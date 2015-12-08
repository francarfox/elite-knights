using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Persistence;
using EliteKnightsModel.Characters;
using EliteKnightsModel.Boots;

namespace EliteKnightsModel
{
    public class Memory
    {
        private Profile profile;
        private List<Personage> personages;

        private PersistenceGame persistence;

        public Memory()
        {
            personages = new List<Personage>();
            persistence = new PersistenceGame();
        }

        public void Initialize()
        {
            try
            {
                persistence.LoadGame(this);
            }
            catch
            {
                //Archivo no encontrado exception
            }
        }

        public void Reset(string nameProfile)
        {
            profile = new Profile(nameProfile);
            profile.Initialize();

            personages.Clear();
            PersonagesBoot.LoadPersonages(this);
        }

        public void Save()
        {
            persistence.SaveGame(this);
        }

        public Profile Profile
        {
            get { return profile; }
            set { profile = value; }
        }

        public List<Personage> Personages
        {
            get { return personages; }
        }
    }
}
