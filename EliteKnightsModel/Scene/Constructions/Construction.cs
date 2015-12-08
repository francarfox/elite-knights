using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel.Scene
{
    public abstract class Construction : Stage
    {
        public Construction(string name, Vector position, int width, int height)
            : base(name, position, width, height)
        { }
    }
}
