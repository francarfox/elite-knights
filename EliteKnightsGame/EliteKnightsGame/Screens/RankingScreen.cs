using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsGame.Interface;
using EliteKnightsModel;
using EliteKnightsModel.Characters;
using EliteKnightsGame.Resources;
using Microsoft.Xna.Framework;

namespace EliteKnightsGame.Screens
{
    class RankingScreen : Screen
    {
        private Personage myPersonage;
        private List<Personage> personages;

        public RankingScreen(GameLoop game)
            : base(game)
        {
            myPersonage = profile.MainPersonage;
            personages = game.Memory.Personages;
        }

        public override void Initialize()
        {
            int posX = BasicWindow.PositionXButtonOption;
            int posY = BasicWindow.PositionYButtonOption;
            int i = BasicWindow.ButtonOptionHeight + 20;

            buttons.Add(new ButtonOption(posX, posY, "RETAR", Battle));
            buttons.Add(new ButtonOption(posX, posY + i * 5, "ATRAS", Back));

            if (!personages.Contains(myPersonage))
                personages.Add(myPersonage);

            personages.Sort();
        }

        public override void Draw()
        {
            base.Draw();

            DrawRanking();
        }

        private void DrawRanking()  //bug sound button
        {
            string ranks = "Puesto \n\n";
            string names = "Nombre \n\n";
            string levels = "Nivel \n\n";
            string status = "Reputacion \n\n";

            for (int i = 0; i < ConstantGame.MaxRanking; i++)
            {
                Personage personage = personages[i];

                ranks += (i + 1) + "\n";
                names += personage.Name + "\n";
                levels += personage.Level + "\n";
                status += personage.Status + " %\n";
            }

            GameLoop.DrawText(Fonts.Arial, ranks, new Vector2(200, 60), Color.Red);
            GameLoop.DrawText(Fonts.Arial, names, new Vector2(300, 60), Color.Red);
            GameLoop.DrawText(Fonts.Arial, levels, new Vector2(420, 60), Color.Red);
            GameLoop.DrawText(Fonts.Arial, status, new Vector2(500, 60), Color.Red);
        }

        private void Battle()
        { }

        protected override void Back()
        {
            if (personages.Contains(myPersonage))
                personages.Remove(myPersonage);

            base.Back();
        }
    }
}
