using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Drawing.Drawing2D;
using Image = System.Drawing.Image;
using SImage = SixLabors.ImageSharp.Image;
using SSize = SixLabors.ImageSharp.Size;
using RectangleF = System.Drawing.RectangleF;
using SizeF = System.Drawing.SizeF;
using PointF = System.Drawing.PointF;
using System.Windows.Forms;

namespace Pixeler.Net.Forms;

public partial class ImagePreview : Form
{
    private Image image;

    public ImagePreview(string imagePath)
    {
        InitializeComponent();

        var image = SImage.Load<Rgba32>(imagePath);
        image = image.Clone(x => x.Resize(new ResizeOptions
        {
            Size = new SSize(32, 32),
            Mode = ResizeMode.BoxPad
        }));

        using var ms = new MemoryStream();
        image.SaveAsPng(ms);
        ms.Position = 0;
        this.image = Image.FromStream(ms);

        var pictureBox = new PictureBox();
        pictureBox.Paint += Picture_OnPaint;

        Resize += (sender, e) => pictureBox.Invalidate();

        Controls.Add(pictureBox);
    }

    public void Picture_OnPaint(object? sender, PaintEventArgs e)
    {
        var pb = (PictureBox)sender;

        pb.Size = ClientSize;
        e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
        e.Graphics.DrawImage(image, GetScaledImageRect(image, pb.ClientSize));
    }

    private RectangleF GetScaledImageRect(Image image, SizeF containerSize)
    {
        var imgRect = RectangleF.Empty;

        var scaleFactor = image.Width / image.Height;
        var containerRatio = containerSize.Width / containerSize.Height;

        if (containerRatio >= scaleFactor)
        {
            imgRect.Size = new SizeF(containerSize.Height * scaleFactor, containerSize.Height);
            imgRect.Location = new PointF((containerSize.Width - imgRect.Width) / 2, 0);
        }
        else
        {
            imgRect.Size = new SizeF(containerSize.Width, containerSize.Width / scaleFactor);
            imgRect.Location = new PointF(0, (containerSize.Height - imgRect.Height) / 2);
        }

        return imgRect;
    }
}
