using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsGame.Interface;

namespace EliteKnightsGame.Screens
{
    class OptionsScreen : Screen
    {
        public OptionsScreen(GameLoop game)
            : base(game)
        { }

        public override void Initialize()
        {
            int posX = BasicWindow.PositionXButtonOption;
            int posY = BasicWindow.PositionYButtonOption;
            int i = BasicWindow.ButtonOptionHeight + 20;

            buttons.Add(new ButtonOption(posX, posY, "PERFILES", Profiles));
            buttons.Add(new ButtonOption(posX, posY + i, "AYUDA", Help));
            buttons.Add(new ButtonOption(posX, posY + i * 2, "FULL SCREEN", FullScreen));
            buttons.Add(new ButtonOption(posX, posY + i * 5, "ATRAS", Back));
        }

        private void Profiles()
        {
            game.SetScreen(new ProfilesScreen(game));
        }

        private void Help()
        { }

        public void FullScreen()
        {
            game.FullScreen();
        }
    }
}
