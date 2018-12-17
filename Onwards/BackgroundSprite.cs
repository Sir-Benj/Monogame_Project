using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Onwards
{
    public class BackgroundSprite
    {
        public Texture2D backgroundImage;
        public Vector2 pos;

        public BackgroundSprite(Texture2D imageIn)
        {
            backgroundImage = imageIn;
            pos = new Vector2(0, 0);
        }
    }
}
