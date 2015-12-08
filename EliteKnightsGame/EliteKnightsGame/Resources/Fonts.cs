using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EliteKnightsGame.Resources
{
    abstract class Fonts
    {
        public static SpriteFont Arial;
        public static SpriteFont Small;

        public static void LoadContent(ContentManager Content)
        {
            Arial = LoadFont(Content, "arial");
            Small = LoadFont(Content, "small");
        }

        private static SpriteFont LoadFont(ContentManager content, string path)
        {
            return content.Load<SpriteFont>("Fonts\\" + path);
        }
    }
}
