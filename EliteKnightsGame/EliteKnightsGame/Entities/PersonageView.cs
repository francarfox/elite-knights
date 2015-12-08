using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;
using EliteKnightsGame.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EliteKnightsModel;
using EliteKnightsModel.Skills;

namespace EliteKnightsGame.Entities
{
    class PersonageView : EntityView, IObserverMobile, IObserverAnimationSkill
    {
        private Personage personage;

        public PersonageView(Model model, Personage personage)
            : base(model, new Vector3(personage.Position.X, personage.Position.Z, personage.Position.Y))
        {
            this.personage = personage;
            personage.AddObserver(this);
            personage.AddObserverAnimationSkill(this);
        }

        public override void Update()
        {
            personage.Update();

            base.Update();
        }

        public Personage Personage
        {
            get { return personage; }
        }

        public void UpdateMove(Vector traslation)
        {
            position = new Vector3(personage.Position.X, personage.Position.Z, personage.Position.Y);
        }

        public void UpdateRotate(float rotate)
        {
            rotation.X = rotate;
        }

        public void UpdateAnimationSkill(ISkill skill)
        {
            //if (skill is Cholera)
            //    Sounds.Electro.CreateInstance().Play(); //test

            //if (skill is OffensiveSkill)
            //    Sounds.Button.CreateInstance().Play(); //test
        }
    }
}
