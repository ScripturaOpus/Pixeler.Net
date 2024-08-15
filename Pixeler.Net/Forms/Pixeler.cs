using Gma.System.MouseKeyHook;
using Pixeler.Net.Classes;
using Pixeler.Net.Forms;
using Pixeler.Net.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Reflection.Metadata.Ecma335;
using System.Security;
using Image = SixLabors.ImageSharp.Image;
using Point = System.Drawing.Point;

namespace Pixeler.Net;

public partial class PixelerForm : Form
{
    private const string downloadedImages = "./downloaded-images";
    private CanvasConfiguration canvasConfig;
    private MovementManager painter;

    public static PixelerForm Instance { get; private set; }

    internal static readonly IKeyboardMouseEvents GlobalHooks = Hook.GlobalEvents();

    public PixelerForm()
    {
        Instance = this;
        InitializeComponent();

        // Hotkeys stop working without this, idk why
        GlobalHooks.KeyDown += (sender, e) =>
        {
            if (e.KeyValue == canvasConfig.EmergencyKillHotkey)
                Application.Exit();

            Debug.WriteLine("Button entered: " + e.KeyValue);
        };

        DragDrop += HandleFileDrop;
        DragEnter += HandleFileEnter;

        // Check if there's already an image in the users clipboard
        LoadImageFromClipboard();
    }

    protected override void OnLoad(EventArgs e)
    {
        UpdateOperation("Loading configurations.");
        canvasConfig = ConfigurationManager.LoadConfigFromFile();

        UpdateOperation();

        if (!string.IsNullOrWhiteSpace(canvasConfig.ImagePath))
            currentImageFilePath.Text = Path.GetFileName(canvasConfig.ImagePath);
    }

    /// <summary>
    /// Static and asynchronous accessor for <see cref="LogMessage(string)"/>
    /// </summary>
    /// <param name="message"></param>
    public static void StaticLogMessage(string message)
    {
        Instance.currentOperation.BeginInvoke(new MethodInvoker(()
            => Instance.LogMessage(message)));
    }

    /// <summary>
    /// Static and asynchronous accessor for <see cref="UpdateOperation(string)"/>
    /// </summary>
    /// <param name="operation"></param>
    public static void StaticUpdateOperation(string? operation = null)
    {
        Instance.currentOperation.BeginInvoke(new MethodInvoker(() =>
        {
            Instance.UpdateOperation(operation);
        }));
    }

    /// <summary>
    /// Update the current task on <see cref="currentOperation"/>
    /// </summary>
    /// <param name="operation"></param>
    public void UpdateOperation(string? operation = null)
    {
        currentOperation.Text = $"Currently: {operation ?? "Awaiting next task."}";
        currentOperation.Refresh();
    }

    /// <summary>
    /// Log a message to <see cref="loggingBox"/>
    /// </summary>
    /// <param name="message"></param>
    public void LogMessage(string message)
    {
        loggingBox.AppendText($"{message}\n");
        loggingBox.SelectionStart = loggingBox.Text.Length;
        loggingBox.ScrollToCaret();
    }

    /// <summary>
    /// Create a new <see cref="CanvasSetup"/> form and get game coordinate information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SetupCoordinates_Click(object sender, EventArgs e)
    {
        UpdateOperation("Awaiting new canvas configuration.");
        var newConfig = CanvasSetup.PromptForConfiguration(this, canvasConfig);

        if (newConfig is null)
        {
            LogMessage("Failed to create config : Returned null");
            return;
        }

        LogMessage("New configuration set.");
        UpdateOperation();

        canvasConfig = newConfig;
        canvasConfig.SaveConfigToFile();
    }

    private bool startPaintDebounce = false;
    /// <summary>
    /// Start painting image on a background worker thread (Using <see cref="WorkerTask_PaintPicture(object?, DoWorkEventArgs)"/>)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PaintStart_Click(object sender, EventArgs e)
    {
        if (startPaintDebounce)
        {
            painter?.ExternalCancel();
            startPaintDebounce = false;
            PaintStart.Text = "Start Painting";
            return;
        }

        startPaintDebounce = true;
        PaintStart.Text = "Stop Painting";

        if (!PrePaintChecks())
            return;

        var sw = Stopwatch.StartNew();
        var paintWorker = new BackgroundWorker();
        paintWorker.DoWork += WorkerTask_PaintPicture;

        paintWorker.RunWorkerCompleted += (sender, e) =>
        {
            StaticLogMessage($"-------------\nPainting {((bool)e.Result! ? "complete" : "failed")}. Took {sw.ElapsedMilliseconds:n0}ms");
        };

        paintWorker.RunWorkerAsync();

        startPaintDebounce = false;
        PaintStart.Text = "Start Painting";
    }

