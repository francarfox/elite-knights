using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public interface IActivableSkill
    {
        void ActivateAttack(Attack skill, IAttackCharacter enemy);
        void ActivateMeditation(Meditation skill);
        void ActivateCourt(Court skill, IAttackCharacter enemy);
        void ActivateImmune(Immune skill);
        void ActivateCourage(Courage skill);
        void ActivateBlindage(Blindage skill);
        void ActivateWinged(Winged skill);
        void ActivateFury(Fury skill, IAttackCharacter enemy);
        void ActivateIre(Ire skill);
        void ActivateCholera(Cholera skill);

        void DesactivateImmune();
        void DesactivateBlindage();
        void DesactivateCholera();
        void DesactivateCourage();
        void DesactivateIre();
    }
}
