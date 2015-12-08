using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;
using EliteKnightsModel.Scene;
using EliteKnightsModel.Simulator;

namespace EliteKnightsModel.Boots
{
    public abstract class MapBoot
    {
        private static Random random = new Random();

        public static void LoadMap(World world)
        {
            world.AddEntity(new Terrain());

            for (int i = 0; i < 1; i++)
                world.AddEntity(new House(new Vector(Random(), Random())));

            LoadPersonages(world);
        }

        private static void LoadPersonages(World world)
        {
            KnightSimulator personage = new KnightSimulator("Computer", new Vector(20, 20), 20, 1, 1);
            personage.Target = world.Principal;
            world.AddEntity(personage);
        }

        private static int Random()
        {
            return random.Next(-General.TerrainWidth, General.TerrainWidth);
        }
    }
}
