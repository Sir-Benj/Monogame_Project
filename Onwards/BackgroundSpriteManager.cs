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

        public static BackgroundSprite fBackOne, fBackTwo, fBackThree, fBackFour, fBackFive,
                                       fMOne, fMTwo, fMThree, fMFour, fMFive,
                                       fPOne, fPTwo, fPThree, fPFour, fPFive,
                                       fOneFore, fTwoFore, fThreeFore, fFourFore, fFiveFore,
                                       fOneMid, fTwoMid, fThreeMid, fFourMid, fFiveMid;

        //Texture lists for map backgrounds;
        public static List<BackgroundSprite> fPath, fFore, fMid, fMountain, fBackground;

        public BackgroundSpriteManager()
        {
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

            fBackOne = new BackgroundSprite(fBackTex);
            fBackTwo = new BackgroundSprite(fBackTex);
            fBackThree = new BackgroundSprite(fBackTex);
            fBackFour = new BackgroundSprite(fBackTex);
            fBackFive = new BackgroundSprite(fBackTex);

            fMOne = new BackgroundSprite(fMOneTex);
            fMTwo = new BackgroundSprite(fMOneTex);
            fMThree = new BackgroundSprite(fMOneTex);
            fMFour = new BackgroundSprite(fMOneTex);
            fMFive = new BackgroundSprite(fMOneTex);

            fOneMid = new BackgroundSprite(fOneMidTex);
            fTwoMid = new BackgroundSprite(fTwoMidTex);
            fThreeMid = new BackgroundSprite(fThreeMidTex);
            fFourMid = new BackgroundSprite(fFourMidTex);
            fFiveMid = new BackgroundSprite(fFiveMidTex);

            fOneFore = new BackgroundSprite(fOneForeTex);
            fTwoFore = new BackgroundSprite(fTwoForeTex);
            fThreeFore = new BackgroundSprite(fThreeForeTex);
            fFourFore = new BackgroundSprite(fFourForeTex);
            fFiveFore = new BackgroundSprite(fFiveForeTex);

            fPOne = new BackgroundSprite(fPOneTex);
            fPTwo = new BackgroundSprite(fPOneTex);
            fPThree = new BackgroundSprite(fPOneTex);
            fPFour = new BackgroundSprite(fPTwoTex);
            fPFive = new BackgroundSprite(fPTwoTex);

            //Forest Path Load List
            fPath.Add(fPOne);
            fPath.Add(fPTwo);
            fPath.Add(fPThree);
            fPath.Add(fPFour);
            fPath.Add(fPFive);
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
            fMountain.Add(fMTwo);
            fMountain.Add(fMThree);
            fMountain.Add(fMFour);
            fMountain.Add(fMFive);
            //Forest Background Load List
            fBackground.Add(fBackOne);
            fBackground.Add(fBackTwo);
            fBackground.Add(fBackThree);
            fBackground.Add(fBackFour);
            fBackground.Add(fBackFive);

            SetupSpritePos(fBackground);
            SetupSpritePos(fMountain);
            SetupSpritePos(fMid);
            SetupSpritePos(fFore);
            SetupSpritePos(fPath);
        }

        private void SetupSpritePos(List<BackgroundSprite> bg)
        {
            Vector2 placement = new Vector2(0, 0);

            for (var i = 0; i < bg.Count; i++ )
            {
                bg[i].pos.X += placement.X;
                placement.X += bg[i].backgroundImage.Width;
            }
        }

        public void UpdateMap()
        {
           
        }

        public void DrawBGSprites(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
            DrawSpriteList(spriteBatch, fBackground);
            DrawSpriteList(spriteBatch, fMountain);
            DrawSpriteList(spriteBatch, fMid);
            DrawSpriteList(spriteBatch, fFore);
            DrawSpriteList(spriteBatch, fPath);
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
