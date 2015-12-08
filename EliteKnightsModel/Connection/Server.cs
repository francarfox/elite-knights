using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using EliteKnightsModel.Characters;
using System.Runtime.Serialization.Formatters.Binary;

namespace EliteKnightsModel.Connection
{
    class Server : Connection
    {
        private Socket acc;
        
        public Server()
        {
            ip = IPAddress.Parse(GetIp());
        }

        public override void Run()
        {
            base.Run();

            Console.WriteLine("IP: " + GetIp());

            acc.Bind(new IPEndPoint(ip, port));
            acc.Listen(0);
            Console.WriteLine("Esperando clientes...");
            socket = acc.Accept();  //sleep

            rec.Start();

            while (true)    //enviar - send
            {
                string message = Console.ReadLine();
                byte[] sdata = Encoding.Default.GetBytes("<" + name + "> " + message);
                socket.Send(sdata, 0, sdata.Length, 0);
            }
        }

        protected override void Receive()
        {
            while (true)
            {
                Thread.Sleep(500);

                byte[] buffer = new byte[255];
                int rec = acc.Receive(buffer, 0, buffer.Length, 0);
                Array.Resize(ref buffer, rec);
                Console.WriteLine(Encoding.Default.GetString(buffer));
            }
        }

        private string GetIp()
        {
            string hostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
            IPAddress[] address = ipEntry.AddressList;

            return address[address.Length - 1].ToString();
        }
    }
}
