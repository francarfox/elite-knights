using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public class Immune : DefensiveSkill
    {
        //No puede atacar ni ser atacado
        public Immune(IAttackCharacter character)
            : base(character, Names.Immune, 250, 15, 4)
        { }

        public override void Activate(IAttackCharacter enemy)
        {
            if (!IsReload())
                character.ActivateImmune(this);
        }

        protected override void Desactivate()
        {
            character.DesactivateImmune();

            base.Desactivate();
        }
    }
}
