using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Boots;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public class SkillsList : IObservableSkillList
    {
        private List<ISkill> skills;
        private List<IObserverSkillsList> observers;

        public SkillsList()
        {
            skills = new List<ISkill>();
            observers = new List<IObserverSkillsList>();
        }

        public void AddSkill(ISkill skill)
        {
            if (skills.Count < General.CountSkillsMax)
                skills.Add(skill);
        }

        public void ActivateSkill(int index, IAttackCharacter enemy)
        {
            skills[index].Activate(enemy);
        }

        public void ActivateSkill(string name, IAttackCharacter enemy)    //for enemy
        {
            foreach (Skill skill in skills)
            {
                if (name == skill.Name)
                {
                    skill.Activate(enemy);
                    break;
                }
            }
        }

        public void Reload()
        {
            NotifySkills();

            foreach (ISkill skill in skills)
                skill.Reload();
        }

        public ISkill Skill(int index)
        {
            return skills[index];
        }

        public void AddObserver(IObserverSkillsList observer)
        {
            observers.Add(observer);
        }

        public void NotifySkills()
        {
            foreach (IObserverSkillsList observer in observers)
                observer.UpdateSkills(this);
        }

        public void AddObserverSkill(int index, IObserverSkill observer)
        {
            skills[index].AddObserver(observer);
        }

        public void AddObserverAnimationSkill(IObserverAnimationSkill observer)
        {
            foreach (Skill skill in skills)
                skill.AddObserver(observer);
        }
    }
}
