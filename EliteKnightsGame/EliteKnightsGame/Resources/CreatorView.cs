using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsGame.Entities;
using EliteKnightsModel;
using EliteKnightsModel.Characters;
using EliteKnightsModel.Scene;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EliteKnightsGame.Resources
{
    abstract class CreatorView
    {
        public static IEntityView View(IEntity entity)
        {
            IEntityView view = null;

            if (entity is Knight)
                view = new PersonageView(Models.Knight, (Knight)entity);
            else
                if (entity is Terrain)
                    view = new TerrainView((Terrain)entity);
                else
                    if (entity is House)
                        view = new HouseView((House)entity);

            return view;
        }
    }
}
