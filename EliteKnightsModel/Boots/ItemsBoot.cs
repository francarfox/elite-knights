using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Items;

namespace EliteKnightsModel.Boots
{
    abstract class ItemsBoot
    {
        public static void LoadItemsStandard(ItemsList items)
        {
            items.AddItem(new Armor("Pechera Caliza", Category.Front, 1));
        }
    }
}
