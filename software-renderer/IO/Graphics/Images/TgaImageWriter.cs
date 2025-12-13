using System.IO;
using SoftwareRenderer.Assets;
using SoftwareRenderer.Render;

namespace SoftwareRenderer.IO.Graphics.Images;

public class TgaImageWriter
{
    public void WriteTrueColor(string path, Image img)
    {
        using (var stream = File.OpenWrite(path))
        using (var writer = new BinaryWriter(stream))
        {
            WriteTrueColorHeader(writer, (short)img.Width, (short)img.Height);
            WriteTrueColorData(writer, img.Data);
        }
    }

    private void WriteTrueColorHeader(BinaryWriter writer, short width, short height)
    {
        writer.Write((byte)0);//ID
        writer.Write((byte)0);//Color map
        writer.Write((byte)2);//Color mode
        //Color map zeroing
        writer.Write((short)0);
        writer.Write((short)0);
        writer.Write((byte)0);
        //Image desc
        writer.Write((short)0);//XOrigin
        writer.Write((short)0);//YOrigin
        writer.Write(width);//X
        writer.Write(height);//Y
        
        writer.Write((byte)24);//Pixel depth
        writer.Write((byte)0);//Image Descriptor
    }

    private void WriteTrueColorData(BinaryWriter writer, int[] data)
    {
        foreach (int pixel in data)
        {
            writer.Write((byte)((pixel >> Color.B_SHIFT) & Color.MASK));
            writer.Write((byte)((pixel >> Color.G_SHIFT) & Color.MASK));
            writer.Write((byte)((pixel >> Color.R_SHIFT) & Color.MASK));
        }
    }
}