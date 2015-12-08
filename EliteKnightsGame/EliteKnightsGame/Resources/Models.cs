using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace EliteKnightsGame.Resources
{
    abstract class Models
    {
        public static Model Terrain;
        public static Model House;
        public static Model Knight;
        public static Model Armor;

        public static void LoadContent(ContentManager Content)
        {
            Terrain = LoadModel(Content, "terrain");
            House = LoadModel(Content, "house");
            Knight = LoadModel(Content, "men");
            Armor = LoadModel(Content, "armor");
        }

        private static Model LoadModel(ContentManager content, string path)
        {
            return content.Load<Model>("Models\\" + path);
        }
    }
}
