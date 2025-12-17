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

    public void Clear(int color)
    {
        int size = Width * Height;
        for (int i = 0; i < size; i++)
        {
            Data[i] = color;
        }
    }
}