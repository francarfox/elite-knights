using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel.Items
{
    class None : Item
    {
        public None(string name)
            : base(name, Category.None, 0)
        { }

        public override int Level
        {
            get { return 0; }
        }

        public override int Value
        {
            get { return 0; }
        }
    }
}
