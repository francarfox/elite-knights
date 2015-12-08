using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public class Cholera : DefensiveSkill
    {
        //50% de resistencia
        private int bonusResistance;

        public Cholera(IAttackCharacter character)
            : base(character, Names.Cholera, 400, 40, 15)
        {
            bonusResistance = General.ProbabilityResistance / 2;
        }

        public override void Activate(IAttackCharacter enemy)
        {
            if (!IsReload())
                character.ActivateCholera(this);
        }

        protected override void Desactivate()
        {
            character.DesactivateCholera();

            base.Desactivate();
        }

        public int BonusResistance
        {
            get { return bonusResistance; }
        }
    }
}
