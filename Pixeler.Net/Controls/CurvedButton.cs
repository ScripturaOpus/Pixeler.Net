using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace Pixeler.Net.Controls;

public class CurvedButton : Button
{
    private int borderSize = 0;
    private int borderRadius = 10;
    private Color borderColor = Color.PaleVioletRed;

    public CurvedButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Size = new Size(150, 40);
        BackColor = Color.SteelBlue;
        ForeColor = Color.White;
        Resize += new EventHandler(Button_Resize);
    }

    [Category("Button Properties")]
    public int BorderSize
    {
        get => borderSize;
        set
        {
            borderSize = value;
            Invalidate();
        }
    }

    [Category("Button Properties")]
    public int BorderRadius
    {
        get => borderRadius;
        set
        {
            borderRadius = value;
            Invalidate();
        }
    }

    [Category("Button Properties")]
    public Color BorderColor
    {
        get => borderColor;
        set
        {
            borderColor = value;
            Invalidate();
        }
    }

    [Category("Button Properties")]
    public Color BackgroundColor
    {
        get => BackColor;
        set => BackColor = value;
    }

    [Category("Button Properties")]
    public Color TextColor
    {
        get => ForeColor;
        set => ForeColor = value;
    }

    private static GraphicsPath GetFigurePath(Rectangle rect, int radius)
    {
        GraphicsPath path = new();
        float curveSize = radius * 2F;

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
        path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
        path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
        path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
        path.CloseFigure();
        return path;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        Rectangle rectSurface = ClientRectangle;
        Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
        
        int smoothSize = 2;
        
        if (borderSize > 0)
            smoothSize = borderSize;

        if (borderRadius > 2)
        {
            using GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius);
            using GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize);
            using Pen penSurface = new(Parent.BackColor, smoothSize);
            using Pen penBorder = new(borderColor, borderSize);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Region = new Region(pathSurface);
            pevent.Graphics.DrawPath(penSurface, pathSurface);

            if (borderSize >= 1)
                pevent.Graphics.DrawPath(penBorder, pathBorder);
        }
        else
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.None;
            Region = new Region(rectSurface);
            
            if (borderSize >= 1)
            {
                using Pen penBorder = new(borderColor, borderSize);
                penBorder.Alignment = PenAlignment.Inset;
                pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
            }
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
    }

    private void Container_BackColorChanged(object? sender, EventArgs e)
    {
        Invalidate();
    }

    private void Button_Resize(object? sender, EventArgs e)
    {
        if (borderRadius > Height)
            borderRadius = Height;
    }
}