    private void validateColors_Click(object sender, EventArgs e)
    {
        if (startPaintDebounce)
        {
            painter?.ExternalCancel();
            startPaintDebounce = false;
            validateColors.Text = "Validate Colors";
            return;
        }

        startPaintDebounce = true;
        validateColors.Text = "Stop Validating";

        if (!PrePaintChecks())
            return;

        var sw = Stopwatch.StartNew();
        var paintWorker = new BackgroundWorker();
        paintWorker.DoWork += WorkerTask_PaintPicture;

        paintWorker.RunWorkerCompleted += (sender, e) =>
        {
            StaticLogMessage($"-------------\nPainting verification {((bool)e.Result! ? "complete" : "failed")}. Took {sw.ElapsedMilliseconds:n0}ms");
        };

        paintWorker.RunWorkerAsync(true);

        startPaintDebounce = false;
        validateColors.Text = "Validate Colors";
    }

    private void WorkerTask_PaintPicture(object? sender, DoWorkEventArgs e)
    {
        try
        {
            painter = new MovementManager(canvasConfig);

            if (e.Argument is not true)
                painter.StartPaintingImage();
            else
                painter.ValidateColors();

            e.Result = true;
        }
        catch (Exception ex)
        {
            StaticLogMessage($"Failed to paint image.\n{ex.GetType().Name}: {ex.Message}");
            e.Result = false;
        }
    }

    private bool PrePaintChecks()
    {
        if (canvasConfig.CanvasBottomRight == new Point(0, 0)
            || canvasConfig.CanvasTopLeft == new Point(0, 0))
        {
            LogMessage("Configuration required to start painting.");
            UpdateOperation("Waiting for coordinate configuration.");
            return false;
        }

        if (string.IsNullOrEmpty(canvasConfig.ImagePath))
        {
            LogMessage("An image is required to start painting.");
            UpdateOperation("Waiting for image.");
            return false;
        }

        if (!File.Exists(canvasConfig.ImagePath))
        {
            LogMessage($"Failed to locate image \"{canvasConfig.ImagePath}\"");
            UpdateOperation("Waiting for image.");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Prompt user for a picture via Windows Explorer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LoadImageButton_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() is DialogResult.OK)
        {
            try
            {
                UpdateImageString(openFileDialog.FileName);
                canvasConfig.SaveConfigToFile();
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\nDetails:\n\n{ex.StackTrace}");
            }
        }
    }

    private Image clipboardImage = null;
    private void LoadImageFromClipboard()
    {
        if (Clipboard.ContainsImage())
        {
            var image = Clipboard.GetDataObject();

            if (image.GetDataPresent(DataFormats.Bitmap))
            {
                var bitmap = (Bitmap)image.GetData(DataFormats.Bitmap);
                using var ms = new MemoryStream();

                bitmap.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                clipboardImage = Image.Load<Rgba32>(ms);
            }
        }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == (Keys.Control | Keys.V))
        {
            LoadImageFromClipboard();

            if (clipboardImage is null)
                goto End;

            string imageFileName = Path.Combine(downloadedImages,
                $"clipboard-image-{Random.Shared.Next():x}.{clipboardImage.Metadata.DecodedImageFormat.FileExtensions.FirstOrDefault() ?? "img"}");
            clipboardImage.Save(imageFileName);

            UpdateOperation("Image copied from clipboard and selected.");
            UpdateImageString(imageFileName);
        }

