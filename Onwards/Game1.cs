using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Onwards
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static ContentManager myContent;
        BackgroundSpriteManager bgManager;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            myContent = Content;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            bgManager = new BackgroundSpriteManager();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bgManager.LoadForestContent();
        }

        protected override void UnloadContent()
        {
          
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            bgManager.DrawBGSprites(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
