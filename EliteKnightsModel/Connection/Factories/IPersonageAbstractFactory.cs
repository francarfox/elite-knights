using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Connection
{
    interface IPersonageAbstractFactory
    {
        Personage Create(string name, Vector position);
    }
}
