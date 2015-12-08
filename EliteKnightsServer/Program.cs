using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace EliteKnightsServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerConsole server = new ServerConsole();
            Menu menu = new Menu();

            while (true)
            {
                Console.Write(">");
                string key = Console.ReadLine();

                menu.IsInstruction(key);
            }
        }
    }
}
