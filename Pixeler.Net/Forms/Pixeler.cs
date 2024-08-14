using Gma.System.MouseKeyHook;
using Pixeler.Net.Classes;
using Pixeler.Net.Controls;
using Pixeler.Net.Forms;
using Pixeler.Net.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Security;

namespace Pixeler.Net;

public partial class PixelerForm : Form
{
    public static PixelerForm Instance { get; private set; }

    internal static readonly IKeyboardMouseEvents GlobalHooks = Hook.GlobalEvents();

    private CanvasConfiguration canvasConfig;
    private MovementManager painter;

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

        if (canvasConfig.CanvasBottomRight == new Point(0, 0)
            || canvasConfig.CanvasTopLeft == new Point(0, 0))
        {
            LogMessage("Configuration required to start painting.");
            UpdateOperation("Waiting for coordinate configuration.");
            return;
        }

        if (string.IsNullOrEmpty(canvasConfig.ImagePath))
        {
            LogMessage("An image is required to start painting.");
            UpdateOperation("Waiting for image.");
            return;
        }

        if (!File.Exists(canvasConfig.ImagePath))
        {
            LogMessage($"Failed to locate image \"{canvasConfig.ImagePath}\"");
            UpdateOperation("Waiting for image.");
            return;
        }

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

    private void WorkerTask_PaintPicture(object? sender, DoWorkEventArgs e)
    {
        try
        {
            painter = new MovementManager(canvasConfig);
            painter.StartPaintingImage();

            e.Result = true;
        }
        catch (Exception ex)
        {
            StaticLogMessage($"Failed to paint image.\n{ex.GetType().Name}: {ex.Message}");
            e.Result = false;
        }
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

    private void HandleFileEnter(object? sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Copy;
            return;
        }

        e.Effect = DragDropEffects.None;
    }

    private void HandleFileDrop(object? sender, DragEventArgs e)
    {
        var file = (string[])e.Data.GetData(DataFormats.FileDrop);
        UpdateImageString(file[0]);
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
}
