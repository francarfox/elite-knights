using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Skills;

namespace EliteKnightsModel.Characters
{
    public abstract class AttackCharacter : Character, IAttackCharacter
    {
        protected int level;
        protected int health, energy;
        protected State state;
        protected SkillsList skills;

        protected bool attack;
        private Time speedyReload, second;

        private List<IObserverMessage> observers;

        public AttackCharacter(string name, Vector position, int level)
            : base(name, position)
        {
            this.level = level;
            state = State.Normal;
            skills = new SkillsList();

            speedyReload = new Time();
            second = new Time();

            observers = new List<IObserverMessage>();
        }

        public abstract void ActivateSkill(int index, IAttackCharacter enemy);

        public abstract void ActivateSkill(string name, IAttackCharacter enemy);  //for enemy

        public override void Update()
        {
            base.Update();

            IsLiving();
            ReloadSkills();

            if (!attack && state != State.Death)
                GlobalReload();
        }

        private void IsLiving()
        {
            if (health <= 0)
            {
                health = 0;
                move = false;
                state = State.Death;
            }
        }

        private void GlobalReload()
        {
            if (speedyReload.Completed())
                attack = true;
            else
                speedyReload.Sleep(General.Second - (int)SpeedyReload);
        }

        private void ReloadSkills()
        {
            if (second.Completed())
                skills.Reload();
            else
                second.Sleep();
        }

        public abstract int CalculateHealth();

        public abstract int CalculateEnergy();

        #region IApplicableSkill

        public void ActivateAttack(Attack skill, IAttackCharacter enemy)
        {
            if (IsNormal(this) && IsNear(enemy) && enemy.IsNormal(this) && SufficientEnergy(skill))
            {
                if (!enemy.ChanceResistance(skill, this))
                    if (ChanceCritical())
                        enemy.DebilityCritical(Damage, skill, this);
                    else
                        enemy.Debility(Damage, skill, this);

                skill.Reset();
            }
        }

        public void ActivateMeditation(Meditation skill)
        {
            if (!EnergyMaximum())
            {
                energy += skill.BonusEnergy;

                if (energy > CalculateEnergy())
                    energy = CalculateEnergy();

                LogSkill(skill);
            }
        }

        public void ActivateCourt(Court skill, IAttackCharacter enemy)
        {
            if (IsNormal(this) && IsNear(enemy) && enemy.IsNormal(this) && SufficientEnergy(skill))
            {
                if (!enemy.ChanceResistance(skill, this))
                {
                    if (ChanceCritical())
                        enemy.DebilityCritical(Damage + skill.BonusDamage, skill, this);
                    else
                        enemy.Debility(Damage + skill.BonusDamage, skill, this);

                    enemy.DebilityEnergy(skill.BonusDamage);
                }

                skill.Reset();
            }
        }

        public void ActivateImmune(Immune skill)
        {
            if (SufficientEnergy(skill))
            {
                state = State.Immune;
                move = false;

                LogSkill(skill);
            }
        }

        public void ActivateCourage(Courage skill)
        {
            if (SufficientEnergy(skill))
            {
                Force = skill.BonusForce;

                LogSkill(skill);
            }
        }

        public void ActivateBlindage(Blindage skill)
        {
            if (IsArmor() && SufficientEnergy(skill))
            {
                Armor += skill.BonusArmor;

                LogSkill(skill);
            }
        }

        public void ActivateWinged(Winged skill)
        {
            if (!HealthMaximum() && SufficientEnergy(skill))
            {
                health += skill.BonusHealth;
                if (health > CalculateHealth())
                    health = CalculateHealth();

                LogSkill(skill);
            }
        }

        public void ActivateFury(Fury skill, IAttackCharacter enemy)
        {
            if (IsNormal(this) && IsNear(enemy) && enemy.IsNormal(this) && SufficientEnergy(skill))
            {
                if(!enemy.ChanceResistance(skill, this))
                    if (ChanceCritical())
                        enemy.DebilityCritical(skill.DamageFury(Damage), skill, this);
                    else
                        enemy.Debility(skill.DamageFury(Damage), skill, this);

                skill.Reset();
            }
        }

        public void ActivateIre(Ire skill)
        {
            if (!ChanceCriticalMaximum() && SufficientEnergy(skill))
            {
                BonusValue += skill.BonusValue;

                LogSkill(skill);
            }
        }

        public void ActivateCholera(Cholera skill)
        {
            if (SufficientEnergy(skill))
            {
                Resistance = skill.BonusResistance - Resistance;    //50%

                LogSkill(skill);
            }
        }

        public void DesactivateImmune()
        {
            state = State.Normal;
            move = true;
        }

        public void DesactivateCourage()
        {
            Force = 0;
        }

        public void DesactivateBlindage()
        {
            Armor = 0;
        }

        public void DesactivateCholera()
        {
            Resistance = 0;
        }

        public void DesactivateIre()
        {
            BonusValue = 0;
        }

        #endregion

        #region IAttackCharacter

