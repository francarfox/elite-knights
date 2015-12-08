using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel.Persistence
{
    [Serializable]
    public class Data
    {
        //entity
        private string name;

        //attackCharacter
        private int level;

        //personage
        private int battlesWon, battlesPlay;
        private long totalExperience, goldCoins;
        //protected ItemsList items;
        //protected Equipment equipment;

        public Data(string name, int level, int battlesWon, int battlesPlay)
        {
            this.name = name;
            this.level = level;
            this.battlesWon = battlesWon;
            this.battlesPlay = battlesPlay;
        }

        public Data(string name)
            : this(name, 1, 0, 0)
        { }

        public string Name
        {
            get { return name; }
        }

        public int Level
        {
            get { return level; }
        }

        public int Won
        {
            get { return battlesWon; }
        }

        public int Play
        {
            get { return battlesPlay; }
        }

        public long Experience
        {
            get { return totalExperience; }
            set { totalExperience = value; }
        }

        public long Coins
        {
            get { return goldCoins; }
            set { goldCoins = value; }
        }
    }
}
