using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel.Scene
{
    public class House : Construction
    {
        public House(Vector position)
            : base(Names.House, position, 1, 2)
        { }
    }
}
