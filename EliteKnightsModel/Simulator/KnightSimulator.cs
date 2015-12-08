using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel.Characters;
using System.Threading;
using EliteKnightsModel.Boots;

namespace EliteKnightsModel.Simulator
{
    class KnightSimulator : Knight
    {
        private ISimulator simulator;
        private IAttackCharacter target;
        private Time time;

        public KnightSimulator(string name, Vector position, int level, int battlesWon, int battlesPlay)
            : base(name, position, level, battlesWon, battlesPlay)
        {
            time = new Time();

            InitializeSimulator();
        }

        private void InitializeSimulator()
        {
            if (level < 2)
                simulator = new Simulator1(this);
            else
            if (level < 4)
                simulator = new Simulator2(this);
            else
            if (level < 5)
                simulator = new Simulator3(this);
            else
            if (level < 6)
                simulator = new Simulator4(this);
            else
            if (level < 7)
                simulator = new Simulator5(this);
            else
            if (level < 8)
                simulator = new Simulator6(this);
            else
            if (level < 9)
                simulator = new Simulator7(this);
            else
                simulator = new Simulator8(this);
        }

        public override void Update()
        {
            base.Update();

            if (state != State.Death)
            {
                if (attack)
                    simulator.SimulateAttack(target);

                SimulateMove();
            }
        }

        private void SimulateMove()
        {
            if (time.Completed())
                simulator.SimulateMove(target);
            else
                time.Sleep(1);
        }

        public IAttackCharacter Target
        {
            set { target = value; }
        }
    }
}
