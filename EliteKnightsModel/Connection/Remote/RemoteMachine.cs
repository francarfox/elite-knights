using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel.Connection
{
    class RemoteMachine
    {
        private static RemoteMachine instance = null;

        private Connection connection;  //serve || client

        private RemoteMachine()
        { }

        public void CreateKnight(KnightProxy proxy)
        {
            //envio mensaje por socket
        }

        public static RemoteMachine Instance
        {
            get 
            {
                if (instance == null)
                    instance = new RemoteMachine();

                return instance;
            }
        }
    }
}
