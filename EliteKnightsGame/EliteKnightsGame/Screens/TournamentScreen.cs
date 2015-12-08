using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsGame.Interface;

namespace EliteKnightsGame.Screens
{
    class TournamentScreen : Screen
    {
        public TournamentScreen(GameLoop game)
            : base(game)
        { }

        public override void Initialize()
        {
            int posX = BasicWindow.PositionXButtonOption;
            int posY = BasicWindow.PositionYButtonOption;
            int i = BasicWindow.ButtonOptionHeight + 20;

            buttons.Add(new ButtonOption(posX, posY, "PARTICIPAR", Join));
            buttons.Add(new ButtonOption(posX, posY + i * 5, "ATRAS", Back));
        }

        private void Join()
        { }
    }
}
