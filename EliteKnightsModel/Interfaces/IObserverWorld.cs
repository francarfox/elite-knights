using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel
{
    public interface IObserverWorld
    {
        void UpdateAddPrincipal(Personage personage);
        void UpdateAddEntity(IEntity entity);
    }
}
