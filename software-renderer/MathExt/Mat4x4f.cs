namespace SoftwareRenderer.MathExt;

public struct Mat4x4f(float[] data)
{
    public float[] Data = data;

    public static Mat4x4f CreateIdentity()
    {
        float[] data = new float[16];
        data[0] = 1;
        data[5] = 1;
        data[10] = 1;
        data[15] = 1;
        return new Mat4x4f(data);
    }

    public void SetRotationY(float y)
    {
        Data[0] = MathF.Cos(y);
        Data[2] = MathF.Sin(y);
        Data[8] = -MathF.Sin(y);
        Data[10] = MathF.Cos(y);
    }

    public override string ToString()
    {
        return $"Mat4x4f:\n{{\n\t({data[0]}, {data[1]}, {data[2]}, {data[3]}),\n" +
               $"\t({data[4]}, {data[5]}, {data[6]}, {data[7]}),\n"+
               $"\t({data[8]}, {data[9]}, {data[10]}, {data[11]}),\n" +
               $"\t({data[12]}, {data[13]}, {data[14]}, {data[15]})\n}}";
    }
}