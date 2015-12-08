using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel.Items
{
    class Armor : Item
    {
        private int level, armature;
        private Material material;

        public Armor(string name, Category category, int level)
            : base(name, category, 1)
        {
            this.level = level;
            armature = CalculateArmature();
            material = CalculateMaterial();
        }

        private int CalculateArmature()
        {
            int armor;

            if (level < 5)
                armor = 1 * level + 9;
            else
            {
                if (level < 10)
                    armor = 2 * level + 4;
                else
                    armor = 3 * level - 6;
            }

            return armor;
        }

        private Material CalculateMaterial()
        {
            Material material = Material.Leather;

            if (level > 5 && level <= 15)
                material = Material.Bronze;
            else
                if (level <= 30)
                    material = Material.Silver;
                else
                    material = Material.Gold;

            return material;
        }

        public override int Level
        {
            get { return level; }
        }

        public override int Value
        {
            get { return armature; }
        }
    }
}
