using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;
using EliteKnightsModel.Exceptions;

namespace EliteKnightsModel.Skills
{
    public abstract class OffensiveSkill : Skill
    {
        public OffensiveSkill(IAttackCharacter character, string name, int cost)
            : base(character, name, cost)
        { }

        public override void Activate(IAttackCharacter enemy)
        {
            if (enemy == null)
            {
                NotifyMessageOther("No tiene objetivo");
                throw new EnemyNullException();
            }
        }

        public override void Reset()
        {
            character.DesactivateIre();

            base.Reset();
        }
    }
}
