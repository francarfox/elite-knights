using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsModel;
using EliteKnightsGame.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EliteKnightsGame.Interface
{
    class Log : IObserverMessage
    {
        private static int countMax = 1000;
        private static string red = "red";

        private int linesMax;
        private string messageOther;
        private Vector2 position;
        private List<string> log;

        private Time time;

        public Log(IObservableMessage observable)
        {
            observable.AddObserver(this);
            linesMax = 20;

            messageOther = "";
            position = new Vector2(BasicWindow.SpaceLade, BasicWindow.PositionYLog);
            log = new List<string>();

            time = new Time();
        }

        public void Update()
        {
            if (time.Completed())
                messageOther = "";
            else
                time.Sleep(General.Second * 3);
        }

        public void Draw()
        {
            if (log.Count < linesMax)
                DrawMessageNormal();
            else
                DrawMessageMax();

            GameLoop.DrawText(Fonts.Arial, messageOther, BasicWindow.RectangleLogOther, Color.Red);
        }

        private void DrawMessageNormal()
        {
            string space = "";

            for (int i = 0; i < log.Count; i++)
            {
                Color color = Color.Orange;
                string line = log[i];

                if (line.Contains(red))
                {
                    line = line.Remove(0, red.Length);
                    color = Color.Red;
                }

                GameLoop.DrawText(Fonts.Small, space + line, position, color);
                space += "\n";
            }
        }

        private void DrawMessageMax()
        {
            string space = "";

            for (int i = log.Count - linesMax; i < log.Count; i++)
            {
                Color color = Color.Orange;
                string line = log[i];

                if (line.Contains(red))
                {
                    line = line.Remove(0, red.Length);
                    color = Color.Red;
                }

                GameLoop.DrawText(Fonts.Small, space + line, position, color);
                space += "\n";
            }
        }

        public void UpdateMessageSkill(string message)
        {
            if (log.Count > countMax)
                log.Remove(log[0]);

            log.Add(message);
        }

        public void UpdateMessageOther(string message)
        {
            this.messageOther = message;
        }

        public void UpdateMessageDamage(string message)
        {
            if (log.Count > countMax)
                log.Remove(log[0]);

            log.Add(red + message);
        }
    }
}
