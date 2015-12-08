using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using EliteKnightsGame.Resources;
using EliteKnightsGame.Screens;

namespace EliteKnightsGame.Interface
{
    delegate void Function();

    class ButtonOption
    {
        private Rectangle area;
        private string text;
        private Function function;
        private bool selected;

        public ButtonOption(int posX, int posY, string text, Function function)
        {
            area = new Rectangle(posX, posY, BasicWindow.ButtonOptionWidth, BasicWindow.ButtonOptionHeight);
            this.text = text;
            this.function = function;
        }

        public void Update()
        {
            MouseState mouse = Mouse.GetState();

            selected = area.Contains(new Point(mouse.X, mouse.Y));

            if (selected && MouseClick(mouse))
            {
                //Sounds.Button.CreateInstance().Play();
                function();
            }
        }

        public void Draw()
        {
            Color color = Color.Gray;

            if (selected)
                color = Color.White;

            GameLoop.Draw(Images.ButtonImage, area, color);
            GameLoop.DrawText(Fonts.Arial, text, area, Color.White);
        }

        private bool MouseClick(MouseState mouse)
        {
            bool click = false;

            if (mouse.LeftButton == ButtonState.Pressed && GameLoop.OldMouse.LeftButton == ButtonState.Released)
                click = true;

            return click;
        }
    }
}
