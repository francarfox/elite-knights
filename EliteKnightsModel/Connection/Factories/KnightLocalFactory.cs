using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Connection
{
    class KnightLocalFactory : IPersonageAbstractFactory
    {
        public Personage Create(string name, Vector position)
        {
            return new Knight(name);
        }
    }
}
