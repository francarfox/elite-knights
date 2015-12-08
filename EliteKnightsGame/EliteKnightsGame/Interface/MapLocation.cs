using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel;
using Microsoft.Xna.Framework.Graphics;
using EliteKnightsGame.Resources;
using Microsoft.Xna.Framework;

namespace EliteKnightsGame.Interface
{
    class MapLocation
    {
        //private IPositionable character;
        private Texture2D image;

        public MapLocation(IPositionable character)
        {
            //this.character = character;
            image = Images.Map;
        }

        public void Draw()
        {
            Rectangle rectangle = new Rectangle(BasicWindow.PositionXMap, BasicWindow.PositionYMap, BasicWindow.MapLegth, BasicWindow.MapLegth);

            GameLoop.Draw(image, rectangle, Color.White);
        }
    }
}
