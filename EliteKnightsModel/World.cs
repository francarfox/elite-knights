using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using EliteKnightsModel.Boots;
using EliteKnightsModel.Characters;
using EliteKnightsModel.Connection;

namespace EliteKnightsModel
{
    public class World : IObservableWorld
    {
        private static World world = null;

        private Personage principal;
        private List<IEntity> entities;
        private List<IObserverWorld> observers;

        private World() 
        {
            entities = new List<IEntity>();
            observers = new List<IObserverWorld>();
        }

        public void Initialize(Personage personage)
        {
            //principal = personage;
            principal = new Knight("Player", new Vector(-20, -20), 20, 1, 1);   //test
            entities.Add(principal);
            NotifyAddPrincipal();

            MapBoot.LoadMap(this);
        }

        public void AddEntity(IEntity entity)
        {
            entities.Add(entity);
            NotifyAddEntity(entity);
        }

        //public List<IEntity> NearEntities(IEntity entity)
        //{
        //    return entities; //calculate near entities
        //}

        public static World Instance
        {
            get 
            {
                if (world == null)
                    world = new World();

                return world;
            }
        }

        public Personage Principal
        {
            get { return principal; }
        }

        #region IObserver

        public void AddObserver(IObserverWorld observer)
        {
            observers.Add(observer);
        }

        public void NotifyAddPrincipal()
        {
            foreach (IObserverWorld observer in observers)
                observer.UpdateAddPrincipal(principal);
        }

        public void NotifyAddEntity(IEntity entity)
        {
            foreach (IObserverWorld observer in observers)
                observer.UpdateAddEntity(entity);
        }

        #endregion
    }
}
