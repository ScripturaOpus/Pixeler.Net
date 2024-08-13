using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Image = SixLabors.ImageSharp.Image;
using Size = SixLabors.ImageSharp.Size;

namespace Pixeler.Net;

internal static class ImageConverter
{
    private const int SizeW = 32;
    private const int SizeH = 32;

    public static string[,] ImageToHexColors(string imagePath)
    {
        using var image = Image.Load<Rgba32>(imagePath);

        var resizedImage = image.Clone(x => x.Resize(new ResizeOptions
        {
            Size = new Size(SizeW, SizeH),
            Mode = ResizeMode.Stretch
        }));

        var colors = new string[SizeW, SizeH];

        for (int y = 0; y < resizedImage.Height; y++)
        {
            for (int x = 0; x < resizedImage.Width; x++)
            {
                var pixel = resizedImage[y, x];
                var hexColor = $"{pixel.R:X2}{pixel.G:X2}{pixel.B:X2}";
                colors[x, y] = hexColor;
            }
        }

        return colors;
    }
}
