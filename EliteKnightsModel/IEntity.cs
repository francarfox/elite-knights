using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel
{
    public interface IEntity : IPositionable
    {
        string Name { get; }
    }
}
