using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel;
using Microsoft.Xna.Framework.Graphics;

namespace EliteKnightsGame.Interface
{
    class Chat
    {
        private IEntity personage;

        public Chat(IEntity personage)
        {
            this.personage = personage;
        }

        public void Draw()
        { }
    }
}
