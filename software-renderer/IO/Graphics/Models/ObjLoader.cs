using SoftwareRenderer.MathExt;

namespace SoftwareRenderer.IO.Graphics.Models;

public class ObjLoader
{
    public static List<Vec3f> GetLines(string path)
    {
        List<Vec3f> points = new List<Vec3f>();
        List<Vec3f> tris = new List<Vec3f>();
        foreach (string line in File.ReadLines(path))
        {
            string[] line_data = line.Split(' ');
            if (line_data[0].Equals("v"))
            {
                points.Add(
                        new Vec3f(
                            float.Parse(line_data[1]), 
                            float.Parse(line_data[2]), 
                            float.Parse(line_data[3])
                            )
                    );
            }

            if (line_data[0].Equals("f"))
            {
                int[] indices = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    indices[i] = int.Parse(line_data[i+1].Split('/')[0]);
                }
                tris.Add(points[indices[0] - 1]);
                tris.Add(points[indices[1] - 1]);
                tris.Add(points[indices[2] - 1]);
            }
        }
        return tris;
    }
}