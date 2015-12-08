using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsGame.Resources;
using Microsoft.Xna.Framework.Graphics;
using EliteKnightsModel;
using EliteKnightsModel.Skills;
using EliteKnightsModel.Characters;
using Microsoft.Xna.Framework.Input;

namespace EliteKnightsGame.Interface
{
    class SkillsBar : IObserverSkillsList
    {
        private AttackCharacter personage;
        private IAttackCharacter enemy;
        private List<ButtonSkill> buttons;

        public SkillsBar(AttackCharacter personage)
        {
            this.personage = personage;
            personage.AddObserverSkill(this);
            buttons = new List<ButtonSkill>();

            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < General.CountSkillsMax; i++)
                buttons.Add(new ButtonSkill(i, BasicWindow.PositionXSkillBar + i * BasicWindow.ButtonSkillLade, BasicWindow.PositionYSkillBar, Images.None, ActivateSkill));

            for (int i = 0; i < General.CountSkillsMax; i++)
                personage.AddObserverSkill(i, buttons[i]);

            buttons[0].Key = KeyboardGame.Skill1;
            buttons[1].Key = KeyboardGame.Skill2;
            buttons[2].Key = KeyboardGame.Skill3;
            buttons[3].Key = KeyboardGame.Skill4;
            buttons[4].Key = KeyboardGame.Skill5;
            buttons[5].Key = KeyboardGame.Skill6;
            buttons[6].Key = KeyboardGame.Skill7;
            buttons[7].Key = KeyboardGame.Skill8;
            buttons[8].Key = KeyboardGame.Skill9;
            buttons[9].Key = KeyboardGame.Skill0;
        }

        public void Update()
        {
            foreach (ButtonSkill button in buttons)
                button.Update(enemy);
        }

        public void Draw()
        {
            foreach (ButtonSkill button in buttons)
                button.Draw();

            DurationBar.Draw();
        }

        public Personage Enemy
        {
            set { enemy = value; }
        }

        private void ActivateSkill(int index, IAttackCharacter enemy)
        {
            personage.ActivateSkill(index, enemy);
        }

        public void UpdateSkills(SkillsList skills)
        {
            for (int i = 0; i < General.CountSkillsMax; i++)
                buttons[i].SetSkill(skills.Skill(i), ActivateSkill);
        }
    }
}
