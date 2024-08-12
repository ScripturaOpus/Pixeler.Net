using Pixeler.Net.Models;

namespace Pixeler.Net.Forms;

public partial class CanvasSetup : Form
{
    private delegate void ConfigurationCreatedEventHandler(object sender, CanvasConfiguration config);
    private event ConfigurationCreatedEventHandler ConfigurationCreated;

    private List<Point> clickPoints = new();
    private CanvasConfiguration _config;

    public static CanvasConfiguration? PromptForConfiguration(Form sender, CanvasConfiguration parentConfig)
    {
        var promptForm = new CanvasSetup(parentConfig);
        CanvasConfiguration? returnedConfig = null;

        // Wait for form to return config
        promptForm.ConfigurationCreated += (sender, config) =>
        {
            returnedConfig = config;
        };

        promptForm.ShowDialog(sender);
        return returnedConfig;
    }

    public CanvasSetup(CanvasConfiguration parentConfig)
    {
        InitializeComponent();
        _config = parentConfig;

        UpdateCoordinateLabels();
    }

    private void UpdateCoordinateLabels()
    {
        topLeftLabel.Text = $"X: {_config.CanvasTopLeft.X}, Y: {_config.CanvasTopLeft.Y}";
        bottomRightLabel.Text = $"X: {_config.CanvasBottomRight.X}, Y: {_config.CanvasBottomRight.Y}";
    }

    private bool probingPoints = false;
    private void SetTopLeft_Click(object? sender, EventArgs e)
    {
        if (!probingPoints)
            StartProbing();
        else
            StopProbing();
    }

    private void StartProbing()
    {
        startButton.Text = "Cancel";
        clickPoints.Clear();
        Pixeler.GlobalHooks.MouseClick += HookManager_MouseClick;
        probingPoints = true;
    }

    private void StopProbing()
    {
        startButton.Text = "Set";
        Pixeler.GlobalHooks.MouseClick -= HookManager_MouseClick;
        probingPoints = false;
    }

    private void ConfirmConfig_Click(object? sender, EventArgs? _)
    {
        ConfigurationCreated?.Invoke(this, _config);
        DialogResult = DialogResult.OK;
    }

    private void HookManager_MouseClick(object? sender, MouseEventArgs e)
    {
        if (e.Button is MouseButtons.Left)
        {
            clickPoints.Add(new Point(e.X, e.Y));

            // We have the points, stop scanning
            if (clickPoints.Count is 1)
            {
                _config.CanvasTopLeft = clickPoints[0];
            }
            else
            {
                StopProbing();
                _config.CanvasBottomRight = clickPoints[1];
            }

            UpdateCoordinateLabels();
        }
    }

    private void speedMultiplier_ValueChanged(object sender, EventArgs e)
    {
        _config.TimeDelayMultiplier = (float)speedMultiplier.Value;
    }
}
