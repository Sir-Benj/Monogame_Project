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
    public class MapManager
    {
        //Textures
        Texture2D forestBackground,
                  fMOne,
                  fPOne, fPTwo,
                  fOneFore, fOneMid,
                  fTwoFore, fTwoMid,
                  fThreeFore, fThreeMid,
                  fFourFore, fFourMid,
                  fFiveFore, fFiveMid;

        //Texture lists for map backgrounds;
        List<Texture2D> fPath, fFore, fMid, fMountain, fBackground;

        public MapManager()
        {
            fPath = new List<Texture2D>();
            fFore = new List<Texture2D>();
            fMid = new List<Texture2D>();
            fMountain = new List<Texture2D>();
            fBackground = new List<Texture2D>();
        }

        public void LoadForestContent()
        {
            forestBackground = Game1.myContent.Load<Texture2D>("Forest/ForestBackground");
            fPOne = Game1.myContent.Load<Texture2D>("Forest/FBPOne");
            fPTwo = Game1.myContent.Load<Texture2D>("Forest/FBPTwo");
            fMOne = Game1.myContent.Load<Texture2D>("Forest/FBMOne");
            fOneFore = Game1.myContent.Load<Texture2D>("Forest/FBOneFore");
            fOneMid = Game1.myContent.Load<Texture2D>("Forest/FBOneMid");
            fTwoFore = Game1.myContent.Load<Texture2D>("Forest/FBTwoFore");
            fTwoMid = Game1.myContent.Load<Texture2D>("Forest/FBTwoMid");
            fThreeFore = Game1.myContent.Load<Texture2D>("Forest/FBThreeFore");
            fThreeMid = Game1.myContent.Load<Texture2D>("Forest/FBThreeMid");
            fFourFore = Game1.myContent.Load<Texture2D>("Forest/FBFourFore");
            fFourMid = Game1.myContent.Load<Texture2D>("Forest/FBFourMid");
            fFiveFore = Game1.myContent.Load<Texture2D>("Forest/FBFiveFore");
            fFiveMid = Game1.myContent.Load<Texture2D>("Forest/FBFiveMid");

            //Forest Path Load List
            fPath.Add(fPOne);
            fPath.Add(fPTwo);
            //Forest Foreground Load List
            fFore.Add(fOneFore);
            fFore.Add(fTwoFore);
            fFore.Add(fThreeFore);
            fFore.Add(fFourFore);
            fFore.Add(fFiveFore);
            //Forest Midground Load List
            fMid.Add(fOneMid);
            fMid.Add(fTwoMid);
            fMid.Add(fThreeMid);
            fMid.Add(fFourMid);
            fMid.Add(fFiveMid);
            //Forest Mountain Load List
            fMountain.Add(fMOne);
            //Forest Background Load List
            fBackground.Add(forestBackground);
        }

        public void UpdateMap()
        {

        }

        public void DrawMap(SpriteBatch spriteBatch)
        {

        }
    }
}
