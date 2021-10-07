using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaCamera
{
    public class Vector3
    {
        private int x;
        private int y;
        private int z;

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Vector3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Z
        {
            get { return z; }
            set { z = value; }
        }
    }
}
