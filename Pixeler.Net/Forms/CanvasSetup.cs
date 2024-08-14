using Pixeler.Net.Classes;
using Pixeler.Net.Controls;
using Pixeler.Net.Models;
using System.ComponentModel;

namespace Pixeler.Net.Forms;

public partial class CanvasSetup : Form
{
    private delegate void ConfigurationCreatedEventHandler(object sender, CanvasConfiguration config);
    private event ConfigurationCreatedEventHandler ConfigurationCreated;

    private readonly List<Point> clickPoints = [];
    private readonly CanvasConfiguration _config;

    private bool probingPoints = false;

    private BoundsVisualizer? boundsVisualizer = null;

    bool movingTopLeft = true,
        movingBottomRight = false;

    public static CanvasConfiguration? PromptForConfiguration(Form sender, CanvasConfiguration parentConfig)
    {
        var promptForm = new CanvasSetup(new(parentConfig));
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

        // Not going to bother with screen stuff right now
        screenSelection.Enabled = false;

        //var allScreens = Screen.AllScreens;
        //var usedScreen = !allScreens.Any(screen => screen.DeviceName == _config.DrawScreen)
        //    ? allScreens.First(screen => screen.Primary).DeviceName
        //    : _config.DrawScreen!;
        //
        //if (allScreens.Length is 1)
        //{
        //    // The user has no option but their primary display
        //    // No point prompting for an alternative
        //
        //    screenSelection.Enabled = false;
        //    screenSelection.Items.Add(usedScreen);
        //    screenSelection.Text = usedScreen;
        //}
        //else
        //{
        //    screenSelection.Items.AddRange(allScreens.Select(screen => screen.DeviceName).ToArray());
        //    screenSelection.Text = usedScreen;
        //}

        paintMethodSelection.DataSource = Enum.GetValues(typeof(PaintingMethod));
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
        PixelerForm.GlobalHooks.MouseClick += HookManager_MouseClick;
        probingPoints = true;
    }

    private void StopProbing()
    {
        startButton.Text = "Set";
        PixelerForm.GlobalHooks.MouseClick -= HookManager_MouseClick;
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

    private void PaintMethodSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        _config.PaintingMethod = (PaintingMethod)paintMethodSelection.SelectedValue!;
    }

    private void VisualizeBounds_Click(object sender, EventArgs e)
    {
        if (boundsVisualizer is not null)
        {
            boundsVisualizer.Close();
            boundsVisualizer = null;
            visualizeBounds.Text = "Visualize Bounds";
            TogglePointMoveButtons(false);

            return;
        }

        boundsVisualizer = new BoundsVisualizer(_config);
        boundsVisualizer.Show();
        visualizeBounds.Text = "Close Visualizer";
        TogglePointMoveButtons(true);

        // Make sure this form doesn't get trapped behind the boundary form
        BringToFront();
    }

    private void TogglePointMoveButtons(bool toggle)
    {
        movePointDownButton.Enabled
            = movePointLeftButton.Enabled
            = movePointRightButton.Enabled
            = movePointUpButton.Enabled
            = topLeftPoint.Enabled
            = bothPoints.Enabled
            = bottomRightPoint.Enabled
            = stepCount.Enabled = toggle;
    }

    /*
     * Editing the bounds visualizer
     */

    private void MovePointHorizontal(bool left)
    {
        int step = (int)(left ? -stepCount.Value : stepCount.Value);

        if (movingTopLeft)
            _config.CanvasTopLeft = new(_config.CanvasTopLeft.X + step, _config.CanvasTopLeft.Y);

        if (movingBottomRight)
            _config.CanvasBottomRight = new(_config.CanvasBottomRight.X + step, _config.CanvasBottomRight.Y);

        boundsVisualizer?.UpdatePoints();
    }

    private void MovePointVertical(bool down)
    {
        int step = (int)(down ? stepCount.Value : -stepCount.Value);

        if (movingTopLeft)
            _config.CanvasTopLeft = new(_config.CanvasTopLeft.X, _config.CanvasTopLeft.Y + step);

        if (movingBottomRight)
            _config.CanvasBottomRight = new(_config.CanvasBottomRight.X, _config.CanvasBottomRight.Y + step);

        boundsVisualizer?.UpdatePoints();
    }

    private void MovePointUpButton_Click(object sender, EventArgs e)
    {
        MovePointVertical(false);
    }

    private void MovePointRightButton_Click(object sender, EventArgs e)
    {
        MovePointHorizontal(false);
    }

    private void MovePointLeftButton_Click(object sender, EventArgs e)
    {
        MovePointHorizontal(true);
    }

    private void MovePointDownButton_Click(object sender, EventArgs e)
    {
        MovePointVertical(true);
    }

    private void TopLeftPoint_CheckedChanged(object sender, EventArgs e)
    {
        movingBottomRight = false;
        movingTopLeft = true;
    }

    private void BothPoints_CheckedChanged(object sender, EventArgs e)
    {
        movingBottomRight = movingTopLeft = true;
    }

    private void BottomRightPoint_CheckedChanged(object sender, EventArgs e)
    {
        movingBottomRight = true;
        movingTopLeft = false;
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
