using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Items
{
    public class Equipment
    {
        private Personage personage;
        private ItemsList items;
        private Dictionary<Category, IItem> equipment;
        private None none;

        public Equipment(Personage personage, ItemsList items)
        {
            this.personage = personage;
            this.items = items;
            equipment = new Dictionary<Category, IItem>();
            none = new None("");

            Initialize();
        }

        private void Initialize()
        {
            equipment.Add(Category.Helmet, none);
            equipment.Add(Category.ShoulderPads, none);
            equipment.Add(Category.Gauntlets, none);
            equipment.Add(Category.Front, none);
            equipment.Add(Category.Belt, none);
            equipment.Add(Category.Legs, none);
            equipment.Add(Category.Shield, none);
            equipment.Add(Category.Arm, none);
        }

        public void EquipItem(IItem item)
        {
            if (IsLevelCorrect(item) && IsItemEquippable(item))
            {
                UnequipItem(item.Category);
                equipment[item.Category] = item;
                items.RemoveItem(item);
            }
        }

        private bool IsLevelCorrect(IItem item)
        {
            bool correct = false;

            if (personage.Level >= item.Level)
                correct = true;

            return correct;
        }

        public void UnequipItem(Category category)
        {
            items.AddItem(equipment[category]);
            equipment[category] = none;
        }

        private bool IsItemEquippable(IItem item)
        {
            bool equippable = false;

            List<Category> equippableCategories = equipment.Keys.ToList();

            if (equippableCategories.Contains(item.Category))
                equippable = true;

            return equippable;
        }

        public int Armor
        {
            get
            {
                int armor = equipment[Category.Helmet].Value;
                armor += equipment[Category.ShoulderPads].Value;
                armor += equipment[Category.Gauntlets].Value;
                armor += equipment[Category.Front].Value;
                armor += equipment[Category.Belt].Value;
                armor += equipment[Category.Legs].Value;
                return armor;
            }
        }

        public int Resistance
        {
            get { return equipment[Category.Shield].Value; }
        }

        public int Damage
        {
            get { return equipment[Category.Arm].Value; }
        }
    }
}
