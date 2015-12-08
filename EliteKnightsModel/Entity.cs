using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel
{
    public abstract class Entity : IEntity
    {
        protected string name;
        protected Vector position;

        public Entity(string name, Vector position)
        {
            this.name = name;
            this.position = position;
        }

        public string Name
        {
            get { return name; }
        }

        public Vector Position
        {
            get { return position; }
        }

        //public int CompareTo(object obj)
        //{
        //    IEntity entity = (IEntity)obj;

        //    return (int)((entity.Distance - distance) * 1000);
        //}
    }
}
