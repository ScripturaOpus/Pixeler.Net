using Pixeler.Net.Classes;
using Pixeler.Net.Models;

namespace Pixeler.Net.Forms;

public partial class BoundsVisualizer : Form
{
    private readonly CanvasConfiguration config;

    public BoundsVisualizer(CanvasConfiguration _config)
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        InitializeComponent();

        config = _config;
        BackColor = Color.Red;
        Opacity = .25;
    }

    public void UpdatePoints()
    {
        // Update the points using the config reference

        int width = config.CanvasBottomRight.X - config.CanvasTopLeft.X;
        int height = config.CanvasBottomRight.Y - config.CanvasTopLeft.Y;

        Size = new Size(width, height);
        Location = config.CanvasTopLeft;
        Invalidate();
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

    protected override void OnPaint(PaintEventArgs e)
    {
        DrawDots(e.Graphics);
        base.OnPaint(e);
    }

    protected override void OnLoad(EventArgs e)
    {
        UpdatePoints();

        base.OnLoad(e);
    }
}
