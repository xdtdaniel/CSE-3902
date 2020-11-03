using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.HUD.Sprite
{
    public class HUDNumberOfBomb : IHUDSprite
    {
        private Texture2D[] numberOfBomb;

        private int scale;
        private int height;
        private int width;
        private int x;
        private int y;
        private int yOrigin;
        private int yDistance;

        private Dictionary<string, int> hudItemList;

        public HUDNumberOfBomb(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //initial values
            numberOfBomb = new Texture2D[2];
            numberOfBomb = HUDFactory.LoadNumber(hudItemList["Bomb"]);
            //need to change later, value is incorrect
            scale = (int)LoadAll.Instance.scale;
            height = 8 * scale;
            width = 8 * scale;
            x = 104 * scale;
            y = 40 * scale;
            yOrigin = y;
            yDistance = 176 * scale;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 2; i++)
            {
                Rectangle sourceRectangle = new Rectangle(0, 0, numberOfBomb[i].Width, numberOfBomb[i].Height);
                Rectangle destinationRectangle = new Rectangle(x + i * width, y, width, height);

                spriteBatch.Draw(numberOfBomb[i], destinationRectangle, sourceRectangle, Color.White);
            }
        }
        public void Update(bool enabled, int speed)
        {
            // update number sprite
            numberOfBomb = HUDFactory.LoadNumber(hudItemList["Bomb"]);

            if (enabled)
            {
                if (y < yOrigin + yDistance)
                {
                    y += speed;
                }
            }
            else
            {
                if (y > yOrigin)
                {
                    y -= speed;
                }
            }
        }

    }
}
