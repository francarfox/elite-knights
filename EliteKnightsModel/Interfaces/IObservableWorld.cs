using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel
{
    public interface IObservableWorld
    {
        void AddObserver(IObserverWorld observer);
        void NotifyAddPrincipal();
        void NotifyAddEntity(IEntity entity);
    }
}
