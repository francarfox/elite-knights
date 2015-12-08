using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel.Scene
{
    public class Terrain : Stage
    {
        public Terrain()
            : base(Names.Terrain, Vector.Zero, General.TerrainWidth, General.TerrainWidth)
        { }
    }
}
