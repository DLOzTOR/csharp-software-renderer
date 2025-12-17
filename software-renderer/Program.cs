using System.Diagnostics;
using SoftwareRenderer.Assets;
using SoftwareRenderer.IO.Graphics.Images;
using SoftwareRenderer.IO.Graphics.Models;
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
        ObjLoaderTest();
    }

    static void ObjLoaderTest()
    {
        Image img = new Image(size, size);
        Renderer renderer = new Renderer(img);
        List<Vec3f> model = ObjLoader.GetLines("Resources/Models/monkey.obj");
        Mat4x4f transform = Mat4x4f.CreateIdentity();
        for (int i = 0; i < 60; i++)
        {
            renderer.DrawWiredModel(model, transform);
            transform.SetRotationY(MathF.PI * i /30);
            DrawImage(ref img);
        }
    }
    
    static void SomeTests()
    {
        Image img = new Image(size, size);
        Renderer renderer = new Renderer(img);
        // for (int i = 0; i < size; i += step)
        // {
        //     renderer.DrawLine(new Vec2i(0, 0), new Vec2i(100, size - step - i), Color.CreateColor(255, 255, 255));
        //     DrawImage(ref img);
        // } 
        //
        // for (int i = 0; i < size; i += step)
        // {
        //     renderer.DrawLine(new Vec2i(0, 0), new Vec2i(i, 100), Color.CreateColor(255, 255, 255));
        //     DrawImage(ref img);
        // } 
        
        var stopWatch = Stopwatch.StartNew();
        Vec2i v1 = new Vec2i(0, 0);
        Vec2i v2 = new Vec2i(size - 1, 0);
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