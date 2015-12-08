using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsServer
{
    class Menu
    {
        private List<Instruction> instructions;

        public Menu()
        {
            instructions = new List<Instruction>();

            Initialize();
        }

        private void Initialize()
        {
            instructions.Add(new Instruction("help", "para ver instrucciones validas", Help));

            instructions.Add(new Instruction("connects", "muestra los jugadores conectados", Connects));
            instructions.Add(new Instruction("profiles", "muestra todos los perfiles", Profiles));
            instructions.Add(new Instruction("personages", "muestra los personajes del perfil actual", Personages));
            instructions.Add(new Instruction("skills", "muestra las skills del personaje actual", Skills));
            instructions.Add(new Instruction("items", "muestra los items del personaje actual", Items));

            instructions.Add(new Instruction("cls", "para limpiar pantalla", ClearScreen));
            instructions.Add(new Instruction("exit", "para salir", Exit));
        }

        public void IsInstruction(string key)
        {
            foreach (Instruction instruction in instructions)
            {
                if (instruction.Name == key)
                {
                    instruction.Active();
                    Console.WriteLine();
                    return;
                }
            }

            Console.WriteLine(instructions[0] + "\n");
        }

        #region Function

        private void Help()
        {
            for (int i = 1; i < instructions.Count; i++)
                Console.WriteLine(instructions[i]);
        }

        private void Connects()
        { }

        private void Profiles()
        { }

        private void Personages()
        { }

        private void Skills()
        { }

        private void Items()
        { }

        private void ClearScreen()
        {
            Console.Clear();
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        #endregion
    }
}
