using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsGame.Interface;
using EliteKnightsGame.Resources;
using Microsoft.Xna.Framework;
using EliteKnightsModel.Persistence;
using EliteKnightsModel;

namespace EliteKnightsGame.Screens
{
    class AccountScreen : Screen
    {
        private string nameProfile, message;
        private TextBox textBoxName;

        public AccountScreen(GameLoop game)
            : base(game)
        {
            nameProfile = "NOMBRE DE PERFIL:";
            message = "Ingresa tu nombre de perfil o crealo aqui.";
            game.IsMouseVisible = true;
        }

        public override void Initialize()
        {
            KeyboardGame.Initialize();

            textBoxName = new TextBox(60, 50);
            buttons.Add(new ButtonOption(55, 100, "ENTRAR", Enter));
            buttons.Add(new ButtonOption(55, 160, "CREAR", Create));
        }

        public override void Update()
        {
            textBoxName.Update();

            base.Update();
        }

        public override void Draw()
        {
            GameLoop.Draw(Images.Account, new Vector2(0, 0), Color.White);

            GameLoop.DrawText(Fonts.Arial, nameProfile, new Vector2(30, 10), Color.White);
            GameLoop.DrawText(Fonts.Small, message, new Vector2(30, 220), Color.White);

            textBoxName.Draw();

            foreach (ButtonOption button in buttons)
                button.Draw();
        }

        public void Enter()
        {
            if (!textBoxName.Selected() && VerifyNameProfile())
            {
                game.FullScreen();
                game.SetScreen(new MenuScreen(game));
            }
        }

        public void Create()
        {
            if (!textBoxName.Selected())
            {
                ProcessNameProfile();

                game.FullScreen();
                game.SetScreen(new MenuScreen(game));
            }
        }

        private void ProcessNameProfile()
        {
            game.Memory.Reset(textBoxName.Text);
        }

        private bool VerifyNameProfile()
        {
            bool verify = false;

            if (textBoxName.Text == profile.Name)
                verify = true;

            return verify;
        }
    }
}
