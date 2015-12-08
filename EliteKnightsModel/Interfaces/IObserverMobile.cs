using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel
{
    public interface IObserverMobile
    {
        void UpdateMove(Vector traslation);
        void UpdateRotate(float rotation);
    }
}
