using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Onwards.Components
{
    public class BaseMenu
    {
        #region Fields

        SpriteFont menuFont;
        Texture2D menuTexture;

        readonly List<string> menuItems = new List<string>();
        int selectedIndex = -1;

        Color baseColour = Color.DarkSlateGray;
        Color highlightColour = Color.LightGray;

        int width;
        int height;

        Vector2 position;

        #endregion

        #region Properties

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Color BaseColour
        {
            get { return baseColour; }
            set { baseColour = value; }
        }

        public Color HighLightColour
        {
            get { return highlightColour; }
            set { highlightColour = value; }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = (int)MathHelper.Clamp(
                                value, 0, menuItems.Count - 1);
            }
        }

        #endregion

        #region Constructors

        public BaseMenu(SpriteFont menuFont, Texture2D menuTexture)
        {
            this.menuFont = menuFont;
            this.menuTexture = menuTexture;
        }

        public BaseMenu(SpriteFont menuFont, Texture2D menuTexture, string[] menuItems)
            : this(menuFont, menuTexture)
        {
            selectedIndex = 0;

            foreach (string s in menuItems)
            {
                this.menuItems.Add(s);
            }

            MeasureMenu();
        }

        #endregion

        #region Methods

        private void SetMenuItems(String[] items)
        {
            menuItems.Clear();
            menuItems.AddRange(items);
            MeasureMenu();

            selectedIndex = 0;
        }

        private void MeasureMenu()
        {
            width = menuTexture.Width;
            height = 0;

            foreach (string s in menuItems)
            {
                Vector2 size = menuFont.MeasureString(s);

                if (size.X > width)
                {
                    width = (int)size.X;
                    height += menuTexture.Height;
                }

                height -= 50;
            }
        }

        public void Update(GameTime gameTime, PlayerIndex index)
        {
            if (InputHandler.KeyPressed(Keys.Up) || InputHandler.ButtonPressed(Buttons.DPadUp, index))
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = 0;
                }
            }
            else if (InputHandler.KeyPressed(Keys.Down) || InputHandler.ButtonPressed(Buttons.DPadDown, index))
            {
                selectedIndex++;
                {
                    if (selectedIndex > menuItems.Count - 1)
                    {
                        selectedIndex = menuItems.Count - 1;
                    }
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 menuPosition = position;
            Color myColour;

            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == selectedIndex)
                {
                    myColour = highlightColour;
                }
                else
                {
                    myColour = baseColour;
                }

                spriteBatch.Draw(menuTexture, menuPosition, Color.White);

                Vector2 textSize = menuFont.MeasureString(menuItems[i]);

                Vector2 textPosition = menuPosition + new Vector2((int)(menuTexture.Width -
                                       textSize.X) / 2, (int)(menuTexture.Height - textSize.Y) / 2);

                spriteBatch.DrawString(menuFont, menuItems[i], textPosition, myColour);

                menuPosition.Y += menuTexture.Height + 50;
            }
        }
        #endregion
    }
}
