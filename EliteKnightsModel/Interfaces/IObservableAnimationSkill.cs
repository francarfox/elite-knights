using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel
{
    public interface IObservableAnimationSkill
    {
        void AddObserver(IObserverAnimationSkill observer);
        void NotifyAnimationSkill();
    }
}
