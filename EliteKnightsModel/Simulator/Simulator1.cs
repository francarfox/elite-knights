using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Simulator
{
    class Simulator1 : Simulator
    {
        public Simulator1(AttackCharacter character)
            : base(character)
        { }

        public override void SimulateAttack(IAttackCharacter target)
        {
            character.ActivateSkill(Names.Courage, target);

            if (message == Messages.IsReload || message == Messages.NoEnergy)
            {
                character.ActivateSkill(Names.Attack, target);

                if (message == Messages.NoNormal || message == Messages.NoNear || message == Messages.NoEnergy)
                    character.ActivateSkill(Names.Meditation, target);
            }
        }
    }
}
