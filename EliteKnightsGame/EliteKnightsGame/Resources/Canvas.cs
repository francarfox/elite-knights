using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EliteKnightsGame.Resources
{
    class Canvas
    {
        private static Texture2D canvas;

        public static void Initialize()
        {
            Color[] tempData = new Color[1];
            tempData[0] = Color.White;

            canvas = new Texture2D(GameLoop.Device, 1, 1);
            canvas.SetData(tempData);
        }

        public static void DrawPixel(Vector2 position, Color color)
        {
            GameLoop.Draw(canvas, position, color);
        }

        public static void DrawRectangle(Rectangle rectangle, Color color)
        {
            GameLoop.Draw(canvas, rectangle, color);
        }

        public static void DrawBorder(int borderLength, Rectangle rectangle, Color color)
        {
            for (int x = 0; x < rectangle.Width; x++)
            {
                for (int y = 0; y < rectangle.Height; y++)
                {
                    if (x < borderLength || y < borderLength)
                        DrawPixel(new Vector2(x + rectangle.X, y + rectangle.Y), color);

                    if (x >= rectangle.Width - borderLength || y >= rectangle.Height - borderLength)
                        DrawPixel(new Vector2(x + rectangle.X, y + rectangle.Y), color);
                }
            }
        }
    }
}
