using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Connection
{
    class KnightProxy : Knight
    {
        private RemoteMachine remote;

        public KnightProxy(string name)
            : base(name)
        {
            remote = RemoteMachine.Instance;
            remote.CreateKnight(this);
        }
    }
}
