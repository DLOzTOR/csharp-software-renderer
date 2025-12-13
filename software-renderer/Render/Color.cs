namespace SoftwareRenderer.Render;

public static class Color
{

    public const byte R_SHIFT = 16;
    public const byte G_SHIFT = 8;
    public const byte B_SHIFT = 0;
    public const uint MASK = 0xFF;
    
    public static int CreateColor(byte red, byte green, byte blue)
    {
        return (red << R_SHIFT) | (green << G_SHIFT) | (blue << B_SHIFT);
    }

    public static byte GetRed(int color)
    {
        return (byte)((color >> R_SHIFT) & MASK);
    }

    public static byte GetGreen(int color)
    {
        return (byte)((color >> G_SHIFT) & MASK);
    }
    public static byte GetBlue(int color)
    {
        return (byte)((color >> B_SHIFT) & MASK);
    }
}