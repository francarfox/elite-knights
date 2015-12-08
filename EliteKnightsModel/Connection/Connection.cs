using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace EliteKnightsModel.Connection
{
    abstract class Connection
    {
        protected string name;
        protected IPAddress ip;
        protected int port;

        protected Socket socket;
        protected Thread rec;

        protected BinaryFormatter formatter;

        public Connection()
        {
            port = 1111;

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            rec = new Thread(Receive);

            formatter = new BinaryFormatter();
        }

        public virtual void Run()
        {
            Console.Write("Name: ");
            name = Console.ReadLine();
        }

        protected abstract void Receive();

        protected void Close()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        public void Connect()
        {
            NetworkStream net = new NetworkStream(socket);

            Data bmp = new Data("Name", 1);

            formatter.Serialize(net, bmp);

            net.Close();

            //en el destino Deserializas el objeto:

            Data data = (Data)formatter.Deserialize(net);

            net.Close();
        }
    }
}
