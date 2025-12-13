namespace SoftwareRenderer.Assets;

public struct Image
{
    public int[] Data;
    public int Width;
    public int Height;

    public Image(int width, int height)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(width, 0);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(height, 0);
        Width = width;
        Height = height;
        Data = new int[width * height];
    }
}