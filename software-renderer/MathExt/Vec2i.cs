namespace SoftwareRenderer.MathExt;
//vector of 2 integer values
public struct Vec2i(int x, int y)
{
    public int X = x;
    public int Y = y;

    static public Vec2i Vec3fToScreenPoint(Vec3f p, Vec2i screen_size)
    {
        int x = (int)(screen_size.X * p.X + screen_size.X)/2;
        int y = (int)(screen_size.Y * p.Y + screen_size.Y)/2;
        x = Math.Clamp(x, 0, screen_size.X - 1);
        y = Math.Clamp(y, 0, screen_size.Y - 1);
        return new Vec2i(x, y);
    }
    
    public override string ToString()
    {
        return $"Vec2i: ({X}; {Y})";
    }
}