using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using EliteKnightsModel.Skills;

namespace EliteKnightsGame.Resources
{
    abstract class CreatorImageSkill
    {
        private static Dictionary<Type, Texture2D> images = new Dictionary<Type, Texture2D>();

        public static void LoadContent()
        {
            images.Add(typeof(NoneSkill), Images.None);
            images.Add(typeof(Attack), Images.Attack);
            images.Add(typeof(Meditation), Images.Meditation);
            images.Add(typeof(Court), Images.Court);
            images.Add(typeof(Immune), Images.Immune);
            images.Add(typeof(Courage), Images.Courage);
            images.Add(typeof(Blindage), Images.Blindage);
            images.Add(typeof(Winged), Images.Winged);
            images.Add(typeof(Fury), Images.Fury);
            images.Add(typeof(Ire), Images.Ire);
            images.Add(typeof(Cholera), Images.Cholera);
        }

        public static Texture2D View(ISkill skill)
        {
            return images[skill.GetType()];
        }
    }
}
