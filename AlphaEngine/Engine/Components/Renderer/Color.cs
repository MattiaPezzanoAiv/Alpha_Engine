using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace AlphaEngine
{
    public struct Color
    {

        public Color(Vector4 color)
        {
            r = color.X;
            g = color.Y;
            b = color.Z;
            a = color.W;
        }
        

        public float r;
        public float g;
        public float b;
        public float a;

        public Vector4 ToVector4()
        {
            return new Vector4(r, g, b, a);
        }

        public static Color Red { get; } = new Color(new Vector4(1,0,0,1));
    }
}
