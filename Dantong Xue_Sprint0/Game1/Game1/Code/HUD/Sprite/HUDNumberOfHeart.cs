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

        private static int scale = (int)LoadAll.Instance.scale;
        private int height = 8 * scale;
        private int width = 8 * scale;
        private int x;
        private int y;
        private int heartPerRow = 8;
        private int currentHeartIndex = 0;

        private int preX = 176 * scale;
        private int preY = -16 * scale;

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
            if (hudItemList["Heart"] % 2 != 0)
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
        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX + preX;
            y = (int)newStartY + preY;
        }
    }
}
