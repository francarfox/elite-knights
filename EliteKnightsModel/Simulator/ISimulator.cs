using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Simulator
{
    interface ISimulator : IObserverMessage
    {
        void SimulateAttack(IAttackCharacter target);
        void SimulateMove(IAttackCharacter target);
    }
}
