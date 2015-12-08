using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsGame.Resources;
using Microsoft.Xna.Framework;
using EliteKnightsGame.Interface;
using Microsoft.Xna.Framework.Input;
using EliteKnightsModel.Characters;
using EliteKnightsModel;
using EliteKnightsGame.Gameplay;

namespace EliteKnightsGame.Screens
{
    class GameScreen : IScreen
    {
        private GameLoop game;
        private Core core;
        //private Cursor cursor;

        public GameScreen(GameLoop game)
        {
            this.game = game;
            game.IsMouseVisible = true;
            core = new Core(game.Memory);
            //cursor = Cursor.Instance;
        }

        public void Initialize()
        {
            core.Initialize();
            core.Start();
        }

        public void Update()
        {
            KeyboardState kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.Escape))
                Back();

            core.Update();
            //cursor.Update();
        }

        public void Draw()
        {
            core.Draw();
            //cursor.Draw();
        }

        private void Back()
        {
            game.SetScreen(new MenuScreen(game));
        }
    }
}
