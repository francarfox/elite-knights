using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Items;
using EliteKnightsModel.Skills;

namespace EliteKnightsModel.Characters
{
    public abstract class Personage : AttackCharacter, IComparable<Personage>
    {
        private int force, valor, temper, speedy;
        private int bonusForce, bonusValue, bonusArmor, bonusResistance;

        private int battlesWon, battlesPlay;
        private long totalExperience, goldCoins;
        protected ItemsList items;
        protected Equipment equipment;

        public Personage(string name, Vector position, int level, int battlesWon, int battlesPlay)
            : base(name, position, level)
        {
            force = level;
            valor = level;
            temper = level;
            speedy = level;

            health = CalculateHealth();
            energy = CalculateEnergy();

            this.battlesWon = battlesWon;
            this.battlesPlay = battlesPlay;

            items = new ItemsList();
            equipment = new Equipment(this, items); //interface
        }

        public override void ActivateSkill(int index, IAttackCharacter enemy)
        {
            if (attack)
            {
                skills.ActivateSkill(index, enemy);
                attack = false;
            }
        }

        public override void ActivateSkill(string name, IAttackCharacter enemy)   //for enemy
        {
            skills.ActivateSkill(name, enemy);
            attack = false;
        }

        public override int CalculateHealth()
        {
            return (500 + temper * 2500 / General.LevelMax);
        }

        public override int CalculateEnergy()
        {
            return (200 + temper * 1500 / General.LevelMax);
        }

        protected override int Force
        {
            get { return (force + bonusForce); }
            set { bonusForce = value; }
        }

        public override bool ChanceResistance(ISkill skill, IAttackCharacter character)
        {
            bool chance = false;
            int probability = General.Infinity;

            if(Resistance > 0)
                probability = General.ProbabilityResistance / Resistance;

            if (Aleatory() % probability == 0)
            {
                chance = true;
                string message = character.Name + "->" + skill.Name + "(" + skill.Level + ") Resistido!";
                NotifyMessageDamage(message);
                character.NotifyMessageSkill(message);
            }

            return chance;
        }

        protected override int Damage
        {
            get { return (int)(Force * 5 + 100 + equipment.Damage); }
        }

        protected override int Armor
        {
            get { return (equipment.Armor + bonusArmor); }
            set { bonusArmor = value; }
        }

        protected override int Resistance
        {
            get { return (temper + equipment.Resistance + bonusResistance); }   //10%
            set { bonusResistance = value; }
        }

        protected override float Critical
        {
            get { return valor + bonusValue; }  //20%
        }

        //Value

        protected override int BonusValue
        {
            get { return bonusValue; }
            set { bonusValue = value; }
        }

        protected override float SpeedyReload
        {
            get { return (speedy * 0.3f); }
        }

        //public long ExperienceNecessary()
        //{
        //    long experience = 0;

        //    for (int i = 1; i <= level; i++)
        //        experience = experience + 100 * i;
        //    return experience;
        //}

        //public float ExperiencePercentage()
        //{
        //    long experience = ExperienceNecessary() - 100 * level;
        //    return (100 * (totalExperience - experience) / (ExperienceNecessary() - experience));
        //}

        //public void LevelUp()
        //{
        //    if (level < General.LevelKnightMax)
        //        if (totalExperience >= ExperienceNecessary())
        //        {
        //            level++;
        //            force++;
        //            value++;
        //            temper++;
        //            speedy++;
        //            health = CalculateHealth();
        //            energy = CalculateEnergy();
        //        }
        //}

        //for persistence
        public int BattlesWon
        {
            get { return battlesWon; }
        }

        public int BattlesPlay
        {
            get { return battlesPlay; }
        }

        public long Experience
        {
            get { return totalExperience; }
            set { totalExperience = value; }
        }

        public long Coins
        {
            get { return goldCoins; }
            set { goldCoins = value; }
        }

        //for ranking
        public float Status
        {
            get
            {
                float status = 0;

                if (battlesPlay > 0)
                    status = 100 * battlesWon / battlesPlay;

                return status;
            }
        }

        public int CompareTo(Personage personage)
        {
            int compare = (personage.Level - level) * 1000;
            compare += (int)(personage.Status - Status) * 10;

            return compare;
        }
    }
}
