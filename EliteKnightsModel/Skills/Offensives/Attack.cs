using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public class Attack : OffensiveSkill
    {
        //Ataque normal
        public Attack(IAttackCharacter character)
            : base(character, Names.Attack, 100)
        { }

        public override void Activate(IAttackCharacter enemy)
        {
            try
            {
                base.Activate(enemy);

                if (!IsReload())
                    character.ActivateAttack(this, enemy);
            }
            catch { }
        }
    }
}
