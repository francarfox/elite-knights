using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel.Connection
{
    [Serializable]
    class Data
    {
        private string name;
        private int level;

        public Data(string name, int level)
        {
            this.name = name;
            this.level = level;
        }
    }
}
