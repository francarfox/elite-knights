using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Scene;
using Microsoft.Xna.Framework;
using EliteKnightsGame.Resources;

namespace EliteKnightsGame.Entities
{
    class HouseView : EntityView
    {
        private House house;

        public HouseView(House house)
            : base(Models.House, new Vector3(house.Position.X, house.Position.Z + (2.58f * 2), house.Position.Y), new Vector3(0.01f * 2))
        {
            this.house = house;
        }
    }
}
