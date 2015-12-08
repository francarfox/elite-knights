using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Simulator
{
    class Simulator2 : Simulator1
    {
        public Simulator2(AttackCharacter character)
            : base(character)
        { }

        public override void SimulateAttack(IAttackCharacter target)
        {
            character.ActivateSkill(Names.Blindage, target);

            if (message == Messages.IsReload || message == Messages.NoEnergy)
                base.SimulateAttack(target);
        }
    }
}
