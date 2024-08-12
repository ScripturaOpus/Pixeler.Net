using Pixeler.Net.Models;
using System.Diagnostics;
using static Vanara.PInvoke.User32;

namespace Pixeler.Net.Classes;

internal class MovementManager
{
    private readonly CanvasConfiguration _config;

    public MovementManager(CanvasConfiguration canvasConfig)
    {
        _config = canvasConfig;
    }

    // Canvas locations
    Point colorPanelButton;
    Point hexInputField;
    Point exitColorPanelButton;

    Point cellSize;

    public void StartPaintingImage()
    {
        if (string.IsNullOrEmpty(_config.ImagePath))
        {
            Pixeler.StaticLogMessage($"Failed to locate image \"{_config.ImagePath}\"");
            Pixeler.StaticUpdateOperation("Waiting for image.");
            return;
        }

        bool exit = false;

        Pixeler.Hotkey.KeyDown += (sender, e)
            => exit = true;

        string[,] hexValues = ImageConverter.ImageToHexColors(_config.ImagePath);
        Point[,] canvasPoints = CreateCanvasGrid(_config.CanvasTopLeft, _config.CanvasBottomRight);

        colorPanelButton = canvasPoints[21, 31];
        colorPanelButton.Y += 4 * cellSize.Y;

        hexInputField = canvasPoints[21, 28]; // Just happens to be on top of the canvas

        exitColorPanelButton = canvasPoints[31, 15];
        exitColorPanelButton.X += 4 * cellSize.X;

        SetRobloxAsForeground();

        string lastColor = string.Empty;
        for (int x = 0; x < 32; ++x)
        {
            for (int y = 0; y < 32; ++y)
            {
                if (exit)
                {
                    Pixeler.StaticLogMessage("Stop hotkey entered.");
                    return;
                }

                var nextColor = hexValues[x, y];

                // Skip the color change if we're already using the right color
                if (lastColor != nextColor)
                    ChangeColor(hexValues[x, y]);

                SendClick(canvasPoints[x, y]);

                Task.Delay((int)(10 * _config.TimeDelay)).Wait();
            }
        }
    }

    private void ChangeColor(string hexColor)
    {
        // Click color panel button
        SendClick(colorPanelButton);

        // Get hex color input field
        SendClick(hexInputField);

        // Type color
        TypeHexColor(hexColor);

        // Get exit button
        SendClick(exitColorPanelButton);
    }

    public Point[,] CreateCanvasGrid(Point topLeft, Point bottomRight)
    {
        int width = bottomRight.X - topLeft.X;
        int height = bottomRight.Y - topLeft.Y;

        int cellWidth = width / 32;
        int cellHeight = height / 32;

        cellSize = new(cellWidth, cellHeight);

        Point[,] grid = new Point[32, 32];
        for (int row = 0; row < 32; row++)
        {
            for (int col = 0; col < 32; col++)
            {
                int x = topLeft.X + col * cellWidth;
                int y = topLeft.Y + row * cellHeight;
                grid[row, col] = new Point(x, y);
            }
        }

        return grid;
    }

    private static void SetRobloxAsForeground()
    {
        var robloxProcess = Process.GetProcesses()
            .FirstOrDefault(proc => proc.ProcessName.Contains("Roblox"));

        if (robloxProcess is null)
            return;

        SetForegroundWindow(robloxProcess.Handle);
    }

    private static void SendClick(Point point)
    {
        Pixeler.StaticUpdateOperation($"Sending mouse down/up");

        INPUT[] inputs =
        [
            new()
            {
                type = INPUTTYPE.INPUT_MOUSE,
                mi = new()
                {
                    dx = point.X,
                    dy = point.Y,
                    dwFlags = MOUSEEVENTF.MOUSEEVENTF_MOVE | MOUSEEVENTF.MOUSEEVENTF_LEFTDOWN,
                    dwExtraInfo = GetMessageExtraInfo()
                }
            },
            new()
            {
                type = INPUTTYPE.INPUT_MOUSE,
                mi = new()
                {
                    dwFlags = MOUSEEVENTF.MOUSEEVENTF_LEFTUP,
                    dwExtraInfo = GetMessageExtraInfo()
                }
            }
        ];

        var result = SendInput((uint)inputs.Length, inputs, 40);

        if (result != 2)
        {
            Pixeler.StaticLogMessage($"Tried left mouseclick. Result: {result}");
        }
    }

    private static void TypeHexColor(string hexColor)
    {
        INPUT[] inputs = new INPUT[2];

        foreach (char c in hexColor)
        {
            Pixeler.StaticUpdateOperation($"Sending keycode `{c}` ({c:x00})");

            var keyCode = char.ToUpper(c);

            inputs[0].type = INPUTTYPE.INPUT_KEYBOARD;
            inputs[0].ki = new()
            {
                wVk = keyCode,
            };

            inputs[1].type = INPUTTYPE.INPUT_KEYBOARD;
            inputs[1].ki = new()
            {
                wVk = keyCode,
                dwFlags = KEYEVENTF.KEYEVENTF_KEYUP
            };

            var result = SendInput((uint)inputs.Length, inputs, 24);

            if (result != 2)
            {
                Pixeler.StaticLogMessage($"Tried keycode `{c}` ({c:x00}). Result: {result}");
            }
        }
    }
}

