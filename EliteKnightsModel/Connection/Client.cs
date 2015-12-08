using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace EliteKnightsModel.Connection
{
    class Client : Connection
    {
        public Client()
        { }

        public override void Run()
        {
            base.Run();

            Console.WriteLine("Server IP: ");
            ip = IPAddress.Parse(Console.ReadLine());

            socket.Connect(new IPEndPoint(ip, port));

            rec.Start();

            byte[] conmsg = Encoding.Default.GetBytes("<" + name + "> " + "Connected");
            socket.Send(conmsg, 0, conmsg.Length, 0);

            while (socket.Connected)
            {
                string message = Console.ReadLine();

                byte[] sdata = Encoding.Default.GetBytes("<" + name + "> " + message);
                socket.Send(sdata, 0, sdata.Length, 0);
            }

            Close();
        }

        protected override void Receive()
        {
            while (true)
            {
                Thread.Sleep(500);

                byte[] buffer = new byte[255];
                int rec = socket.Receive(buffer, 0, buffer.Length, 0);
                Array.Resize(ref buffer, rec);
                Console.WriteLine(Encoding.Default.GetString(buffer));
            }
        }
    }
}
