using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public class Courage : DefensiveSkill
    {
        //50% bonus de fuerza
        private int bonusForce;

        public Courage(IAttackCharacter character)
            : base(character, Names.Courage, 150, 30, 20)
        {
            bonusForce = 50;
        }

        public override void Activate(IAttackCharacter enemy)
        {
            if (!IsReload())
                character.ActivateCourage(this);
        }

        protected override void Desactivate()
        {
            character.DesactivateCourage();

            base.Desactivate();
        }

        public int BonusForce
        {
            get { return bonusForce; }
        }
    }
}
