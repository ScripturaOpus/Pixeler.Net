using Pixeler.Net.Classes;
using Pixeler.Net.Models;

namespace Pixeler.Net.Forms;

internal partial class BoundsVisualizer : Form
{
    private readonly CanvasConfiguration config;

    internal BoundsVisualizer(CanvasConfiguration _config)
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        InitializeComponent();

        // The reference from CanvasSetup is needed for updates real-time
        config = _config;
        BackColor = Color.Red;
        Opacity = .25;

        Load += (sender, e) =>
        {
            UpdatePoints();
        };

        Paint += (sender, e) =>
        {
            DrawDots(e.Graphics);
        };
    }

    public void UpdatePoints()
    {
        // Update the points using the config reference from CanvasSetup
        int width = config.CanvasBottomRight.X - config.CanvasTopLeft.X;
        int height = config.CanvasBottomRight.Y - config.CanvasTopLeft.Y;

        Size = new Size(width, height);
        Location = config.CanvasTopLeft;
        Refresh();
    }

    private void DrawDots(Graphics g)
    {
        using var brush = new SolidBrush(Color.Black); // Replace with desired color

        // Draw each dot
        foreach (var point in new MovementManager(config).CreateCanvasGrid())
        {
            var formPoint = PointToClient(point);
            g.FillEllipse(brush, formPoint.X - 2, formPoint.Y - 2, 4, 4);
        }
    }
}
