﻿using Pixeler.Net.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

namespace Pixeler.Net.Classes;

internal class MovementManager
{
    private readonly CanvasConfiguration _config;

    readonly CanvasCoordinatePair[,] coordinatePairs = new CanvasCoordinatePair[32, 32];

    [DllImport("gdi32.dll")] 
    private static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

    [DllImport("user32.dll")]
    static extern IntPtr GetDC(IntPtr hWnd);

    public MovementManager(CanvasConfiguration canvasConfig)
    {
        // Create a copy of the config
        _config = new(canvasConfig);

        var display = Screen.AllScreens.First(screen => screen.DeviceName == _config.DrawScreen).Bounds;
        screenWidth = display.Width;
        screenHeight = display.Height;

        timeDelay = (int)(10 * _config.TimeDelayMultiplier);
    }

    // Canvas locations
    Point colorPanelButton;
    Point hexInputField;
    Point exitColorPanelButton;

    Point cellSize;

    int timeDelay;

    int screenWidth;
    int screenHeight;

    bool abortDrawCall;

    public void ExternalCancel()
        => abortDrawCall = true;

    public void StartPaintingImage()
    {
        Initialize();

        var pointPairs = SortColors(coordinatePairs, _config.PaintingMethod);

        // First click to make window in focus (Might make something better later)
        SendClick(coordinatePairs[0, 0].Point);

        const float stepIncrement = 100 / 1024f;
        float progress = stepIncrement;

        string lastColor = string.Empty;
        for (int x = 0; x < 32; ++x)
        {
            for (int y = 0; y < 32; ++y)
            {
                if (abortDrawCall)
                {
                    PixelerForm.StaticLogMessage("Stop hotkey entered.");
                    goto Exit;
                }

                var color = pointPairs[x, y].HexColor;

                // Skip the color change if we're already using the right color
                bool changeColor = lastColor != color;
                if (changeColor)
                    ChangeColor(color);

                // Paint the pixel (Twice to make sure it registers)
                SendClick(pointPairs[x, y].Point, false);
                SendClick(pointPairs[x, y].Point, false);

                progress += stepIncrement;
                PixelerForm.StaticUpdateOperation($"Painting progress: {progress:n0}%/100%");

                Wait();

                lastColor = color;
            }
        }

    Exit:
        PixelerForm.GlobalHooks.KeyDown -= HandleKeyInput;
    }

    public void ValidateColors()
    {
        Initialize();

        var pointPairs = SortColors(coordinatePairs, _config.PaintingMethod);

        const float stepIncrement = 100 / 1024f;
        float progress = stepIncrement;

        var screenHdc = GetDC(IntPtr.Zero);

        // First click to make window in focus (Might make something better later)
        SendClick(coordinatePairs[0, 0].Point);

        string lastColor = string.Empty;
        for (int x = 0; x < 32; ++x)
        {
            for (int y = 0; y < 32; ++y)
            {
                if (abortDrawCall)
                {
                    PixelerForm.StaticLogMessage("Stop hotkey entered.");
                    goto Exit;
                }

                var pair = pointPairs[x, y];
                var point = pair.Point;

                var pixel = GetPixel(screenHdc, point.X, point.Y);
                var pixelColor = ColorTranslator.FromWin32((int)pixel);

                var hexPixelColor = $"{pixelColor.R:X2}{pixelColor.G:X2}{pixelColor.B:X2}";

                var color = pair.HexColor;
                Debug.WriteLine($"{hexPixelColor} -> {color}");

                if (color != hexPixelColor)
                {
                    PixelerForm.StaticLogMessage($"Redrawing pixel `{hexPixelColor}` -> `{color}`");

                    // Skip the color change if we're already using the right color
                    bool changeColor = lastColor != color;
                    if (changeColor)
                        ChangeColor(color);

                    SendClick(point, false);
                }
                   
                progress += stepIncrement;
                PixelerForm.StaticUpdateOperation($"Painting progress: {progress:n0}%/100%");

                lastColor = color;
            }
        }

    Exit:
        PixelerForm.GlobalHooks.KeyDown -= HandleKeyInput;

        // First click to make window in focus (Might make something better later)
        SendClick(coordinatePairs[0, 0].Point);
    }

    private void Initialize()
    {
        var hexValues = ImageConverter.ImageToHexColors(_config.ImagePath);
        var canvasPoints = CreateCanvasGrid();

        for (int x = 0; x < 32; ++x)
            for (int y = 0; y < 32; ++y)
                coordinatePairs[x, y] = new(canvasPoints[x, y], hexValues[x, y]);

        colorPanelButton = canvasPoints[31, 22];
        colorPanelButton.X += (int)(.5 * cellSize.X);
        colorPanelButton.Y += 3 * cellSize.Y;

        hexInputField = canvasPoints[29, 22]; // Just happens to be on top of the canvas

        exitColorPanelButton = canvasPoints[15, 31];
        exitColorPanelButton.X += 4 * cellSize.X;

        abortDrawCall = false;

        PixelerForm.GlobalHooks.KeyDown += HandleKeyInput;
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
        Wait(5);

        // Get hex color input field
        SendClick(hexInputField);
        Wait();

        // Type color
        TypeHexColor(hexColor);

        // Get exit button (Twice to make sure it closes)
        SendClick(exitColorPanelButton);
    }

