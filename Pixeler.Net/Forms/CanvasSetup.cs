using Pixeler.Net.Models;
using System.ComponentModel;

namespace Pixeler.Net.Forms;

public partial class CanvasSetup : Form
{
    private delegate void ConfigurationCreatedEventHandler(object sender, CanvasConfiguration config);
    private event ConfigurationCreatedEventHandler ConfigurationCreated;

    private BackgroundWorker backgroundWorker;
    private List<Point> clickPoints = new();

    private CanvasConfiguration _config = new();

    public static CanvasConfiguration? PromptForNewConfiguration(Form sender)
    {
        var promptForm = new CanvasSetup();
        CanvasConfiguration? returnedConfig = null;

        // Wait for form to return config
        promptForm.ConfigurationCreated += (sender, config) =>
        {
            returnedConfig = config;
        };

        promptForm.ShowDialog(sender);
        return returnedConfig;
    }

    public CanvasSetup()
    {
        InitializeComponent();

        backgroundWorker = new()
        {
            WorkerSupportsCancellation = true
        };

        FormClosed += (sender, args) =>
        {
            Pixeler.StaticLogMessage("Canceled configuration update.");
        };

        backgroundWorker.DoWork += BackgroundWorker_DoWork;
        backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
    }

    private void SetTopLeft_Click(object? sender, EventArgs e)
    {
        if (startButton.Text == "Set")
        {
            startButton.Text = "Cancel";
            clickPoints.Clear();
            Pixeler.GlobalHooks.MouseClick += HookManager_MouseClick;
            backgroundWorker.RunWorkerAsync();
        }
        else
        {
            startButton.Text = "Set";
            backgroundWorker.CancelAsync();
            Pixeler.GlobalHooks.MouseClick -= HookManager_MouseClick;
        }
    }

    private void ConfirmConfig_Click(object? sender, EventArgs? _)
    {
        ConfigurationCreated?.Invoke(this, _config);
        DialogResult = DialogResult.OK;
    }

    private void HookManager_MouseClick(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            clickPoints.Add(new Point(e.X, e.Y));
        }
    }

    private void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
    {
        var worker = sender as BackgroundWorker;

        while (!worker.CancellationPending)
        {
            Thread.Sleep(10);
        }
    }

    private void BackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        startButton.Text = "Set";
        // Process clickPoints here
    }
}
