using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public interface ISkill : IObservableSkill
    {
        void Activate(IAttackCharacter enemy);
        void Reload();
        void Reset();
        string Name { get; }
        int Level { get; }
        int Cost { get; }
    }
}
