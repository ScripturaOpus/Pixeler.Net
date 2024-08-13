using Pixeler.Net.Models;
using System.ComponentModel;

namespace Pixeler.Net.Forms;

public partial class CanvasSetup : Form
{
    private delegate void ConfigurationCreatedEventHandler(object sender, CanvasConfiguration config);
    private event ConfigurationCreatedEventHandler ConfigurationCreated;

    private readonly List<Point> clickPoints = [];
    private readonly CanvasConfiguration _config;

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
        speedMultiplier.Value = (decimal)_config.TimeDelayMultiplier;

        var allScreens = Screen.AllScreens;
        var usedScreen = !allScreens.Any(screen => screen.DeviceName == _config.DrawScreen)
            ? allScreens.First(screen => screen.Primary).DeviceName
            : _config.DrawScreen!;

        if (allScreens.Length is 1)
        {
            // The user has no option but their primary display
            // No point prompting for an alternative

            screenSelection.Enabled = false;
            screenSelection.Items.Add(usedScreen);
            screenSelection.Text = usedScreen;
        }
        else
        {
            screenSelection.Items.AddRange(allScreens.Select(screen => screen.DeviceName).ToArray());
            screenSelection.Text = usedScreen;
        }

    }

    protected override void OnClosing(CancelEventArgs e)
    {
        boundsVisualizer?.Close();
        base.OnClosing(e);
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
            clickPoints.Add(e.Location);

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

    private void SpeedMultiplier_ValueChanged(object sender, EventArgs e)
    {
        _config.TimeDelayMultiplier = (float)speedMultiplier.Value;
    }

    private void ScreenSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        _config.DrawScreen = screenSelection.Text;
    }

    private BoundsVisualizer? boundsVisualizer = null;
    private void VisualizeBounds_Click(object sender, EventArgs e)
    {
        if (boundsVisualizer is not null)
        {
            boundsVisualizer.Close();
            boundsVisualizer = null;
            visualizeBounds.Text = "Visualize Bounds";

            return;
        }

        boundsVisualizer = new BoundsVisualizer(_config);
        boundsVisualizer.Show();
        visualizeBounds.Text = "Close Visualizer";

        // Make sure this form doesn't get trapped behind the boundary form
        BringToFront();
    }
}
