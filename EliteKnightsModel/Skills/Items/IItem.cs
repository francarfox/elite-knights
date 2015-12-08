using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel.Items
{
    public interface IItem
    {
        Category Category { get; }
        int Level { get; }
        int Value { get; }
    }
}
