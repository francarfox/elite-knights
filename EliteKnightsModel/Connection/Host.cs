using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel.Connection
{
    class Host
    {
        private Connection server;

        public Host()
        {
            server = new Server();
        }
    }
}
