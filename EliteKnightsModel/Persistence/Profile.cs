using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Persistence
{
    public class Profile
    {
        private string name;    //pass
        private List<Personage> personages;

        public Profile(string name)
        {
            this.name = name;
            personages = new List<Personage>();
        }

        public void Initialize()
        {
            personages.Add(new Knight(name));  //test
        }

        public void AddPersonage(Personage personage)
        {
            personages.Add(personage);
        }

        public string Name
        {
            get { return name; }
        }

        public Personage MainPersonage  //test
        {
            get { return personages[0]; }
        }
    }
}
