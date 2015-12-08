using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Boots;

namespace EliteKnightsModel.Items
{
    public class ItemsList
    {
        private List<IItem> items;

        public ItemsList()
        {
            items = new List<IItem>();
        }

        public void AddItem(IItem item)
        {
            if (items.Count < General.CountItemsMax)
                items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            items.Remove(item);
        }

        public IItem Item(int index)
        {
            return items[index];
        }
    }
}
