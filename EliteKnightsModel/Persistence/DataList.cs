using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel.Persistence
{
    [Serializable]
    public class DataList
    {
        //profile
        private string nameProfile;
        private Data dataProfile;

        //knights
        private List<Data> dataList;

        public DataList(string nameProfile, Data dataProfile)
        {
            this.nameProfile = nameProfile;
            this.dataProfile = dataProfile;

            dataList = new List<Data>();
        }

        public void AddDataProfile(Data data)
        {
            dataProfile = data;
        }

        public void Add(Data data)
        {
            dataList.Add(data);
        }

        public string NameProfile
        {
            get { return nameProfile; }
        }

        public Data DataProfile
        {
            get { return dataProfile; }
        }

        public List<Data> List
        {
            get { return dataList; }
        }
    }
}
