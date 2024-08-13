using Pixeler.Net.Models;

namespace Pixeler.Net.Forms;

public partial class BoundsVisualizer : Form
{
    private readonly Point onLoadLocation;

    public BoundsVisualizer(CanvasConfiguration config)
    {
        InitializeComponent();

        int width = config.CanvasBottomRight.X - config.CanvasTopLeft.X;
        int height = config.CanvasBottomRight.Y - config.CanvasTopLeft.Y;

        Size = new Size(width, height);
        onLoadLocation = config.CanvasTopLeft;
        BackColor = Color.Red;
        Opacity = .25;
    }

    protected override void OnShown(EventArgs e)
    {
        Location = onLoadLocation;
    }
}
