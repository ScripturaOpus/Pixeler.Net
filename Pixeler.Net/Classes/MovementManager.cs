using Pixeler.Net.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;
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
    CanvasPoint colorPanelButton;
    CanvasPoint hexInputField;
    CanvasPoint exitColorPanelButton;

    CanvasPoint cellSize;

    int timeDelay;

    int screenWidth;
    int screenHeight;

    bool abortDrawCall;

    public void ExternalCancel()
        => abortDrawCall = true;

    public void StartPaintingImage()
    {
        abortDrawCall = false;

        Pixeler.GlobalHooks.KeyDown += HandleKeyInput;

        string[,] hexValues = ImageConverter.ImageToHexColors(_config.ImagePath);
        CanvasPoint[,] canvasPoints = CreateCanvasGrid(_config.CanvasTopLeft, _config.CanvasBottomRight);

        colorPanelButton = canvasPoints[31, 22];
        colorPanelButton.X += (int)(.5 * cellSize.X);
        colorPanelButton.Y += 3 * cellSize.Y;

        hexInputField = canvasPoints[29, 22]; // Just happens to be on top of the canvas

        exitColorPanelButton = canvasPoints[15, 31];
        exitColorPanelButton.X += 4 * cellSize.X;

        var display = Screen.AllScreens.First(screen => screen.DeviceName == _config.DrawScreen).Bounds;
        screenWidth = display.Width;
        screenHeight = display.Height;

        timeDelay = (int)(10 * _config.TimeDelayMultiplier);

        // SetRobloxAsForeground();

        string lastColor = string.Empty;
        for (int x = 0; x < 32; ++x)
        {
            for (int y = 0; y < 32; ++y)
            {
                if (abortDrawCall)
                {
                    Pixeler.StaticLogMessage("Stop hotkey entered.");
                    goto Exit;
                }

                var color = hexValues[x, y];

                // Skip the color change if we're already using the right color
                bool changeColor = lastColor != color;
                if (changeColor)
                    ChangeColor(hexValues[x, y]);

                SendClick(canvasPoints[x, y], changeColor);

                lastColor = color;
            }
        }

    Exit:
        Pixeler.GlobalHooks.KeyDown -= HandleKeyInput;
    }

    private void Wait(int? delay = null)
        => Task.Delay(delay ?? timeDelay).Wait();

    private void HandleKeyInput(object? sender, KeyEventArgs e)
    {
        if (e.KeyValue == _config.CancellationHotkey)
            abortDrawCall = true;
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

    public CanvasPoint[,] CreateCanvasGrid(Point topLeft, Point bottomRight)
    {
        int width = bottomRight.X - topLeft.X;
        int height = bottomRight.Y - topLeft.Y;

        int cellWidth = width / 32;
        int cellHeight = height / 32;

        cellSize = new(cellWidth, cellHeight); // Retained cellSize

        var halfX = cellSize.X / 2;
        var halfY = cellSize.Y / 2;

        CanvasPoint[,] grid = new CanvasPoint[32, 32];

        for (int row = 0; row < 32; row++)
        {
            for (int col = 0; col < 32; col++)
            {
                int x = topLeft.X + col * cellWidth + halfX;
                int y = topLeft.Y + row * cellHeight + halfY;
                grid[row, col] = new CanvasPoint(x, y);
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

    private void SendClick(CanvasPoint point, bool skipDelay = false)
    {
        // if (!SetCursorPos(point.X, point.Y))
        // {
        //     Pixeler.StaticLogMessage($"Failed to set cursor position to X: {point.X}, Y: {point.Y}");
        //     return;
        // }

        Pixeler.StaticUpdateOperation($"Sending mouse down/up");

        int normalizedX = (int)(point.X * 65535.0 / screenWidth);
        int normalizedY = (int)(point.Y * 65535.0 / screenHeight);

        INPUT[] inputs =
        [
            new() 
            {
                type = INPUTTYPE.INPUT_MOUSE,
                mi = new() 
                {
                    dx = normalizedX,
                    dy = normalizedY,
                    dwFlags = MOUSEEVENTF.MOUSEEVENTF_MOVE | MOUSEEVENTF.MOUSEEVENTF_ABSOLUTE
                }
            },
            new()
            {
                type = INPUTTYPE.INPUT_MOUSE,
                mi = new()
                {
                    dwFlags = MOUSEEVENTF.MOUSEEVENTF_LEFTDOWN,
                }
            },
            new()
            {
                type = INPUTTYPE.INPUT_MOUSE,
                mi = new()
                {
                    dwFlags = MOUSEEVENTF.MOUSEEVENTF_LEFTUP,
                }
            }
        ];

        foreach (var input in inputs)
        {
            var result = SendInput(1, [input], Marshal.SizeOf<INPUT>());

            if (result != 2)
            {
                Pixeler.StaticLogMessage($"Sent left mouseclick. Successful actions: {result}");
            }

            if (!skipDelay)
                Wait(timeDelay / 2);
        }
    }

    private void TypeHexColor(string hexColor)
    {
        INPUT[] inputs = new INPUT[12];

        int colorIndex = 0;
        for (int i = 0; i < inputs.Length; i += 2)
        {
            char c = hexColor[colorIndex++];

            var keyCode = char.ToUpper(c);

            inputs[i].type = INPUTTYPE.INPUT_KEYBOARD;
            inputs[i].ki = new()
            {
                wVk = keyCode,
            };

            inputs[i + 1].type = INPUTTYPE.INPUT_KEYBOARD;
            inputs[i + 1].ki = new()
            {
                wVk = keyCode,
                dwFlags = KEYEVENTF.KEYEVENTF_KEYUP
            };
        }

        var result = SendInput((uint)inputs.Length, inputs, Marshal.SizeOf<INPUT>());
        Pixeler.StaticLogMessage($"Tried hex color `{hexColor}`. Successful actions: {result}");

        Wait();
    }

    internal sealed class CanvasPoint
    {
        public CanvasPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public CanvasPoint(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}

