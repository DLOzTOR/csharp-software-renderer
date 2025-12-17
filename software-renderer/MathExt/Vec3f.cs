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

    public Vec3f multMat(Mat4x4f m)
    {
        float ox = X;
        float oy = Y;
        float oz = Z;
        X = ox * m.Data[0] + oy * m.Data[1] + oz * m.Data[2] + m.Data[3];
        Y = ox * m.Data[4] + oy * m.Data[5] + oz * m.Data[6] + m.Data[7];
        Z = ox * m.Data[8] + oy * m.Data[9] + oz * m.Data[10] + m.Data[11];
        return this;
    }
}