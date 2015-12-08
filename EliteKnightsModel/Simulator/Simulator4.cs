using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Simulator
{
    class Simulator4 : Simulator3
    {
        public Simulator4(AttackCharacter character)
            : base(character)
        { }

        public override void SimulateAttack(IAttackCharacter target)
        {
            if (character.Health < character.CalculateHealth() / 2)
            {
                character.ActivateSkill(Names.Immune, target);

                if (message == Messages.IsReload || message == Messages.NoEnergy)
                {
                    character.ActivateSkill(Names.Meditation, target);
                }
            }

            base.SimulateAttack(target);
        }
    }
}
