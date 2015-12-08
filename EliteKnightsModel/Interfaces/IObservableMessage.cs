using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel
{
    public interface IObservableMessage
    {
        void AddObserver(IObserverMessage observer);
        void NotifyMessageSkill(string message);
        void NotifyMessageOther(string message);
        void NotifyMessageDamage(string message);
    }
}
