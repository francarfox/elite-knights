using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace EliteKnightsGame.Resources
{
    abstract class Images
    {
        public static Texture2D None;

        public static Texture2D Attack;
        public static Texture2D Meditation;
        public static Texture2D Court;
        public static Texture2D Immune;
        public static Texture2D Courage;
        public static Texture2D Blindage;
        public static Texture2D Winged;
        public static Texture2D Fury;
        public static Texture2D Ire;
        public static Texture2D Cholera;

        public static Texture2D Map;
        public static Texture2D Cursor;
        public static Texture2D ButtonImage;
        public static Texture2D Account;
        public static Texture2D Presentation;

        public static void LoadContent(ContentManager Content)
        {
            None = LoadImageSkill(Content, "none");
            Attack = LoadImageSkill(Content, "attack");
            Meditation = LoadImageSkill(Content, "meditation");
            Court = LoadImageSkill(Content, "court");
            Immune = LoadImageSkill(Content, "immune");
            Courage = LoadImageSkill(Content, "courage");
            Blindage = LoadImageSkill(Content, "blindage");
            Winged = LoadImageSkill(Content, "winged");
            Fury = LoadImageSkill(Content, "fury");
            Ire = LoadImageSkill(Content, "ire");
            Cholera = LoadImageSkill(Content, "cholera");

            Map = LoadImage(Content, "map");
            Cursor = LoadImage(Content, "cursor");
            ButtonImage = LoadImage(Content, "button");
            Account = LoadImage(Content, "account");
            Presentation = LoadImage(Content, "presentation");

            CreatorImageSkill.LoadContent();
        }

        private static Texture2D LoadImageSkill(ContentManager content, string path)
        {
            return content.Load<Texture2D>("Images\\Skills\\" + path);
        }

        private static Texture2D LoadImage(ContentManager content, string path)
        {
            return content.Load<Texture2D>("Images\\" + path);
        }
    }
}
