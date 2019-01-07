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

namespace Onwards.GameStates
{
    public interface ITitleScreenState : IGameState
    {

    }
    public class TitleScreenState : BaseGameState, ITitleScreenState
    {
        #region Fields

        Texture2D bgMountains;
        Texture2D bgMountainsFollow;
        Texture2D bgTitle;
        Texture2D bgClouds;
        Texture2D bgCloudsFollow;
        Rectangle bgTitleDest;
        Rectangle bgMountDest; 
        Rectangle bgCloudDest;
        Rectangle bgFollowMount;
        Rectangle bgFollowCloud;
        SpriteFont font;
        TimeSpan elapsed;
        Vector2 position;
        string message;

        #endregion

        #region Constructor

        public TitleScreenState(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(ITitleScreenState), this);
        }

        #endregion

        #region XNA Methods

        public override void Initialize()
        {
            bgTitleDest = Game1.ScreenRectangle;

            bgMountDest = Game1.ScreenRectangle;
            bgFollowMount = Game1.ScreenRectangle;
            bgFollowMount.X = Game1.ScreenRectangle.Width;

            bgCloudDest = Game1.ScreenRectangle;
            bgFollowCloud = Game1.ScreenRectangle;
            bgFollowCloud.X = Game1.ScreenRectangle.Width;

            elapsed = TimeSpan.Zero;
            message = "PRESS A BUTTON OR SPACEBAR";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            bgMountains = content.Load<Texture2D>("TitleScreen/TitleMountains");
            bgMountainsFollow = bgMountains;
            bgClouds = content.Load<Texture2D>("TitleScreen/TitleClouds");
            bgCloudsFollow = bgClouds;
            bgTitle = content.Load<Texture2D>("TitleScreen/TitleName");

            font = content.Load<SpriteFont>("Fonts/Title");

            Vector2 size = font.MeasureString(message);
            position = new Vector2((Game1.ScreenRectangle.Width - size.X) / 2,
                       (Game1.ScreenRectangle.Bottom - 50 - font.LineSpacing));

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            PlayerIndex index = PlayerIndex.One;
            elapsed += gameTime.ElapsedGameTime;

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
            GameRef.SpriteBatch.Draw(bgTitle, bgTitleDest, Color.White);

            Color colour = new Color(0f, 0f, 0f, 255f) * 
                                    (float)Math.Abs(Math.Sin(elapsed.TotalSeconds * 2));

            GameRef.SpriteBatch.DrawString(font, message, position, colour);

            GameRef.SpriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion
    }
}
