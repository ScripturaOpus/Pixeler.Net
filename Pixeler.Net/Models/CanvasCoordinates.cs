namespace Pixeler.Net.Models;

public class CanvasConfiguration
{
    public Point CanvasTopLeft { get; set; }
    public Point CanvasBottomRight { get; set; }

    public int ColorSelectPanel { get; set; } = 0;

    public string ImagePath { get; set; } = string.Empty;

    public float TimeDelay { get; set; } = .25f;
}
