using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsGame.Interface;
using EliteKnightsGame.Resources;

namespace EliteKnightsGame.Screens
{
    class MenuScreen : Screen
    {
        public MenuScreen(GameLoop game)
            : base(game)
        {
            game.IsMouseVisible = true;
        }

        public override void Initialize()
        {
            int posX = BasicWindow.PositionXButtonOption;
            int posY = BasicWindow.PositionYButtonOption;
            int i = BasicWindow.ButtonOptionHeight + 20;

            buttons.Add(new ButtonOption(posX, posY, "JUGAR", Game));
            buttons.Add(new ButtonOption(posX, posY + i, "TORNEOS", Tournaments));
            buttons.Add(new ButtonOption(posX, posY + i * 2, "ONLINE", Online));
            buttons.Add(new ButtonOption(posX, posY + i * 3, "RANKING", Ranking));
            buttons.Add(new ButtonOption(posX, posY + i * 4, "OPCIONES", Options));
            buttons.Add(new ButtonOption(posX, posY + i * 5, "SALIR", Exit));
        }

        public void Game()
        {
            Models.LoadContent(game.Content);
            game.SetScreen(new GameScreen(game));
        }

        public void Tournaments()
        {
            game.SetScreen(new TournamentScreen(game));
        }

        public void Online()
        {
            game.SetScreen(new OnlineScreen(game));
        }

        public void Ranking()
        {
            game.SetScreen(new RankingScreen(game));
        }

        public void Options()
        {
            game.SetScreen(new OptionsScreen(game));
        }

        public void Exit()
        {
            game.Memory.Save();
            game.Exit();
        }
    }
}
