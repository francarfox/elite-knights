using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public class Ire : DefensiveSkill
    {
        //+20 de valor, aumenta chance de critico
        private int bonusValue;

        public Ire(IAttackCharacter character)
            : base(character, Names.Ire, 110)
        {
            bonusValue = 20;
        }

        public override void Activate(IAttackCharacter enemy)
        {
            if (!IsReload())
                character.ActivateIre(this);
        }

        //Desactivate in first attack

        public int BonusValue
        {
            get { return bonusValue; }
        }
    }
}
