using System;
using System.Runtime.CompilerServices;
using SoftwareRenderer.Assets;
using SoftwareRenderer.IO.Graphics.Models;
using SoftwareRenderer.MathExt;

namespace SoftwareRenderer.Render;

public class Renderer
{
    private Image target;

    public Renderer(Image target)
    {
        this.target = target;
    }
    
    public void DrawLine(Vec2i start, Vec2i end, int color)
    {
        Console.WriteLine($"{start} | {end}");
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
            int delta_err = 2 * d_y;
            int step = end.Y > start.Y ? 1 : -1;
            int row = start.Y * target.Width;
            int row_step = step * target.Width;
            for (int x = start.X; x <= end.X; x++)
            {
                target.Data[row + x] = color;
                err += delta_err;
                if (err >= d_x)
                {
                    row += row_step;
                    err -= d_x * 2;
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
            int delta_err = 2 * d_x;
            int x = start.X;
            int step = end.X > start.X ? 1 : -1;
            int row = start.Y * target.Width;
            for (int y = start.Y; y <= end.Y; y++)
            {
                target.Data[row + x] = color;
                err += delta_err;
                if (err >= d_y)
                {
                    x += step;
                    err -= d_y * 2;
                }
                row += target.Width;
            }
        }
    }

    public void DrawWiredModel(string path)
    {
        var tris = ObjLoader.GetLines(path);
        int c = 0xFFFFFF;
        Vec2i screen_size = new Vec2i(
            target.Width,
            target.Height
        );
        for (int i = 0; i < tris.Count; i += 3)
        {
            DrawLine(
                Vec2i.Vec3fToScreenPoint(tris[i], screen_size), 
                Vec2i.Vec3fToScreenPoint(tris[i+1], screen_size), 
                c
                );
            DrawLine(
                Vec2i.Vec3fToScreenPoint(tris[i], screen_size), 
                Vec2i.Vec3fToScreenPoint(tris[i+2], screen_size), 
                c
            );
            DrawLine(
                Vec2i.Vec3fToScreenPoint(tris[i+1], screen_size), 
                Vec2i.Vec3fToScreenPoint(tris[i+2], screen_size), 
                c
            );
        }
    }
    
    public void DrawTriangle(Vec2i p1, Vec2i p2, Vec2i p3)
    {
        
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