    private void SendClick(Point point, bool skipDelay = false)
    {
        int normalizedX = (int)(point.X * 65535.0 / screenWidth);
        int normalizedY = (int)(point.Y * 65535.0 / screenHeight);

        INPUT[] inputs =
        [
            new()
            {
                type = INPUTTYPE.INPUT_MOUSE,
                mi = new()
                {
                    // Offset to give game time to notice mouse movement
                    dx = normalizedX - 1,
                    dy = normalizedY - 1,
                    dwFlags = MOUSEEVENTF.MOUSEEVENTF_MOVE | MOUSEEVENTF.MOUSEEVENTF_ABSOLUTE
                }
            },
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

            if (result != 1)
                PixelerForm.StaticLogMessage($"Sent left mouseclick. Successful actions: {result}");

            if (!skipDelay)
                Wait(1);
        }
    }

    private void TypeHexColor(string hexColor)
    {
        Wait(5);

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
        PixelerForm.StaticLogMessage($"Tried hex color `{hexColor}`. Successful actions: {result}");
    }

    internal Point[,] CreateCanvasGrid()
    {
        var topLeft = _config.CanvasTopLeft;
        var bottomRight = _config.CanvasBottomRight;

        int width = bottomRight.X - topLeft.X;
        int height = bottomRight.Y - topLeft.Y;

        int cellWidth = width / 32;
        int cellHeight = height / 32;

        cellSize = new(cellWidth, cellHeight);

        var halfX = cellSize.X / 2;
        var halfY = cellSize.Y / 2;

        Point[,] grid = new Point[32, 32];

        for (int row = 0; row < 32; row++)
        {
            for (int col = 0; col < 32; col++)
            {
                int x = topLeft.X + col * cellWidth + halfX;
                int y = topLeft.Y + row * cellHeight + halfY;
                grid[row, col] = new Point(x, y);
            }
        }

        return grid;
    }

    private static CanvasCoordinatePair[,] SortColors(CanvasCoordinatePair[,] pointPairs, PaintingMethod method)
    {
        // Reorganize the points for painting efficiency
        switch (method)
        {
            case PaintingMethod.ColorByColor:
                return SortByHexColor(pointPairs);

            case PaintingMethod.MostToLeastAppearance:
                return SortByColorFrequency(pointPairs);

            case PaintingMethod.Classic:
                // Do nothing, it's already sorted for "classic" painting
                break;
        }

        return pointPairs;
    }

    private static CanvasCoordinatePair[,] SortByHexColor(CanvasCoordinatePair[,] originalArray)
    {
        // Flatten the array
        var flattenedArray = originalArray.Cast<CanvasCoordinatePair>().ToArray();

        // Sort the flattened array by HexColor
        Array.Sort(flattenedArray, (a, b) => string.Compare(a.HexColor, b.HexColor));

        // Reconstruct the 2D array
        CanvasCoordinatePair[,] sortedArray = new CanvasCoordinatePair[32, 32];
        int index = 0;
        for (int row = 0; row < 32; row++)
        {
            for (int col = 0; col < 32; col++)
            {
                sortedArray[row, col] = flattenedArray[index++];
            }
        }

        return sortedArray;
    }

    public static CanvasCoordinatePair[,] SortByColorFrequency(CanvasCoordinatePair[,] originalArray)
    {
        // Flatten the array
        var flattenedArray = originalArray.Cast<CanvasCoordinatePair>().ToArray();

        // Create a dictionary to count color frequencies
        var colorFrequency = new Dictionary<string, int>();
        foreach (var pair in flattenedArray)
        {
            if (colorFrequency.ContainsKey(pair.HexColor))
                colorFrequency[pair.HexColor]++;
            else
                colorFrequency[pair.HexColor] = 1;
        }

        // Sort colors by frequency descending
        var sortedColors = colorFrequency.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

        // Reconstruct the array based on color frequency
        CanvasCoordinatePair[,] sortedArray = new CanvasCoordinatePair[32, 32];
        int index = 0;
        foreach (var color in sortedColors)
        {
            foreach (var pair in flattenedArray)
            {
                if (pair.HexColor == color)
                {
                    sortedArray[index / 32, index % 32] = pair;
                    index++;
                }
            }
        }

        return sortedArray;
    }

    internal sealed class CanvasCoordinatePair
    {
        public CanvasCoordinatePair(Point point, string hexColor)
        {
            Point = point;
            HexColor = hexColor;
        }

        public Point Point { get; set; }
        public string HexColor { get; set; }
    }
}