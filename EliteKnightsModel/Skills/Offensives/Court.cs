using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public class Court : OffensiveSkill
    {
        //Ataque normal +200 y reduce enegia en 200
        private int bonusDamage;

        public Court(IAttackCharacter character)
            : base(character, Names.Court, 250)
        {
            bonusDamage = 200;
        }

        public override void Activate(IAttackCharacter enemy)
        {
            try
            {
                base.Activate(enemy);

                if (!IsReload())
                    character.ActivateCourt(this, enemy);
            }
            catch { }
        }

        public int BonusDamage
        {
            get { return bonusDamage; }
        }
    }
}
