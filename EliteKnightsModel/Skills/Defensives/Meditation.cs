using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public class Meditation : DefensiveSkill
    {
        //Recupera 300 de energia
        private int bonusEnergy;

        public Meditation(IAttackCharacter character)
            : base(character, Names.Meditation, 0)
        {
            bonusEnergy = 300;
        }

        public override void Activate(IAttackCharacter enemy)
        {
            if (!IsReload())
                character.ActivateMeditation(this);
        }

        public int BonusEnergy
        {
            get { return bonusEnergy; }
        }
    }
}
