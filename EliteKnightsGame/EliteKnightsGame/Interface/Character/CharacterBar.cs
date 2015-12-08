using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;
using Microsoft.Xna.Framework;
using EliteKnightsGame.Resources;

namespace EliteKnightsGame.Interface
{
    class CharacterBar
    {
        private int total;

        public CharacterBar(int total)
        {
            this.total = total;
        }

        public void Update(int total)
        {
            this.total = total;
        }

        public void Draw(int current, Vector2 position)
        {
            int width = BasicWindow.WidthBar * Porcentage(current) / 100;
            Rectangle rectangle = new Rectangle((int)position.X, (int)position.Y, width, BasicWindow.HeightBar);
            Canvas.DrawRectangle(rectangle, Color.Blue);

            DrawBar(current, position);
        }

        public void DrawDinamic(int current, Vector2 position)
        {
            int color = 255 * Porcentage(current) / 100;
            int width = BasicWindow.WidthBar * Porcentage(current) / 100;

            Rectangle rectangle = new Rectangle((int)position.X, (int)position.Y, width, BasicWindow.HeightBar);
            Canvas.DrawRectangle(rectangle, new Color(255 - color, color, 0));

            DrawBar(current, position);
        }

        private void DrawBar(int current, Vector2 position)
        {
            Rectangle rectangle = new Rectangle((int)position.X, (int)position.Y, BasicWindow.WidthBar, BasicWindow.HeightBar);
            Canvas.DrawBorder(BasicWindow.BorderLegth, rectangle, Color.Black);

            string text = current + " / " + total;
            GameLoop.DrawText(Fonts.Small, text, rectangle, Color.Black);
        }

        private int Porcentage(int current)
        {
            int porcentage = 0;
            
            if(total > 0)
                porcentage = 100 * current / total;

            return porcentage;
        }
    }
}
