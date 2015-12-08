using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Skills;

namespace EliteKnightsModel
{
    public interface IObserverSkill
    {
        void UpdateCurrentReload(int current);
        void UpdateCurrentDuration(int current);
    }
}
