using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using EliteKnightsGame.Resources;

namespace EliteKnightsGame.Interface
{
    abstract class DurationBar
    {
        private static Dictionary<Texture2D, int> durations = new Dictionary<Texture2D,int>();

        public static void Update(Texture2D image, int current)
        {
            durations[image] = current;

            if (current <= 0)
                durations.Remove(image);
        }

        public static void Draw()
        {
            for (int i = 0; i < durations.Count; i++)
            {
                Texture2D image = durations.Keys.ElementAt(i);
                int posX = BasicWindow.PositionXDurationBar + BasicWindow.ButtonSkillLade * i;
                string text = durations[image].ToString();

                GameLoop.Draw(image, new Vector2(posX, BasicWindow.PositionYDurationBar), Color.Gray);

                GameLoop.DrawText(Fonts.Arial, text, new Rectangle(posX, BasicWindow.PositionYDurationBar, image.Width, image.Height), Color.White);
            }
        }
    }
}
