using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsServer
{
    delegate void Function();

    class Instruction
    {
        private string name, resume;
        private Function function;

        public Instruction(string name, string resume, Function function)
        {
            this.name = name;
            this.resume = resume;
            this.function = function;
        }

        public void Active()
        {
            function();
        }

        public string Name
        {
            get { return name; }
        }

        public override string ToString()
        {
            return "'" + name + "' " + resume;
        }
    }
}
