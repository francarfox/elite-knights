using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using EliteKnightsGame.Resources;

namespace EliteKnightsGame.Interface
{
    class TextBox
    {
        private string text;
        private Rectangle area;
        private bool selected;

        public TextBox(int posX, int posY)
        {
            text = "";
            area = new Rectangle(posX, posY, BasicWindow.TextBoxWidth, BasicWindow.TextBoxHeight);
        }

        public void Update()
        {
            MouseState mouse = Mouse.GetState();

            if (area.Contains(new Point(mouse.X, mouse.Y)) && mouse.LeftButton == ButtonState.Pressed)
            {
                text = "_";
                selected = true;
            }

            if (selected)
                ProcessKeys();
        }

        public void Draw()
        {
            Canvas.DrawRectangle(area, Color.White);
            Canvas.DrawBorder(1, area, Color.Gray);

            GameLoop.DrawText(Fonts.Arial, text, area, Color.Black);
        }

        private void ProcessKeys()
        {
            KeyboardState kState = Keyboard.GetState();
            Keys[] pressedKeys = kState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (GameLoop.OldKey.IsKeyUp(key))
                {
                    if (KeyboardGame.IsChar(key))
                    {
                        if (text.Length > 1)
                            text = text.Insert(text.Length - 1, key.ToString().ToLower());
                        else
                            text = text.Insert(text.Length - 1, key.ToString().ToUpper());
                    }

                    if (key == Keys.Back && text.Length > 1)
                        text = text.Remove(text.Length - 2, 1);

                    if (key == Keys.Space)
                        text = text.Insert(text.Length - 1, " ");

                    if (key == Keys.Enter)
                    {
                        text = text.Remove(text.Length - 1, 1);
                        selected = false;
                    }
                }
            }
        }

        public bool Selected()
        {
            return selected;
        }

        public string Text
        {
            get { return text; }
        }
    }
}
