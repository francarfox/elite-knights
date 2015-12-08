using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Simulator
{
    class Simulator6 : Simulator
    {
        public Simulator6(AttackCharacter character)
            : base(character)
        { }

        public override void SimulateAttack(IAttackCharacter target)
        {
            SimulateImmune(target);

            character.ActivateSkill(Names.Blindage, target);

            if (message == Messages.IsReload || message == Messages.NoEnergy)
            {
                character.ActivateSkill(Names.Courage, target);

                if (message == Messages.IsReload || message == Messages.NoEnergy)
                {
                    character.ActivateSkill(Names.Court, target);

                    if (message == Messages.NoNormal || message == Messages.NoNear || message == Messages.NoEnergy)
                    {
                        character.ActivateSkill(Names.Attack, target);

                        if (message == Messages.NoNormal || message == Messages.NoNear || message == Messages.NoEnergy)
                        {
                            character.ActivateSkill(Names.Meditation, target);

                            if (message == Messages.MaxEnergy)
                                character.ActivateSkill(Names.Ire, target);
                        }
                    }
                }
            }
        }
    }
}
