using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace EliteKnightsGame
{
    abstract class KeyboardGame
    {
        public static Keys Up = Keys.W;
        public static Keys Down = Keys.S;
        public static Keys Right = Keys.D;
        public static Keys Left = Keys.A;
        public static Keys RotateRight = Keys.E;
        public static Keys RotateLeft = Keys.Q;

        public static Keys Skill1 = Keys.D1;
        public static Keys Skill2 = Keys.D2;
        public static Keys Skill3 = Keys.D3;
        public static Keys Skill4 = Keys.D4;
        public static Keys Skill5 = Keys.D5;
        public static Keys Skill6 = Keys.D6;
        public static Keys Skill7 = Keys.D7;
        public static Keys Skill8 = Keys.D8;
        public static Keys Skill9 = Keys.D9;
        public static Keys Skill0 = Keys.D0;

        private static List<Keys> chars = new List<Keys>();
        private static List<Keys> numbers = new List<Keys>();

        public static void Initialize()
        {
            chars.Add(Keys.A);
            chars.Add(Keys.B);
            chars.Add(Keys.C);
            chars.Add(Keys.D);
            chars.Add(Keys.E);
            chars.Add(Keys.F);
            chars.Add(Keys.G);
            chars.Add(Keys.H);
            chars.Add(Keys.I);
            chars.Add(Keys.J);
            chars.Add(Keys.K);
            chars.Add(Keys.L);
            chars.Add(Keys.M);
            chars.Add(Keys.N);
            chars.Add(Keys.O);
            chars.Add(Keys.P);
            chars.Add(Keys.Q);
            chars.Add(Keys.R);
            chars.Add(Keys.S);
            chars.Add(Keys.T);
            chars.Add(Keys.U);
            chars.Add(Keys.V);
            chars.Add(Keys.W);
            chars.Add(Keys.X);
            chars.Add(Keys.Y);
            chars.Add(Keys.Z);

            numbers.Add(Keys.D1);   //mejorar xq se imprime D1 y no 1
            numbers.Add(Keys.D2);
            numbers.Add(Keys.D3);
            numbers.Add(Keys.D4);
            numbers.Add(Keys.D5);
            numbers.Add(Keys.D6);
            numbers.Add(Keys.D7);
            numbers.Add(Keys.D8);
            numbers.Add(Keys.D9);
            numbers.Add(Keys.D0);
            numbers.Add(Keys.OemPeriod);    //. point
        }

        public static bool IsChar(Keys key)
        {
            return chars.Contains(key);
        }

        public static bool IsNumber(Keys key)
        {
            return numbers.Contains(key);
        }
    }
}
