using SoftwareRenderer.Assets;
using SoftwareRenderer.IO.Graphics.Images;
using SoftwareRenderer.MathExt;
using SoftwareRenderer.Render;

namespace SoftwareRenderer;

class Program
{
    static void Main(string[] args)
    {
        Image img = new Image(100, 100);
        Renderer renderer = new Renderer(img);
        renderer.DrawLine(new Vector2i(0,50), new Vector2i(99,0), Color.CreateColor(255, 255, 255));
        renderer.DrawLine(new Vector2i(50,99), new Vector2i(0,0), Color.CreateColor(255, 255, 255));
        var writer = new TgaImageWriter();
        writer.WriteTrueColor("./img.tga", img);
    }
}