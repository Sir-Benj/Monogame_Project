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
    public class BackgroundSpriteManager
    {
        //Textures
        private static Texture2D fBackTex,
                                 fMOneTex,
                                 fPOneTex, fPTwoTex,
                                 fOneForeTex, fOneMidTex,
                                 fTwoForeTex, fTwoMidTex,
                                 fThreeForeTex, fThreeMidTex,
                                 fFourForeTex, fFourMidTex,
                                 fFiveForeTex, fFiveMidTex;

        public static BackgroundSprite fBack,
                                       fMOne,
                                       fPOne, fPTwo,
                                       fOneFore, fOneMid,
                                       fTwoFore, fTwoMid,
                                       fThreeFore, fThreeMid,
                                       fFourFore, fFourMid,
                                       fFiveFore, fFiveMid;

        //Texture lists for map backgrounds;
        public static List<BackgroundSprite> fPath, fFore, fMid, fMountain, fBackground;

        public static List<List<BackgroundSprite>> backgroundSprites;

        public BackgroundSpriteManager()
        {
            backgroundSprites = new List<List<BackgroundSprite>>();
            fPath = new List<BackgroundSprite>();
            fFore = new List<BackgroundSprite>();
            fMid = new List<BackgroundSprite>();
            fMountain = new List<BackgroundSprite>();
            fBackground = new List<BackgroundSprite>();
        }

        public void LoadForestContent()
        {
            fBackTex = Game1.myContent.Load<Texture2D>("Forest/ForestBackground");
            fPOneTex = Game1.myContent.Load<Texture2D>("Forest/FBPOne");
            fPTwoTex = Game1.myContent.Load<Texture2D>("Forest/FBPTwo");
            fMOneTex = Game1.myContent.Load<Texture2D>("Forest/FBMOne");
            fOneForeTex = Game1.myContent.Load<Texture2D>("Forest/FBOneFore");
            fOneMidTex = Game1.myContent.Load<Texture2D>("Forest/FBOneMid");
            fTwoForeTex = Game1.myContent.Load<Texture2D>("Forest/FBTwoFore");
            fTwoMidTex = Game1.myContent.Load<Texture2D>("Forest/FBTwoMid");
            fThreeForeTex = Game1.myContent.Load<Texture2D>("Forest/FBThreeFore");
            fThreeMidTex = Game1.myContent.Load<Texture2D>("Forest/FBThreeMid");
            fFourForeTex = Game1.myContent.Load<Texture2D>("Forest/FBFourFore");
            fFourMidTex = Game1.myContent.Load<Texture2D>("Forest/FBFourMid");
            fFiveForeTex = Game1.myContent.Load<Texture2D>("Forest/FBFiveFore");
            fFiveMidTex = Game1.myContent.Load<Texture2D>("Forest/FBFiveMid");

            fBack = new BackgroundSprite(fBackTex);
            fPOne = new BackgroundSprite(fPOneTex);
            fPTwo = new BackgroundSprite(fPTwoTex);
            fMOne = new BackgroundSprite(fMOneTex);
            fOneFore = new BackgroundSprite(fOneForeTex);
            fOneMid = new BackgroundSprite(fOneMidTex);
            fTwoFore = new BackgroundSprite(fTwoForeTex);
            fTwoMid = new BackgroundSprite(fTwoMidTex);
            fThreeFore = new BackgroundSprite(fThreeForeTex);
            fThreeMid = new BackgroundSprite(fThreeMidTex);
            fFourFore = new BackgroundSprite(fFourForeTex);
            fFourMid = new BackgroundSprite(fFourMidTex);
            fFiveFore = new BackgroundSprite(fFiveForeTex);
            fFiveMid = new BackgroundSprite(fFiveMidTex);

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
            fBackground.Add(fBack);

            backgroundSprites.Add(fBackground);
            backgroundSprites.Add(fMountain);
            backgroundSprites.Add(fMid);
            backgroundSprites.Add(fFore);
            backgroundSprites.Add(fPath);

            foreach (List<BackgroundSprite> sprites in backgroundSprites)
            {
                SetupSpritePos(sprites);
            }
        }

        private void SetupSpritePos(List<BackgroundSprite> bg)
        {
            Vector2 placement = new Vector2(0, 0);

            foreach (BackgroundSprite background in bg)
            {
                background.pos.X = 0f + placement.X;
                placement.X += background.backgroundImage.Width;
            }
        }

        public void UpdateMap()
        {
           
        }

        public void DrawBGSprites(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
            foreach (List<BackgroundSprite> sprites in backgroundSprites)
            {
                DrawSpriteList(spriteBatch, sprites);
            }
            spriteBatch.End();
        }

        private void DrawSpriteList(SpriteBatch spriteBatch, List<BackgroundSprite> bg)
        {
            foreach (BackgroundSprite background in bg)
            {
                spriteBatch.Draw(background.backgroundImage, background.pos, Color.White);
            }
        }
    }
}
