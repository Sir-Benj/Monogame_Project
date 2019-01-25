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
    }
}
