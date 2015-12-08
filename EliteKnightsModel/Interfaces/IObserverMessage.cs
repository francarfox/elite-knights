using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel
{
    public interface IObserverMessage
    {
        void UpdateMessageSkill(string message);
        void UpdateMessageOther(string message);
        void UpdateMessageDamage(string message);
    }
}
