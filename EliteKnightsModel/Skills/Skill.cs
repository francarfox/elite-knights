using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public abstract class Skill : ISkill, IObservableMessage, IObservableAnimationSkill
    {
        protected IAttackCharacter character;
        private string name;
        private int level, reload, duration, currentReload, currentDuration;
        private int cost;

        private List<IObserverSkill> observersSkill;
        private List<IObserverMessage> observersMessage;
        private List<IObserverAnimationSkill> observersAnimation;

        public Skill(IAttackCharacter character, string name, int cost, int reload, int duration)
        {
            this.character = character;
            this.name = name;

            level = 1;
            this.cost = cost;
            this.reload = reload;
            this.duration = duration;
            currentReload = reload + 1;
            currentDuration = duration + 1;

            observersSkill = new List<IObserverSkill>();
            observersMessage = new List<IObserverMessage>();
            observersAnimation = new List<IObserverAnimationSkill>();
            AddObserver(character);
        }

        public Skill(IAttackCharacter character, string name, int cost, int reload)
            : this(character, name, cost, reload, 0)
        { }

        public Skill(IAttackCharacter character, string name, int cost)
            : this(character, name, cost, 0)
        { }

        public abstract void Activate(IAttackCharacter enemy);

        //public void LevelUp()
        //{
        //    if (level < General.LevelSkillMax)
        //        level++;
        //}

        public void Reload()
        {
            if (currentReload <= reload)
            {
                NotifyCurrentReload(reload - currentReload);
                currentReload++;
            }

            if (currentDuration <= duration)
            {
                NotifyCurrentDuration(duration - currentDuration);
                currentDuration++;
            }
            else
                Desactivate();
        }

        public virtual void Reset()
        {
            currentReload = 0;
            currentDuration = 0;
            NotifyCurrentReload(reload - currentReload);
            NotifyCurrentDuration(duration - currentDuration);
            NotifyAnimationSkill();
        }

        protected virtual void Desactivate()
        { }

	    protected bool IsReload()
        {
            bool isReload = false;

            if (currentReload <= reload)
            {
                isReload = true;
                NotifyMessageOther(Messages.IsReload);
            }
            
            return isReload;
	    }

        public string Name
        {
            get { return name; }
        }

        public int Level
        {
            get { return level; }
        }

        public int Cost
        {
            get { return cost; }
        }

        #region IObserver

        public void AddObserver(IObserverMessage observer)
        {
            observersMessage.Add(observer);
        }

        public void NotifyMessageSkill(string message)
        {
            foreach (IObserverMessage observer in observersMessage)
                observer.UpdateMessageSkill(message);
        }

        public void NotifyMessageOther(string message)
        {
            foreach (IObserverMessage observer in observersMessage)
                observer.UpdateMessageOther(message);
        }

        public void NotifyMessageDamage(string message)
        {
            foreach (IObserverMessage observer in observersMessage)
                observer.UpdateMessageDamage(message);
        }

        public void AddObserver(IObserverSkill observer)
        {
            observersSkill.Add(observer);
        }

        public void NotifyCurrentReload(int current)
        {
            foreach (IObserverSkill observer in observersSkill)
                observer.UpdateCurrentReload(current);
        }

        public void NotifyCurrentDuration(int current)
        {
            foreach (IObserverSkill observer in observersSkill)
                observer.UpdateCurrentDuration(current);
        }

        public void AddObserver(IObserverAnimationSkill observer)
        {
            observersAnimation.Add(observer);
        }

        public void NotifyAnimationSkill()
        {
            foreach (IObserverAnimationSkill observer in observersAnimation)
                observer.UpdateAnimationSkill(this);
        }

        #endregion
    }
}
