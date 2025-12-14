using System.Diagnostics;
using SoftwareRenderer.Assets;
using SoftwareRenderer.IO.Graphics.Images;
using SoftwareRenderer.MathExt;
using SoftwareRenderer.Render;

namespace SoftwareRenderer;

class Program
{
    private const int size = 1500;
    private const int step = size / 10;
    static int imageWritten = 0;
    static TgaImageWriter writer = new TgaImageWriter();
    static void Main(string[] args)
    {
        Image img = new Image(size, size);
        Renderer renderer = new Renderer(img);

        // for (int i = 0; i < size; i += step)
        // {
        //     renderer.DrawLine(new Vec2i(0, 0), new Vec2i(i, size - 1), Color.CreateColor(255, 255, 255));
        //     DrawImage(ref img);
        //     
        // } 
        // renderer.DrawLine(new Vec2i(0, 0), new Vec2i(size - 1, size - 1), Color.CreateColor(255, 255, 255));
        // DrawImage(ref img);
        // for (int i = step; i < size; i += step)
        // {
        //     renderer.DrawLine(new Vec2i(0, 0), new Vec2i(size - 1, size - 1 - i), Color.CreateColor(255, 255, 255));
        //     DrawImage(ref img);
        // }
        // renderer.DrawLine(new Vec2i(0, 0), new Vec2i(size - 1, 0), Color.CreateColor(255, 255, 255));
        // DrawImage(ref img);
        var stopWatch = Stopwatch.StartNew();
        Vec2i v1 = new Vec2i(0, 0);
        Vec2i v2 = new Vec2i(size - 1, size - 1);
        int color = Color.CreateColor(255, 255, 255);
        for (int i = 0; i < 1000000; i++)
        {
            renderer.DrawLine(v1, v2, color);
        }
        stopWatch.Stop();

        Console.WriteLine($"{stopWatch.ElapsedMilliseconds} ms");
    }

    static void DrawImage(ref Image img)
    {
        writer.WriteTrueColor($"./out/img{++imageWritten:D2}.tga", img);
        img.Clear(0);
    }
}