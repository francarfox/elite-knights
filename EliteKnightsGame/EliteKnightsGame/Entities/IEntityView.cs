using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EliteKnightsGame.Entities
{
    interface IEntityView : IDrawable, EliteKnightsModel.IUpdateable
    {
        bool IsSelected();
    }
}
