namespace SoftwareRenderer.MathExt;

public struct Vec3f(float x, float y, float z)
{
    public float X = x;
    public float Y = y;
    public float Z = z;
    public override string ToString()
    {
        return $"Vec3f: ({X}; {Y}; {Z})";
    }
}