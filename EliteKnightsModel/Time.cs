using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteKnightsModel
{
    public class Time
    {

        private int totalTime;
        private int currentTime;

        public Time()
        {
            totalTime = General.Second;
            currentTime = totalTime;
        }

        public void Sleep(int time)
        {
            totalTime = time;
            currentTime++;
        }

        public void Sleep()
        {
            Sleep(General.Second);
        }

        public bool Completed()
        {
            bool completed = false;

            if (currentTime >= totalTime)
            {
                currentTime = 0;
                completed = true;
            }

            return completed;
        }

    }
}
