using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public class Winged : DefensiveSkill
    {
        //Recupera 1000 de salud
        private int bonusHealth;

        public Winged(IAttackCharacter character)
            : base(character, Names.Winged, 250, 20)
        {
            bonusHealth = 1000;
        }

        public override void Activate(IAttackCharacter enemy)
        {
            if (!IsReload())
                character.ActivateWinged(this);
        }

        public int BonusHealth
        {
            get { return bonusHealth; }
        }
    }
}
