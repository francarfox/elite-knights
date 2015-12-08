using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public class Blindage : DefensiveSkill
    {
        //50% bonus de armadura
        private int bonusArmor;

        public Blindage(IAttackCharacter character)
            : base(character, Names.Blindage, 150, 35, 25)
        {
            bonusArmor = 50;
        }

        public override void Activate(IAttackCharacter enemy)
        {
            if (!IsReload())
                character.ActivateBlindage(this);
        }

        protected override void Desactivate()
        {
            character.DesactivateBlindage();

            base.Desactivate();
        }

        public int BonusArmor
        {
            get { return bonusArmor; }
        }
    }
}
