using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Simulator
{
    class Simulator8 : Simulator7
    {
        public Simulator8(AttackCharacter character)
            : base(character)
        { }

        public override void SimulateAttack(IAttackCharacter target)
        {
            if (character.IsNear(target))
                character.ActivateSkill(Names.Cholera, target);

            base.SimulateAttack(target);
        }
    }
}
