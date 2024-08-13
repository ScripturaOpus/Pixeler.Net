using Newtonsoft.Json;

namespace Pixeler.Net.Models;

public class CanvasConfiguration
{
    /// <summary>
    /// The point for the top left corner of the in-game canvas
    /// </summary>
    [JsonProperty("canvas_top_left_point")]
    public Point CanvasTopLeft { get; set; }

    /// <summary>
    /// The point for the bottom right corner of the in-game canvas
    /// </summary>
    [JsonProperty("canvas_bottom_right_point")]
    public Point CanvasBottomRight { get; set; }

    /// <summary>
    /// The Windows path to the wanted image (Not preloaded for lower memory usage)
    /// </summary>
    [JsonProperty("last_loaded_image")]
    public string ImagePath { get; set; } = string.Empty;

    /// <summary>
    /// The time delay multiplier for simulated device actions (Keyboard, mouse, etc).
    /// <para>
    /// <see langword="delay"/> = (<see cref="int"/>)(<see cref="TimeDelayMultiplier"/> * <see langword="10"/>)
    /// </para>
    /// </summary>
    [JsonProperty("time_delay_multiplier")]
    public float TimeDelayMultiplier { get; set; } = .25f;

    /// <summary>
    /// Stops the image before it's complete
    /// </summary>
    [JsonProperty("cancellation_hotkey")]
    public char CancellationHotkey { get; set; } = 'G';

    /// <summary>
    /// Kills Pixeler.
    /// </summary>
    [JsonProperty("emergency_kill_hotkey")]
    public char? EmergencyKillHotkey { get; set; } = '\0';

    /// <summary>
    /// The screen which is where Pixeler will draw (Defaults to the primary screen)
    /// </summary>
    [JsonProperty("draw_screen")]
    public string? DrawScreen { get; set; } = Screen.PrimaryScreen?.DeviceName;
}
