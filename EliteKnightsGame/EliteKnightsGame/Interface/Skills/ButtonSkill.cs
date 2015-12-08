using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EliteKnightsGame.Resources;
using EliteKnightsModel.Skills;
using EliteKnightsModel;

namespace EliteKnightsGame.Interface
{
    public delegate void FunctionSkill(int index, IAttackCharacter enemy);

    class ButtonSkill : IObserverSkill
    {
        private int id;
        private Texture2D image;
        private Rectangle area;
        private FunctionSkill function;
        private Keys key;
        private bool selected;

        private int currentReload, currentDuration;

        public ButtonSkill(int id, int posX, int posY, Texture2D image, FunctionSkill function)
        {
            this.id = id;
            this.image = image;
            area = new Rectangle(posX, posY, BasicWindow.ButtonSkillLade, BasicWindow.ButtonSkillLade);
            this.function = function;
        }

        public void Update(IAttackCharacter enemy)
        {
            MouseState mouse = Mouse.GetState();
            KeyboardState kState = Keyboard.GetState();

            selected = area.Contains(new Point(mouse.X, mouse.Y));
            if(kState.IsKeyDown(key))
                selected = true;

            if (selected && mouse.LeftButton == ButtonState.Pressed || kState.IsKeyDown(key))
                function(id, enemy);

            if (currentDuration >= 0)
                DurationBar.Update(image, currentDuration);
        }

        public void Draw()
        {
            Color color = Color.White;

            if (selected)
                color = Color.Green;
            if (currentReload > 0)
                color = Color.Brown;

            GameLoop.Draw(image, area, color);

            if (currentReload > 0)
                GameLoop.DrawText(Fonts.Arial, currentReload.ToString(), area, Color.White);
        }

        public void SetSkill(ISkill skill, FunctionSkill function)
        {
            image = CreatorImageSkill.View(skill);
            this.function = function;
        }

        public Keys Key
        {
            set { key = value; }
        }

        public void UpdateCurrentReload(int current)
        {
            currentReload = current;
        }

        public void UpdateCurrentDuration(int current)
        {
            currentDuration = current;
        }
    }
}
