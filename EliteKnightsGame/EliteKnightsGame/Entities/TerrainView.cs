using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsGame.Resources;
using EliteKnightsModel.Scene;
using Microsoft.Xna.Framework;

namespace EliteKnightsGame.Entities
{
    class TerrainView : EntityView
    {
        private Terrain terrain;

        public TerrainView(Terrain terrain)
            : base(Models.Terrain, new Vector3(terrain.Position.X, terrain.Position.Z, terrain.Position.Y), new Vector3(terrain.Width))
        {
            this.terrain = terrain;
        }

        public override bool IsSelected()
        {
            return false;
        }
    }
}