        public bool IsNormal(IAttackCharacter character)
        {
            bool normal = true;

            if (state != State.Normal)
            {
                normal = false;
                character.NotifyMessageOther(Messages.NoNormal);
            }

            return normal;
        }

        public bool IsNear(IAttackCharacter enemy)
        {
            bool isNear = true;

            Vector vector = new Vector(enemy.Position.X - position.X, enemy.Position.Y - position.Y);

            if (vector.Module() > General.NearDistance)
            {
                isNear = false;
                NotifyMessageOther(Messages.NoNear);
            }

            return isNear;
        }

        public abstract bool ChanceResistance(ISkill skill, IAttackCharacter character);

        public void Debility(int damage, ISkill skill, IAttackCharacter character)
        {
            int totalDamage = damage - Armor * damage / 1200;
            health -= totalDamage;

            string message = character.Name + "->" + skill.Name + "(" + skill.Level + ")[" + totalDamage + "]->" + name;
            NotifyMessageDamage(message);
            character.NotifyMessageSkill(message);

            IsLiving();
        }

        public void DebilityCritical(int damage, ISkill skill, IAttackCharacter character)
        {
            damage += Aleatory();
            int totalDamage = damage - Armor * damage / 1200;
            health -= totalDamage;

            string message = character.Name + "->" + skill.Name + "(" + skill.Level + ")[" + totalDamage + "]->" + name + " Critico!";
            NotifyMessageDamage(message);
            character.NotifyMessageSkill(message);

            IsLiving();
        }

        public void DebilityEnergy(int damage)
        {
            energy -= damage;

            if (energy < 0)
                energy = 0;
        }

        #endregion

        private void LogSkill(ISkill skill)
        {
            string message = name + "->" + skill.Name + "(" + skill.Level + ")";

            NotifyMessageSkill(message);
            skill.Reset();
        }

        public bool SufficientEnergy(ISkill skill)
        {
            bool sufficient = false;

            if (energy >= skill.Cost)
            {
                energy -= skill.Cost;
                sufficient = true;
            }
            else
                NotifyMessageOther(Messages.NoEnergy);

            return sufficient;
        }

        private bool HealthMaximum()
        {
            bool healthMax = false;

            if (health >= CalculateHealth())
            {
                healthMax = true;
                NotifyMessageOther(Messages.MaxHealth);
            }

            return healthMax;
        }

        private bool EnergyMaximum()
        {
            bool maximum = false;

            if (energy >= CalculateEnergy())
            {
                maximum = true;
                NotifyMessageOther(Messages.MaxEnergy);
            }

            return maximum;
        }

        private bool IsArmor()
        {
            bool isArmor = true;

            if (Armor <= 0)
            {
                isArmor = false;
                NotifyMessageOther(Messages.NoArmor);
            }

            return isArmor;
        }

        private bool ChanceCriticalMaximum()
        {
            bool criticalMax = false;

            if (Critical >= General.ProbabilityCritical)
            {
                criticalMax = true;
                NotifyMessageOther(Messages.MaxCritical);
            }

            return criticalMax;
        }

        private bool ChanceCritical()
        {
            bool chance = false;

            float proba = General.ProbabilityCritical / Critical;

            if (proba < 1)
                proba = 1;

            if (Aleatory() % proba == 0)
                chance = true;

            return chance;
        }

        protected int Aleatory()
        {
            Random random = new Random();

            return random.Next(Damage);
        }

        public int Level
        {
            get { return level; }
        }

        protected abstract int Damage { get; }

        protected abstract int Armor { get; set; }

        protected abstract int Resistance { get; set; }

        protected abstract int Force { get; set; }

        protected abstract float Critical { get; }

        protected abstract int BonusValue { get; set; }

        protected abstract float SpeedyReload { get; }

        public int Health
        {
            get { return health; }
        }

        public int Energy
        {
            get { return energy; }
        }

        #region IObserver

        public void AddObserver(IObserverMessage observer)
        {
            observers.Add(observer);
        }

        public void NotifyMessageSkill(string message)
        {
            foreach (IObserverMessage observer in observers)
                observer.UpdateMessageSkill(message);
        }

        public void NotifyMessageOther(string message)
        {
            foreach (IObserverMessage observer in observers)
                observer.UpdateMessageOther(message);
        }

        public void NotifyMessageDamage(string message)
        {
            foreach (IObserverMessage observer in observers)
                observer.UpdateMessageDamage(message);
        }

        public void UpdateMessageSkill(string message)
        {
            NotifyMessageSkill(message);
        }

        public void UpdateMessageOther(string message)
        {
            NotifyMessageOther(message);
        }

        public void UpdateMessageDamage(string message)
        {
            NotifyMessageDamage(message);
        }

        public void AddObserverSkill(IObserverSkillsList observer)
        {
            skills.AddObserver(observer);
        }

        public void AddObserverSkill(int index, IObserverSkill observer)  //for skillBar
        {
            skills.AddObserverSkill(index, observer);
        }

        public void AddObserverAnimationSkill(IObserverAnimationSkill observer)
        {
            skills.AddObserverAnimationSkill(observer);
        }

        #endregion
    }
}
