using SoftwareRenderer.Assets;
using SoftwareRenderer.IO.Graphics.Images;
using SoftwareRenderer.MathExt;
using SoftwareRenderer.Render;

namespace SoftwareRenderer;

class Program
{
    private const int size = 500;
    private const int step = size / 10;
    static int imageWritten = 0;
    static TgaImageWriter writer = new TgaImageWriter();
    static void Main(string[] args)
    {
        Image img = new Image(size, size);
        Renderer renderer = new Renderer(img);
        
        for (int i = 0; i < size; i += step)
        {
            renderer.DrawLine(new Vec2i(0, 0), new Vec2i(i, size - 1), Color.CreateColor(255, 255, 255));
            DrawImage(ref img);
            
        } 
        renderer.DrawLine(new Vec2i(0, 0), new Vec2i(size - 1, size - 1), Color.CreateColor(255, 255, 255));
        DrawImage(ref img);
        for (int i = step; i < size; i += step)
        {
            renderer.DrawLine(new Vec2i(0, 0), new Vec2i(size - 1, size - 1 - i), Color.CreateColor(255, 255, 255));
            DrawImage(ref img);
        }
        renderer.DrawLine(new Vec2i(0, 0), new Vec2i(size - 1, 0), Color.CreateColor(255, 255, 255));
        DrawImage(ref img);
        
        int a = 10;
        int b = 15; 
    }

    static void DrawImage(ref Image img)
    {
        writer.WriteTrueColor($"./out/img{++imageWritten:D2}.tga", img);
        img.Clear(0);
    }
}