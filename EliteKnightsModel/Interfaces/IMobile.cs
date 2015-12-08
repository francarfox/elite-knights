using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel
{
    public interface IMobile : IUpdateable, IObservableMobile
    {
        void Move(Vector traslation);
        void Rotate(float rotation);
    }
}
