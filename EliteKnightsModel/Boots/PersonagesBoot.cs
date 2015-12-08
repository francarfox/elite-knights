using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Boots
{
    abstract class PersonagesBoot
    {
        public static void LoadPersonages(Memory memory)
        {
            List<Personage> list = memory.Personages;

            Personage personage = new Knight("Julius", 50, 3000, 3100); list.Add(personage);
            personage = new Knight("Tigro", 50, 2600, 2850); list.Add(personage);
            personage = new Knight("Ogre", 50, 2500, 2800); list.Add(personage);
            personage = new Knight("Eddark", 49, 2450, 2700); list.Add(personage);
            personage = new Knight("Mattius", 49, 2400, 2600); list.Add(personage);
            personage = new Knight("Maximus", 48, 2320, 2500); list.Add(personage);
            personage = new Knight("Fernal", 47, 2260, 2500); list.Add(personage);
            personage = new Knight("Blast", 46, 2200, 2450); list.Add(personage);
            personage = new Knight("Thunder", 45, 2100, 2400); list.Add(personage);
            personage = new Knight("Cesar", 44, 2000, 2300); list.Add(personage);
            personage = new Knight("Phanto", 43, 1900, 2200); list.Add(personage);
            personage = new Knight("Sant", 42, 1850, 2100); list.Add(personage);
            personage = new Knight("Elver", 41, 1800, 2100); list.Add(personage);
            personage = new Knight("Coraza", 41, 1750, 2000); list.Add(personage);
            personage = new Knight("Davids", 40, 1700, 1900); list.Add(personage);
            personage = new Knight("Kill", 40, 1670, 1900); list.Add(personage);
            personage = new Knight("Dash", 40, 1640, 1900); list.Add(personage);
            personage = new Knight("Thronn", 39, 1550, 1800); list.Add(personage);
            personage = new Knight("Dragon", 38, 1430, 1750); list.Add(personage);
            personage = new Knight("Black", 37, 1380, 1700); list.Add(personage);
            personage = new Knight("Campos", 36, 1300, 1650); list.Add(personage);
            personage = new Knight("Linus", 35, 1260, 1500); list.Add(personage);
            personage = new Knight("Stream", 34, 1200, 1400); list.Add(personage);
            personage = new Knight("Divex", 33, 1170, 1320); list.Add(personage);
            personage = new Knight("Exort", 32, 1130, 1300); list.Add(personage);
            personage = new Knight("Berlin", 31, 1100, 1300); list.Add(personage);
            personage = new Knight("Freez", 31, 1050, 1300); list.Add(personage);
            personage = new Knight("Mamuth", 30, 1000, 1200); list.Add(personage);
            personage = new Knight("Homer", 30, 960, 1200); list.Add(personage);
            personage = new Knight("Hachem", 30, 930, 1200); list.Add(personage);
            personage = new Knight("Cobrax", 29, 900, 1150); list.Add(personage);
            personage = new Knight("Hunter", 28, 850, 1000); list.Add(personage);
            personage = new Knight("Bosch", 27, 800, 950); list.Add(personage);
            personage = new Knight("Peet", 26, 760, 900); list.Add(personage);
            personage = new Knight("Agost", 25, 650, 850); list.Add(personage);
            personage = new Knight("Wallk", 24, 600, 820); list.Add(personage);
            personage = new Knight("Corvinus", 23, 580, 780); list.Add(personage);
            personage = new Knight("Madwaq", 22, 550, 750); list.Add(personage);
            personage = new Knight("Verbot", 21, 500, 700); list.Add(personage);
            personage = new Knight("Kev", 21, 480, 650); list.Add(personage);
            personage = new Knight("Artur", 20, 450, 650); list.Add(personage);
            personage = new Knight("Liberty", 20, 435, 650); list.Add(personage);
            personage = new Knight("Espart", 20, 420, 620); list.Add(personage);
            personage = new Knight("Claude", 19, 400, 600); list.Add(personage);
            personage = new Knight("Alado", 18, 370, 570); list.Add(personage);
            personage = new Knight("Cirius", 17, 330, 530); list.Add(personage);
            personage = new Knight("Golden", 16, 290, 490); list.Add(personage);
            personage = new Knight("Simbol", 15, 250, 450); list.Add(personage);
            personage = new Knight("Santy", 15, 240, 440); list.Add(personage);
            personage = new Knight("Marcus", 14, 230, 400); list.Add(personage);
            personage = new Knight("Frezz", 14, 210, 350); list.Add(personage);
            personage = new Knight("Carson", 13, 200, 300); list.Add(personage);
            personage = new Knight("Diamond", 13, 180, 270); list.Add(personage);
            personage = new Knight("Preson", 12, 170, 260); list.Add(personage);
            personage = new Knight("Hector", 12, 160, 250); list.Add(personage);
            personage = new Knight("Grifo", 11, 150, 240); list.Add(personage);
            personage = new Knight("Blindd", 11, 140, 200); list.Add(personage);
            personage = new Knight("Lester", 10, 130, 200); list.Add(personage);
            personage = new Knight("Promez", 10, 120, 200); list.Add(personage);
            personage = new Knight("Jordan", 10, 110, 200); list.Add(personage);
        }
    }
}
