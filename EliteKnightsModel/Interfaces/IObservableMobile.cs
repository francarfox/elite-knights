using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel
{
    public interface IObservableMobile
    {
        void AddObserver(IObserverMobile observer);
        void NotifyMove(Vector traslation);
        void NotifyRotate(float rotation);
    }
}
