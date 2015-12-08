﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsGame.Interface;

namespace EliteKnightsGame.Screens
{
    class ProfilesScreen : Screen
    {
        public ProfilesScreen(GameLoop game)
            : base(game)
        { }

        public override void Initialize()
        {
            int posX = BasicWindow.PositionXButtonOption;
            int posY = BasicWindow.PositionYButtonOption;
            int i = BasicWindow.ButtonOptionHeight + 20;

            buttons.Add(new ButtonOption(posX, posY, "CREAR", Create));
            buttons.Add(new ButtonOption(posX, posY + i, "REMOVER", Remove));
            buttons.Add(new ButtonOption(posX, posY + i * 5, "ATRAS", Back));
        }

        private void Create()
        { }

        private void Remove()
        { }

        protected override void Back()
        {
            game.SetScreen(new OptionsScreen(game));
        }
    }
}
