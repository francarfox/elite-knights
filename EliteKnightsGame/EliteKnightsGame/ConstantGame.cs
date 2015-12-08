using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EliteKnightsGame
{
    abstract class ConstantGame
    {
        public static Vector3 CameraDistance = new Vector3(0, 4, 10);
        public static Vector3 MinBoundigBox = new Vector3(-1);
        public static Vector3 MaxBoundigBox = new Vector3(1);

        public static int MaxRanking = 20;
    }
}
