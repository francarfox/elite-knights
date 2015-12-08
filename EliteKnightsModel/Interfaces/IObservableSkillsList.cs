using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Skills;

namespace EliteKnightsModel
{
    public interface IObservableSkillList
    {
        void AddObserver(IObserverSkillsList observer);
        void NotifySkills();
    }
}
