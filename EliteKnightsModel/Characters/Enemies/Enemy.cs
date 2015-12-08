using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Skills;
using EliteKnightsModel.Boots;

namespace EliteKnightsModel.Characters
{
    class Enemy : AttackCharacter
    {
        public Enemy(string name, Vector position, int level)
            : base(name, position, level)
        {
            SkillsBoot.LoadSkillsEnemy(this, skills);
        }

        public override void ActivateSkill(int index, IAttackCharacter enemy)
        {
            skills.ActivateSkill(0, enemy); //Add intelligence
        }

        public override void ActivateSkill(string name, IAttackCharacter enemy)
        {
            throw new NotImplementedException();    //Add intelligence
        }

        public override int CalculateHealth()
        {
            throw new NotImplementedException();
        }

        public override int CalculateEnergy()
        {
            throw new NotImplementedException();
        }

        public override bool ChanceResistance(ISkill skill, IAttackCharacter character)
        {
            throw new NotImplementedException();
        }

        protected override int Damage
        {
            get { throw new NotImplementedException(); }
        }

        protected override int Armor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        protected override int Resistance
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        protected override int Force
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        protected override float Critical
        {
            get { throw new NotImplementedException(); }
        }

        protected override int BonusValue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        protected override float SpeedyReload
        {
            get { throw new NotImplementedException(); }
        }
    }
}
