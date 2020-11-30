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
        private int levelNumberSideLength = 12 * scale;
        private int levelX;
        private int levelY;
       
        private int preLevelX = 172 * scale;
        private int preLevelY = -30 * scale;

        private Texture2D expLevelTexture;
        private int explevel;
        public HUDExpLevel(int level)
        {
            explevel = 1;
            expLevelTexture = HUDFactory.LoadNumber(explevel)[1]; // level number has one digit
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // draw exp level number
           Rectangle sourceRectangle = new Rectangle(0, 0, expLevelTexture.Width, expLevelTexture.Height);
            Rectangle destinationRectangle = new Rectangle(levelX, levelY, levelNumberSideLength, levelNumberSideLength);

            spriteBatch.Draw(expLevelTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(float newStartX, float newStartY)
        {
            explevel = HUDExp.level;
            expLevelTexture = HUDFactory.LoadNumber(explevel)[1];
            levelX = (int)newStartX + preLevelX;
            levelY = (int)newStartY + preLevelY;
            
        }
    }
}