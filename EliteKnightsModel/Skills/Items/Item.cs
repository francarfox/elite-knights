using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel.Items
{
    abstract class Item : IItem
    {
        private string name;
        private Category category;
        //private int count;

        public Item(string name, Category category, int count)
        {
            this.name = name;
            this.category = category;
            //this.count = count;
        }

        public Category Category
        {
            get { return category; }
        }

        public abstract int Level { get; }

        public abstract int Value { get; }
    }
}
