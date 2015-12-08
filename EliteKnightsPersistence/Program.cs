using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsPersistence
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneratorFile generator = new GeneratorFile();

            generator.Initialize();

            generator.GenerateFile();
            //generator.LoadFile();

            Console.ReadKey();
        }
    }
}
