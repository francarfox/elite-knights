using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public class NoneSkill : Skill
    {
        public NoneSkill()
            : base(null, "", 0)
        { }

        public override void Activate(IAttackCharacter enemy)
        { }
    }
}
