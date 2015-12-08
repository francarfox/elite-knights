using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Skills;

namespace EliteKnightsModel.Characters
{
    public interface IAttackCharacter : IActivableSkill, IObserverMessage, IObservableMessage, IPositionable
    {
        bool IsNormal(IAttackCharacter character);
        bool IsNear(IAttackCharacter character);
        bool ChanceResistance(ISkill skill, IAttackCharacter character);
        void Debility(int damage, ISkill skill, IAttackCharacter enemy);
        void DebilityCritical(int damage, ISkill skill, IAttackCharacter enemy);
        void DebilityEnergy(int damage);
        string Name { get; }
    }
}
