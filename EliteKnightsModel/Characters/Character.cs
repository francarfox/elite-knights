using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace EliteKnightsModel.Characters
{
    public abstract class Character : Entity, ICharacter
    {
        protected bool move;  //detect collisions
        private float rotate;

        private List<IObserverMobile> observers;

        public Character(string name, Vector position)
            : base(name, position)
        {
            move = true;
            observers = new List<IObserverMobile>();
        }

        public void Move(Vector traslation)
        {
            //List<IEntity> entities = World.Instance.NearEntities(this);
            if (move)
            {
                position.Move(traslation.Product(0.04f), rotate);
                NotifyMove(traslation.Product(0.04f));
            }
        }

        public void Rotate(float rotation)
        {
            rotate -= rotation * 0.03f;
            NotifyRotate(rotate);
        }

        public virtual void Update()
        {
            //move
        }

        public void AddObserver(IObserverMobile observer)
        {
            observers.Add(observer);
        }

        public void NotifyMove(Vector traslation)
        {
            foreach (IObserverMobile observer in observers)
                observer.UpdateMove(traslation);
        }

        public void NotifyRotate(float rotation)
        {
            foreach (IObserverMobile observer in observers)
                observer.UpdateRotate(rotation);
        }
    }
}
