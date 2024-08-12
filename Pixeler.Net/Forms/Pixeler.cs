using Gma.System.MouseKeyHook;
using Pixeler.Net.Classes;
using Pixeler.Net.Forms;
using Pixeler.Net.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Security;

namespace Pixeler.Net;

public partial class Pixeler : Form
{
    public static Pixeler Instance { get; private set; }

    internal static GlobalHotkeys Hotkey { get; private set; } = new();
    internal static IKeyboardMouseEvents GlobalHooks = Hook.GlobalEvents();

    private CanvasConfiguration canvasConfig = new();

    public Pixeler()
    {
        Instance = this;
        InitializeComponent();

        Hotkey.HookedKeys.Add(Keys.G);
        Hotkey.KeyDown += (sender, e) => Debug.WriteLine("Hotkey entered: " + e.KeyValue);

        Load += (sender, e) => UpdateOperation();
    }

    /// <summary>
    /// Static and asyncronous accessor for <see cref="LogMessage(string)"/>
    /// </summary>
    /// <param name="message"></param>
    public static void StaticLogMessage(string message)
    {
        Instance.currentOperation.BeginInvoke(new MethodInvoker(() 
            => Instance.LogMessage(message)));
    }

    /// <summary>
    /// Static and asyncronous accessor for <see cref="UpdateOperation(string)"/>
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

        canvasConfig = newConfig;
    }

    /// <summary>
    /// Start painting image on a background worker thread (Using <see cref="WorkerTask_PaintPicture(object?, DoWorkEventArgs)"/>)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PaintStart_Click(object sender, EventArgs e)
    {
        var sw = Stopwatch.StartNew();
        var worker = new BackgroundWorker();
        worker.DoWork += WorkerTask_PaintPicture;
        worker.RunWorkerCompleted += (sender, e)
            => StaticLogMessage($"-------------\nPainting complete. Took {sw.ElapsedMilliseconds:n0}ms");
        worker.RunWorkerAsync();
    }

    private void WorkerTask_PaintPicture(object? sender, DoWorkEventArgs e)
    {
        var mm = new MovementManager(canvasConfig);
        mm.StartPaintingImage();
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
                canvasConfig.ImagePath = openFileDialog.FileName;
                currentImageFilePath.Text = Path.GetFileName(canvasConfig.ImagePath);
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
            }
        }
    }
}
