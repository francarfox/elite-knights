using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteKnightsGame.Interface;
using EliteKnightsGame.Resources;
using Microsoft.Xna.Framework;
using EliteKnightsModel.Persistence;

namespace EliteKnightsGame.Screens
{
    abstract class Screen : IScreen
    {
        protected GameLoop game;
        protected Profile profile;
        protected List<ButtonOption> buttons;

        public Screen(GameLoop game)
        {
            this.game = game;
            profile = game.Memory.Profile;
            buttons = new List<ButtonOption>();
        }

        public abstract void Initialize();

        public virtual void Update()
        {
            foreach (ButtonOption button in buttons)
                button.Update();
        }

        public virtual void Draw()
        {
            GameLoop.Draw(Images.Presentation, game.WindowSize, Color.White);

            Vector2 position = new Vector2(BasicWindow.SpaceLade, BasicWindow.SpaceLade);
            GameLoop.DrawText(Fonts.Arial, profile.Name, position, Color.White);

            foreach (ButtonOption button in buttons)
                button.Draw();
        }

        protected virtual void Back()
        {
            game.SetScreen(new MenuScreen(game));
        }
    }
}
