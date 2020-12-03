using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Game1.Code.HUD.Sprite
{
    class HUDExpLevel : IHUDSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int levelNumberSideLength = 8 * scale;
        private int levelX;
        private int levelY;
       
        private int preLevelX = 174 * scale;
        private int preLevelY = -30 * scale;

        private Texture2D expLevelTexture;
        private promptText prompt;
        private Game1 game;
        private int preLevel;
        private int explevel;
        private int currentFrame = 0;
        private int maxCurrentFrame = 500;

        public HUDExpLevel(Game1 game)
        {
            this.game = game;
            prompt = new promptText(100,100);
            preLevel = 1;
            explevel = 1;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // draw exp level number
            Rectangle sourceRectangle = new Rectangle(0, 0, expLevelTexture.Width, expLevelTexture.Height);
            Rectangle destinationRectangle = new Rectangle(levelX, levelY, levelNumberSideLength, levelNumberSideLength);

            spriteBatch.Draw(expLevelTexture, destinationRectangle, sourceRectangle, Color.LimeGreen);
           
            if (explevel != preLevel) {
                prompt.Draw(spriteBatch);                             
            }
           
        }

        public void Update(float newStartX, float newStartY)
        {
            currentFrame++;
            explevel = game.link.linkLevel;
            expLevelTexture = HUDFactory.LoadNumber(explevel)[1];
            levelX = (int)newStartX + preLevelX;
            levelY = (int)newStartY + preLevelY;
           
            if (currentFrame == maxCurrentFrame) //display few seconds.
            {
                preLevel = explevel;
                currentFrame = 0;
            }
        }
    }
}