using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Skills
{
    public class Fury : OffensiveSkill
    {
        public Fury(IAttackCharacter character)
            : base(character, Names.Fury, 400)
        { }

        public override void Activate(IAttackCharacter enemy)
        {
            try
            {
                base.Activate(enemy);

                if (!IsReload())
                    character.ActivateFury(this, enemy);
            }
            catch { }
        }

        public int DamageFury(int damage)
        {
            int damageFury;

            if (ChanceFury(damage))
                damageFury = 2 * damage;    //200%
            else
                damageFury = 15 * damage / 10;  //150%

            return damageFury;
        }

        public bool ChanceFury(int damage)
        {
            bool chanceFury = false;
            Random random = new Random();
            int aleatory = random.Next(damage);

            if (aleatory % 2 == 0)  //50% chance
                chanceFury = true;

            return chanceFury;
        }
    }
}
