using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace EliteKnightsGame.Resources
{
    abstract class Sounds
    {
        public static SoundEffect Button;
        public static SoundEffect Electro;

        public static void LoadContent(ContentManager Content)
        {
            Button = LoadSound(Content, "button");
            Electro = LoadSound(Content, "electro");
        }

        private static SoundEffect LoadSound(ContentManager content, string path)
        {
            return content.Load<SoundEffect>("Sounds\\" + path);
        }
    }
}
