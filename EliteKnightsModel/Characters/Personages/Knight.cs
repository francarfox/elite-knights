using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Boots;

namespace EliteKnightsModel.Characters
{
    public class Knight : Personage
    {
        public Knight(string name, Vector position, int level, int battlesWon, int battlesPlay)
            : base(name, position, level, battlesWon, battlesPlay)
        {
            SkillsBoot.LoadSkillsKnight(this, skills);
            ItemsBoot.LoadItemsStandard(items);

            equipment.EquipItem(items.Item(0)); //test
        }

        public Knight(string name, int level, int battlesWon, int battlesPlay)
            : this(name, Vector.Zero, level, battlesWon, battlesPlay)
        { }

        public Knight(string name)
            : this(name, 1, 0, 0)
        { }
    }
}
