using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EliteKnightsGame.Resources;
using EliteKnightsModel;
using EliteKnightsModel.Characters;

namespace EliteKnightsGame.Interface
{
    class StatisticCharacter
    {
        private AttackCharacter character;
        private CharacterBar healthBar, energyBar;

        public StatisticCharacter(AttackCharacter character)
        {
            this.character = character;
            healthBar = new CharacterBar(character.CalculateHealth());
            energyBar = new CharacterBar(character.CalculateEnergy());
        }

        public void Update()
        {
            character.Update();
            healthBar.Update(character.CalculateHealth());
            energyBar.Update(character.CalculateEnergy());
        }

        public void Draw(int positionX)
        {
            string text = character.Level + " " + character.Name;
            GameLoop.DrawText(Fonts.Arial, text, new Vector2(positionX, BasicWindow.PositionYName), Color.White);

            healthBar.DrawDinamic(character.Health, new Vector2(positionX, BasicWindow.PositionYHealthBar));
            energyBar.Draw(character.Energy, new Vector2(positionX, BasicWindow.PositionYEnergyBar));
        }
    }
}
