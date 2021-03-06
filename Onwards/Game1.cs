﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Onwards.GameStates;
using Onwards.Components;
using Onwards.StateManager;

namespace Onwards
{
    public class Game1 : Game
    {
        #region Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameStateManager gameStateManager;

        ITitleScreenState titleScreenState;
        IMainMenuState mainMenuState;

        static Rectangle screenRectangle;
        #endregion

        #region Properties

        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }

        public static Rectangle ScreenRectangle
        {
            get { return screenRectangle; }
        }

        public ITitleScreenState TitleScreenState
        {
            get { return titleScreenState; }
        }

        public IMainMenuState MainMenuState
        {
            get { return mainMenuState; }
        }

        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            screenRectangle = new Rectangle(0, 0, 1280, 720);

            graphics.PreferredBackBufferWidth = screenRectangle.Width;
            graphics.PreferredBackBufferHeight = screenRectangle.Height;

            gameStateManager = new GameStateManager(this);
            Components.Add(gameStateManager);

            titleScreenState = new TitleScreenState(this);
            mainMenuState = new MainMenuState(this);

            gameStateManager.ChangeState((TitleScreenState)titleScreenState, PlayerIndex.One);
        }

        protected override void Initialize()
        {
            Components.Add(new InputHandler(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
          
        }

        protected override void Update(GameTime gameTime)
        {
            if (InputHandler.KeyPressed(Keys.Escape) || InputHandler.ButtonPressed(Buttons.Back, PlayerIndex.One))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
