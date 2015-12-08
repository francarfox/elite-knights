using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public abstract class DefensiveSkill : Skill
    {
        public DefensiveSkill(IAttackCharacter character, string name, int cost, int reload, int duration)
            : base(character, name, cost, reload, duration)
        { }

        public DefensiveSkill(IAttackCharacter character, string name, int cost, int reload)
            : this(character, name, cost, reload, 0)
        { }

        public DefensiveSkill(IAttackCharacter character, string name, int cost)
            : this(character, name, cost, 0)
        { }

        public override abstract void Activate(IAttackCharacter enemy);
    }
}
