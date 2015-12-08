using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;

namespace EliteKnightsModel.Simulator
{
    abstract class Simulator : ISimulator
    {
        protected KnightSimulator character;
        protected string message;

        public Simulator(AttackCharacter character)
        {
            this.character = (KnightSimulator)character;
            character.AddObserver(this);
        }

        public abstract void SimulateAttack(IAttackCharacter target);

        public void SimulateMove(IAttackCharacter target)
        {
            if (character.IsNear(target))
                MoveAway(target);
            else
                MoveNear(target);
        }

        public void SimulateImmune(IAttackCharacter target)
        {
            if (character.Health < character.CalculateHealth() / 2)
            {
                character.ActivateSkill(Names.Immune, target);

                if (message == Messages.IsReload || message == Messages.NoEnergy)
                {
                    character.ActivateSkill(Names.Winged, target);

                    if (message == Messages.IsReload || message == Messages.NoEnergy)
                    {
                        character.ActivateSkill(Names.Meditation, target);
                    }
                }
            }
        }

        private void MoveNear(IAttackCharacter target)
        {
            Vector direction = target.Position.Diference(character.Position);
            direction.Normalize();
            //rotate
            character.Move(direction);
        }

        private void MoveAway(IAttackCharacter target)
        {
            Vector direction = target.Position.Diference(character.Position);
            direction.Normalize();
            //rotate
            character.Move(direction.Product(-1));
        }

        public void UpdateMessageSkill(string message)
        {
            this.message = message;
        }

        public void UpdateMessageOther(string message)
        {
            this.message = message;
        }

        public void UpdateMessageDamage(string message)
        {
            this.message = message;
        }
    }
}
