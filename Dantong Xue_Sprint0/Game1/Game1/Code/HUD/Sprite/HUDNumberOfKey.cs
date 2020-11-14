using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.HUD.Sprite
{
    public class HUDNumberOfKey : IHUDSprite
    {
        private Texture2D[] numberOfKey;

        private static int scale = (int)LoadAll.Instance.scale;
        private int height = 8 * scale;
        private int width = 8 * scale;
        private int x;
        private int y;

        private int preX = 104 * scale;
        private int preY = -24 * scale;

        private Dictionary<string, int> hudItemList;

        public HUDNumberOfKey(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //initial values
            numberOfKey = new Texture2D[2];
            numberOfKey = HUDFactory.LoadNumber(hudItemList["Key"]);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 2; i++)
            {
                Rectangle sourceRectangle = new Rectangle(0, 0, numberOfKey[i].Width, numberOfKey[i].Height);
                Rectangle destinationRectangle = new Rectangle(x + i * width, y, width, height);

                spriteBatch.Draw(numberOfKey[i], destinationRectangle, sourceRectangle, Color.White);
            }
        }
        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX + preX;
            y = (int)newStartY + preY;
            numberOfKey = HUDFactory.LoadNumber(hudItemList["Key"]);
        }

    }
}

