using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using EliteKnightsModel.Characters;
using System.Runtime.Serialization.Formatters.Binary;

namespace EliteKnightsModel.Persistence
{
    public class PersistenceGame
    {
        private static string file = "game.ek";

        private BinaryFormatter formatter;
        private DataList dataList;

        public PersistenceGame()
        {
            formatter = new BinaryFormatter();
        }

        public void LoadGame(Memory memory)
        {
            dataList = (DataList)formatter.Deserialize(File.OpenRead(file));

            LoadProfile(memory);
            LoadPersonages(memory);
        }

        private void LoadProfile(Memory memory)
        {
            string nameProfile = dataList.NameProfile;
            Data dataProfile = dataList.DataProfile;

            Personage personage = new Knight(dataProfile.Name, dataProfile.Level, dataProfile.Won, dataProfile.Play);
            personage.Experience = dataProfile.Experience;
            personage.Coins = dataProfile.Coins;

            memory.Profile = new Profile(nameProfile);
            memory.Profile.AddPersonage(personage);
        }

        private void LoadPersonages(Memory memory)
        {
            List<Data> list = dataList.List;

            foreach (Data data in list)
            {
                Personage personage = new Knight(data.Name, data.Level, data.Won, data.Play);
                memory.Personages.Add(personage);
            }
        }

        public void SaveGame(Memory memory)
        {
            SaveProfile(memory);
            SaveKnights(memory);

            formatter.Serialize(File.OpenWrite(file), dataList);
        }

        private void SaveProfile(Memory memory)
        {
            string nameProfile = memory.Profile.Name;
            Personage personage = memory.Profile.MainPersonage;

            Data dataProfile = new Data(personage.Name, personage.Level, personage.BattlesWon, personage.BattlesPlay);
            dataProfile.Experience = dataProfile.Experience;
            dataProfile.Coins = dataProfile.Coins;

            dataList = new DataList(nameProfile, dataProfile);
        }

        private void SaveKnights(Memory memory)
        {
            foreach (Knight knight in memory.Personages)
            {
                Data data = new Data(knight.Name, knight.Level, knight.BattlesWon, knight.BattlesPlay);
                dataList.Add(data);
            }
        }

        public static string FileName
        {
            get { return file; }
        }
    }
}
