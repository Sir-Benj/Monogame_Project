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
    public class MenuCore
    {
        SpriteFont menuFont;
        readonly List<string> menuItems = new List<string>();
        int selectedIndex = -1;

        Color baseColour = Color.DarkSlateGray;
        Color highlightColour = Color.LightGray;

        Texture2D menuTexture;
    }
}
