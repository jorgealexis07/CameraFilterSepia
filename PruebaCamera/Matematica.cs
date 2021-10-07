using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PruebaCamera
{
    public class Matematica
    {
        public static float Distancia(Vector3 v1, Vector3 v2)
        {
            double t;
            float d;
            t = (Math.Pow(v2.X - v1.X, 2) + Math.Pow(v2.Y - v1.Y, 2) + Math.Pow(v2.Z - v1.Z, 2));
            d = (float)Math.Sqrt(t);
            return d;
        }

        public static Vector3 ColorAVector3(Color c)
        {
            return new Vector3(c.R, c.G, c.B);
        }

        public static Color Vector3AColor(Vector3 v)
        {
            return Color.FromArgb(v.X, v.Y, v.Z);
        }

    }
}
