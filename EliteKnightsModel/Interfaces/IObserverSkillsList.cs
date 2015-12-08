using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Skills;

namespace EliteKnightsModel
{
    public interface IObserverSkillsList
    {
        void UpdateSkills(SkillsList skills);
    }
}
