using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel
{
    public interface IObservableSkill
    {
        void AddObserver(IObserverSkill observer);
        void NotifyCurrentReload(int current);
        void NotifyCurrentDuration(int current);
    }
}