    End:
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void HandleFileEnter(object? sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop, false)
            || e.Data.GetDataPresent(DataFormats.Html))
        {
            e.Effect = DragDropEffects.All;
            return;
        }

        e.Effect = DragDropEffects.None;
    }

    private async void HandleFileDrop(object? sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
        {
            var file = (string[])e.Data.GetData(DataFormats.FileDrop);
            UpdateImageString(file[0]);
        }
        else if (e.Data.GetDataPresent(DataFormats.Html, false))
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                LogMessage("Unable to connect to the internet. Cannot download image.");
                return;
            }

            string draggedFileUrl = (string)e.Data.GetData(DataFormats.Html, false);
            draggedFileUrl = GetSourceImage(draggedFileUrl);

            UpdateOperation("Downloading image: " + draggedFileUrl);

            Directory.CreateDirectory(downloadedImages);

            string imageFileName;
            try
            {
                using var client = new HttpClient();
                using var result = await client.GetAsync(draggedFileUrl);

                if (!result.IsSuccessStatusCode)
                {
                    LogMessage("Failed to download file from URL: " + draggedFileUrl);
                    return;
                }

                var imageDescription = result.Content.Headers.ContentDisposition;

                var byteData = await result.Content.ReadAsByteArrayAsync();

                string RandomImageName()
                    => $"downloaded-image-{Random.Shared.Next():x}.{Image.DetectFormat(byteData).FileExtensions.FirstOrDefault() ?? "img"}";

                if (imageDescription is not null)
                {
                    imageFileName = imageDescription.FileNameStar
                       ?? imageDescription.FileName?.Trim('"')
                       ?? imageDescription.Name
                       ?? RandomImageName();
                }
                else
                {
                    imageFileName = RandomImageName();
                }

                imageFileName = Path.Combine(downloadedImages, imageFileName);
                await File.WriteAllBytesAsync(imageFileName,
                    byteData);
            }
            catch
            {
                using var image = GetImageFromDataUrl(draggedFileUrl);
                imageFileName = Path.Combine(downloadedImages,
                    $"downloaded-resource-image-{Random.Shared.Next():x}.{image.Metadata.DecodedImageFormat.FileExtensions.FirstOrDefault() ?? "img"}");
                await image.SaveAsync(imageFileName);
            }

            UpdateOperation("Image downloaded and selected.");
            UpdateImageString(imageFileName);
        }
    }

    private static string GetSourceImage(string str)
    {
        string firstString = "src=\"";
        string lastString = "\"";

        int startPos = str.IndexOf(firstString) + firstString.Length;
        string modifiedString = str[startPos..];
        int endPos = modifiedString.IndexOf(lastString);
        return modifiedString[..endPos];
    }

    private Image GetImageFromDataUrl(string dataUrl)
    {
        if (string.IsNullOrEmpty(dataUrl))
            return null;

        try
        {
            // Split the data URL into parts
            string[] parts = dataUrl.Split(',');
            string base64String = parts[1];
            string contentType = parts[0].Split(':')[1];

            byte[] imageBytes = Convert.FromBase64String(base64String);

            using var ms = new MemoryStream(imageBytes);
            return Image.Load(ms);
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine($"Error processing data URL: {ex.Message}");
            return null;
        }
    }

    private void ClearLogsButton_Click(object sender, EventArgs e)
    {
        loggingBox.Text = string.Empty;
    }

    private void UpdateImageString(string imagePath)
    {
        canvasConfig.ImagePath = imagePath;
        currentImageFilePath.Text = Path.GetFileName(imagePath);
        canvasConfig.SaveConfigToFile();
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void minimizeButton_Click(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Minimized;
    }

    private void openSavedImages_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists(downloadedImages))
        {
            LogMessage("You don't have any downloaded images.\nDrag and drop an image from your browser to download it.");
            return;
        }

        Process.Start("explorer", Path.GetFullPath(downloadedImages));
    }

    ImagePreview? imagePreview = null;
    private void viewImage_Click(object sender, EventArgs e)
    {
        if (imagePreview is not null)
        {
            imagePreview.Close();
            imagePreview = null;
            return;
        }

        if (string.IsNullOrWhiteSpace(canvasConfig.ImagePath))
        {
            LogMessage("No image loaded to view.");
            return;
        }

        if (!File.Exists(canvasConfig.ImagePath))
        {
            LogMessage("The image has been deleted or moved. Please select a new image.");
            return;
        }

        imagePreview = new(canvasConfig.ImagePath);
        imagePreview.Show();
    }

    private static readonly IntPtr HWND_TOPMOST = new(-1);
    private static readonly IntPtr HWND_NOTTOPMOST = new(-2);

    private void appearOnTop_CheckedChanged(object sender, EventArgs e)
    {
        Vanara.PInvoke.User32.SetWindowPos(Handle, appearOnTop.Checked
            ? HWND_TOPMOST
            : HWND_NOTTOPMOST, Location.X, Location.Y, Size.Width, Size.Height, 0);
    }
}
