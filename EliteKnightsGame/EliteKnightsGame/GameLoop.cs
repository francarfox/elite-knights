using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using EliteKnightsGame.Resources;
using EliteKnightsGame.Screens;
using System.Threading;
using EliteKnightsModel;

namespace EliteKnightsGame
{
    public class GameLoop : Game
    {
        private static MouseState oldMouse;
        private static KeyboardState oldKey;

        private static GraphicsDeviceManager graphics;
        private static SpriteBatch spriteBatch;

        private Rectangle windowSize;
        private DisplayMode display;
        private IScreen currentScreen;
        private Memory memory;
        
        public GameLoop()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            windowSize = new Rectangle(0, 0, 900, 600);
            display = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
            memory = new Memory();  //model
        }

        protected override void Initialize()
        {
            Window.Title = "Elite Knights - Alpha";

            //graphics.PreferredBackBufferWidth = BasicWindow.AccountWidth;   //debe ir en el initialize de accountScreen
            //graphics.PreferredBackBufferHeight = BasicWindow.AccountHeight;
            //graphics.ApplyChanges();

            graphics.PreferredBackBufferWidth = windowSize.Width;
            graphics.PreferredBackBufferHeight = windowSize.Height;
            graphics.ApplyChanges();

            //FullScreen();

            BasicWindow.Initialize(windowSize);
            memory.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Canvas.Initialize();
            Fonts.LoadContent(Content);
            Images.LoadContent(Content);
            Sounds.LoadContent(Content);

            SetScreen(new MenuScreen(this)); //test
        }

        protected override void UnloadContent()
        { }

        protected override void Update(GameTime gameTime)
        {
            currentScreen.Update();

            oldMouse = Mouse.GetState();
            oldKey = Keyboard.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            spriteBatch.Begin();
            currentScreen.Draw();
            spriteBatch.End();

            Thread.Sleep(15);
            base.Draw(gameTime);
        }

        public void SetScreen(IScreen screen)
        {
            currentScreen = screen;
            currentScreen.Initialize();
        }

        public static void Draw(Texture2D image, Rectangle rectangle, Color color)
        {
            spriteBatch.Draw(image, rectangle, color);
        }

        public static void Draw(Texture2D image, Vector2 position, Color color)
        {
            spriteBatch.Draw(image, position, color);
        }

        public static void DrawText(SpriteFont font, string text, Vector2 position, Color color)
        {
            spriteBatch.DrawString(font, text, position, color);
        }

        public static void DrawText(SpriteFont font, string text, Rectangle rectangle, Color color)
        {
            float posTextX = rectangle.X + (rectangle.Width - font.MeasureString(text).X) / 2;
            float posTextY = rectangle.Y + (rectangle.Height - font.MeasureString(text).Y) / 2;

            DrawText(font, text, new Vector2(posTextX, posTextY), color);
        }

        public void FullScreen()
        {
            windowSize = new Rectangle(0, 0, display.Width, display.Height);
            BasicWindow.Initialize(windowSize);

            graphics.PreferredBackBufferWidth = windowSize.Width;
            graphics.PreferredBackBufferHeight = windowSize.Height;
            graphics.ToggleFullScreen();
            graphics.ApplyChanges();
        }

        public static MouseState OldMouse
        {
            get { return oldMouse; }
        }

        public static KeyboardState OldKey
        {
            get { return oldKey; }
        }

        public static GraphicsDevice Device
        {
            get { return graphics.GraphicsDevice; }
        }

        public Rectangle WindowSize
        {
            get { return windowSize; }
        }

        public Memory Memory
        {
            get { return memory; }
        }
    }
}
