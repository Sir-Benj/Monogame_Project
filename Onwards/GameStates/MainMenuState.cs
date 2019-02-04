using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Onwards.StateManager;
using Onwards.Components;

namespace Onwards.GameStates
{
    public interface IMainMenuState : IGameState
    {

    }

    public class MainMenuState : BaseGameState, IMainMenuState
    {
        #region Fields

        Texture2D bgMountains;
        Texture2D bgMountainsFollow;
        Texture2D bgTitle;
        Texture2D bgClouds;
        Texture2D bgCloudsFollow;
        Rectangle bgMountDest;
        Rectangle bgCloudDest;
        Rectangle bgFollowMount;
        Rectangle bgFollowCloud;
        SpriteFont menuFont;
        TimeSpan elapsed;
        BaseMenu menuMain;

        #endregion

        #region Constructor

        public MainMenuState(Game game)
            :base(game)
        {
            game.Services.AddService(typeof(IMainMenuState), this);
        }

        #endregion

        #region Methods

        public override void Initialize()
        {
            bgMountDest = GameRef.TitleScreenState.BGMountDest;
            bgFollowMount = GameRef.TitleScreenState.BGFollowMount;

            bgCloudDest = GameRef.TitleScreenState.BGCloudDest;
            bgFollowCloud = GameRef.TitleScreenState.BGFollowCloud;

            elapsed = TimeSpan.Zero;
 
            base.Initialize();
        }

        protected override void LoadContent()
        {
            bgMountains = content.Load<Texture2D>("TitleScreen/TitleMountains");
            bgMountainsFollow = bgMountains;
            bgClouds = content.Load<Texture2D>("TitleScreen/TitleClouds");
            bgCloudsFollow = bgClouds;

            menuFont = content.Load<SpriteFont>("Fonts/Title");

            Texture2D menuTexture = content.Load<Texture2D>("TitleScreen/MainMenu");

            string[] menuItems = { "NEW GAME", "CONTINUE", "OPTIONS", "EXIT" };

            menuMain = new BaseMenu(menuFont, menuTexture, menuItems);

            Vector2 position = new Vector2();

            position.Y = 20;
            position.X = Game1.ScreenRectangle.Width - menuMain.Width;

            menuMain.Position = position;

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            elapsed += gameTime.ElapsedGameTime;

            menuMain.Update(gameTime, PlayerIndex.One);
            System.Console.WriteLine(menuMain.SelectedIndex);

            if (InputHandler.KeyPressed(Keys.Enter) || InputHandler.ButtonReleased(Buttons.A, PlayerIndex.One))
            {
                if (menuMain.SelectedIndex == 0)
                {
                    InputHandler.FlushInput();
                }
                else if (menuMain.SelectedIndex == 1)
                {
                    InputHandler.FlushInput();
                }
                else if (menuMain.SelectedIndex == 2)
                {
                    InputHandler.FlushInput();
                }
                else if (menuMain.SelectedIndex == 3)
                {
                    Game.Exit();
                }
            }

            bgMountDest.X -= 1;
            bgFollowMount.X -= 1;

            if (bgMountDest.X <= -bgMountains.Width)
            {
                bgMountDest.X = 0;
                bgFollowMount.X = bgMountains.Width;
            }

            bgCloudDest.X -= 2;
            bgFollowCloud.X -= 2;

            if (bgCloudDest.X <= -bgClouds.Width)
            {
                bgCloudDest.X = 0;
                bgFollowCloud.X = bgClouds.Width;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            GameRef.SpriteBatch.Draw(bgMountains, bgMountDest, Color.White);
            GameRef.SpriteBatch.Draw(bgMountainsFollow, bgFollowMount, Color.White);
            GameRef.SpriteBatch.Draw(bgClouds, bgCloudDest, Color.White);
            GameRef.SpriteBatch.Draw(bgCloudsFollow, bgFollowCloud, Color.White);

            GameRef.SpriteBatch.End();

            base.Draw(gameTime);

            GameRef.SpriteBatch.Begin();
            menuMain.Draw(gameTime, GameRef.SpriteBatch);
            GameRef.SpriteBatch.End();
        }
        #endregion
    }


}
