using System;
using SoftwareRenderer.Assets;
using SoftwareRenderer.MathExt;

namespace SoftwareRenderer.Render;

public class Renderer
{
    private Image target;

    public Renderer(Image target)
    {
        this.target = target;
    }

    public void DrawLine(Vector2i start, Vector2i end, int color)
    {
        int d_x = end.X - start.X;
        int d_y = end.Y - start.Y;
        if (Math.Abs(d_y) < Math.Abs(d_x))
        {
            if (d_x < 0)
            {
                (start, end) = (end, start);
                d_x = end.X - start.X;
            }
            d_y = Math.Abs(end.Y - start.Y);
            int err = 0;
            int delta_err = d_y + 1;
            int y = start.Y;
            int step = end.Y > start.Y ? 1 : -1;
            for (int x = start.X; x <= end.X; x++)
            {
                target.Data[y * target.Width + x] = color;
                err += delta_err;
                if (err >= d_x + 1)
                {
                    y += step;
                    err -= d_x + 1;
                }
            }
        }
        else
        {
            if (d_y < 0)
            {
                (start, end) = (end, start);
                d_y = end.Y - start.Y;
            }
            d_x = Math.Abs(end.X - start.X);
            int err = 0;
            int delta_err = d_x + 1;
            int x = start.X;
            int step = end.X > start.X ? 1 : -1;
            for (int y = start.Y; y <= end.Y; y++)
            {
                target.Data[y * target.Width + x] = color;
                err += delta_err;
                if (err >= d_y + 1)
                {
                    x += step;
                    err -= d_y + 1;
                }
            }
        }
    }

    public void MadeChessPattern()
    {
        int white = Color.CreateColor(255, 255, 255);
        for (int x = 0; x < target.Width; x++)
        {
            for (int y = 0; y < target.Height; y++)
            {
                if ((x + y) % 2 == 1)
                {
                    target.Data[y * target.Width + x] = white;
                }
            }
        }
    }
}