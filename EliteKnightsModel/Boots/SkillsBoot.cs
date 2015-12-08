using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Skills;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Boots
{
    abstract class SkillsBoot
    {
        public static void LoadSkillsKnight(AttackCharacter character, SkillsList skills)
        {
            skills.AddSkill(new Attack(character));
            skills.AddSkill(new Meditation(character));

            int level = character.Level;
            int count = 2;

            if (level >= 2)
            {
                skills.AddSkill(new Courage(character));
                count++;
            }
            if (level >= 4)
            {
                skills.AddSkill(new Blindage(character));
                count++;
            }
            if (level >= 5)
            {
                skills.AddSkill(new Court(character));
                count++;
            }
            if (level >= 6)
            {
                skills.AddSkill(new Immune(character));
                count++;
            }
            if (level >= 7)
            {
                skills.AddSkill(new Winged(character));
                count++;
            }
            if (level >= 8)
            {
                skills.AddSkill(new Ire(character));
                count++;
            }
            if (level >= 9)
            {
                skills.AddSkill(new Fury(character));
                count++;
            }
            if (level >= 10)
            {
                skills.AddSkill(new Cholera(character));
                count++;
            }

            LoadNoneSkill(count, skills);
        }

        private static void LoadNoneSkill(int count, SkillsList skills)
        {
            for (int i = 0; i < General.CountSkillsMax - count; i++)
                skills.AddSkill(new NoneSkill());
        }

        public static void LoadSkillsEnemy(IAttackCharacter character, SkillsList skills)
        {
            skills.AddSkill(new Attack(character));
            skills.AddSkill(new Meditation(character));

            for (int i = 0; i < General.CountSkillsMax - 2; i++)
                skills.AddSkill(new NoneSkill());
        }
    }
}
