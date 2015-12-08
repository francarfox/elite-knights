using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Persistence;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EliteKnightsPersistence
{
    class GeneratorFile
    {
        private string name;

        private string file;
        private DataList dataList;

        public GeneratorFile()
        {
            name = "Player";
            file = PersistenceGame.FileName;
            dataList = new DataList(name, new Data(name, 1, 1, 1));
        }

        public void Initialize()
        {
            Data data = new Data("Julius", 19, 3000, 3100); dataList.Add(data);
            data = new Data("Tigro", 17, 2600, 2850); dataList.Add(data);
            data = new Data("Ogre", 16, 2500, 2800); dataList.Add(data);
            data = new Data("Eddark", 16, 2450, 2700); dataList.Add(data);
            data = new Data("Artur", 16, 2400, 2600); dataList.Add(data);
            data = new Data("Maximus", 16, 2320, 2500); dataList.Add(data);
            data = new Data("Ferre", 15, 2260, 2500); dataList.Add(data);
            data = new Data("Marcus", 15, 2200, 2450); dataList.Add(data);
            data = new Data("Coraza", 15, 2100, 2400); dataList.Add(data);
            data = new Data("Cesar", 15, 2000, 2300); dataList.Add(data);
            data = new Data("Phanto", 14, 1900, 2200); dataList.Add(data);
            data = new Data("Dante", 14, 1850, 2100); dataList.Add(data);
            data = new Data("Hachem", 14, 1800, 2100); dataList.Add(data);
            data = new Data("Mattius", 14, 1750, 2000); dataList.Add(data);
            data = new Data("Davids", 14, 1700, 1900); dataList.Add(data);
            data = new Data("Kev", 14, 1670, 1900); dataList.Add(data);
            data = new Data("Madwaq", 14, 1640, 1900); dataList.Add(data);
            data = new Data("Thronn", 14, 1550, 1800); dataList.Add(data);
            data = new Data("August", 14, 1430, 1750); dataList.Add(data);
            data = new Data("Black", 14, 1380, 1700); dataList.Add(data);
            data = new Data("Campos", 13, 1300, 1650); dataList.Add(data);
            data = new Data("Linus", 13, 1260, 1500); dataList.Add(data);
            data = new Data("Brandon", 13, 1200, 1400); dataList.Add(data);
            data = new Data("Divex", 13, 1170, 1320); dataList.Add(data);
            data = new Data("Exort", 13, 1130, 1300); dataList.Add(data);
            data = new Data("Berlin", 13, 1100, 1300); dataList.Add(data);
            data = new Data("Frederic", 13, 1050, 1300); dataList.Add(data);
            data = new Data("Mamuth", 13, 1000, 1200); dataList.Add(data);
            data = new Data("Homer", 13, 960, 1200); dataList.Add(data);
            data = new Data("Elver", 13, 930, 1200); dataList.Add(data);
            data = new Data("Cobrax", 12, 900, 1150); dataList.Add(data);
            data = new Data("Hunter", 12, 850, 1000); dataList.Add(data);
            data = new Data("Bosch", 12, 800, 950); dataList.Add(data);
            data = new Data("Peet", 12, 760, 900); dataList.Add(data);
            data = new Data("Dragon", 12, 650, 850); dataList.Add(data);
            data = new Data("Wallk", 12, 600, 820); dataList.Add(data);
            data = new Data("Corvinus", 12, 580, 780); dataList.Add(data);
            data = new Data("Dash", 12, 550, 750); dataList.Add(data);
            data = new Data("Vernot", 12, 500, 700); dataList.Add(data);
            data = new Data("Grandad", 12, 480, 650); dataList.Add(data);
            data = new Data("Thunder", 11, 450, 650); dataList.Add(data);
            data = new Data("Liberty", 11, 435, 650); dataList.Add(data);
            data = new Data("Espart", 11, 420, 620); dataList.Add(data);
            data = new Data("Claude", 11, 400, 600); dataList.Add(data);
            data = new Data("Gross", 11, 370, 570); dataList.Add(data);
            data = new Data("Cirius", 11, 330, 530); dataList.Add(data);
            data = new Data("Golden", 11, 290, 490); dataList.Add(data);
            data = new Data("Simbol", 11, 250, 450); dataList.Add(data);
            data = new Data("Eloim", 11, 240, 440); dataList.Add(data);
            data = new Data("Blast", 11, 230, 400); dataList.Add(data);
            data = new Data("Frezz", 10, 210, 350); dataList.Add(data);
            data = new Data("Carson", 10, 200, 300); dataList.Add(data);
            data = new Data("Diamond", 10, 180, 270); dataList.Add(data);
            data = new Data("Preson", 10, 170, 260); dataList.Add(data);
            data = new Data("Hector", 10, 160, 250); dataList.Add(data);
            data = new Data("Grifo", 10, 150, 240); dataList.Add(data);
            data = new Data("Blind", 10, 140, 200); dataList.Add(data);
            data = new Data("Lester", 10, 130, 200); dataList.Add(data);
            data = new Data("Promez", 10, 120, 200); dataList.Add(data);
            data = new Data("Jordan", 10, 110, 200); dataList.Add(data);
        }

        public void GenerateFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(File.OpenWrite(file), dataList);

            Console.WriteLine("Archivo Generado");
        }

        public void LoadFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            dataList = (DataList)formatter.Deserialize(File.OpenRead(file));

            Console.WriteLine("Archivo Cargado");
        }
    }
}
