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
    public class HUDNumberOfHeart : IHUDSprite
    {
        private Texture2D emptyHeart;
        private Texture2D halfHeart;
        private Texture2D fullHeart;

        private int scale;
        private int height;
        private int width;
        private int x;
        private int y;
        private int yOrigin;
        private int yDistance;
        private int heartPerRow;
        private int currentHeartIndex;

        private Dictionary<string, int> hudItemList;
        Rectangle sourceRectangle;
        Rectangle destinationRectangle;

        public HUDNumberOfHeart(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //initial values
            emptyHeart = HUDFactory.LoadEmptyHeart();
            halfHeart = HUDFactory.LoadHalfHeart();
            fullHeart = HUDFactory.LoadFullHeart();
            //need to change later, value is incorrect
            scale = (int)LoadAll.Instance.scale;
            height = 8 * scale;
            width = 8 * scale;
            x = 176 * scale;
            y = 40 * scale;
            yOrigin = y;
            yDistance = 176 * scale;
            heartPerRow = 8;
            currentHeartIndex = 0;
            sourceRectangle = new Rectangle();
            destinationRectangle = new Rectangle();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentHeartIndex = 0;

            // draw full heart
            for (currentHeartIndex = 0; currentHeartIndex < hudItemList["Heart"] / 2; currentHeartIndex++)
            {
                sourceRectangle = new Rectangle(0, 0, fullHeart.Width, fullHeart.Height);
                if (currentHeartIndex < heartPerRow)
                {
                    destinationRectangle = new Rectangle(x + width * currentHeartIndex, y, width, height);
                }
                else
                {
                    destinationRectangle = new Rectangle(x + width * (currentHeartIndex % heartPerRow), y - height, width, height);
                }

                spriteBatch.Draw(fullHeart, destinationRectangle, sourceRectangle, Color.White);
            }

            // draw half heart
            if (hudItemList["HeartContainer"] - hudItemList["Heart"] % 2 != 0)
            {
                sourceRectangle = new Rectangle(0, 0, halfHeart.Width, halfHeart.Height);
                if (currentHeartIndex < heartPerRow)
                {
                    destinationRectangle = new Rectangle(x + width * currentHeartIndex, y, width, height);
                }
                else
                {
                    destinationRectangle = new Rectangle(x + width * (currentHeartIndex % heartPerRow), y - height, width, height);
                }
                spriteBatch.Draw(halfHeart, destinationRectangle, sourceRectangle, Color.White);

                currentHeartIndex++;
            }

            //// draw empty heart
            for (int i = 0; i < (hudItemList["HeartContainer"] - hudItemList["Heart"]) / 2; i++)
            {
                sourceRectangle = new Rectangle(0, 0, emptyHeart.Width, emptyHeart.Height);
                if (currentHeartIndex < heartPerRow)
                {
                    destinationRectangle = new Rectangle(x + width * currentHeartIndex, y, width, height);
                }
                else
                {
                    destinationRectangle = new Rectangle(x + width * (currentHeartIndex % heartPerRow), y - height, width, height);
                }

                spriteBatch.Draw(emptyHeart, destinationRectangle, sourceRectangle, Color.White);

                currentHeartIndex++;
            }

        }
        public void Update(bool enabled, int speed)
        {
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
