using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel
{
    public abstract class Direction
    {
        public static Vector None = Vector.Zero;
        public static Vector Up = new Vector(0, 1);
        public static Vector Down = new Vector(0, -1);
        public static Vector Right = new Vector(-1, 0);
        public static Vector Left = new Vector(1, 0);

        public static float GireRight = 1;
        public static float GireLeft = -1;
    }
}
