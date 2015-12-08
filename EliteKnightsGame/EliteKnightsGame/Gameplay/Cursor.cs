using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using EliteKnightsGame.Resources;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace EliteKnightsGame.Gameplay
{
    class Cursor
    {
        private static Cursor cursor = null;

        private Texture2D image;
        private Vector2 position;

        private Cursor()
        {
            image = Images.Cursor;
        }

        public void Update()
        {
            MouseState mouse = Mouse.GetState();

            position.X = mouse.X;
            position.Y = mouse.Y;
        }

        public void Draw()
        {
            GameLoop.Draw(image, position, Color.White);
        }

        public static Cursor Instance
        {
            get 
            {
                if (cursor == null)
                    cursor = new Cursor();

                return cursor;
            }
        }
    }
}
