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
    public class HUDHeartAmount
    {
        private int life_count;
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

        private Dictionary<string, int> hudItemList;

        public HUDHeartAmount(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //initial values
            life_count = 0;
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
        }

        public void DrawCount(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle();
            Rectangle destinationRectangle = new Rectangle();

            int lostHeart = hudItemList["heartcontainer"] - hudItemList["heart"];
            int currentHeartIndex = 0;

            
            x = 176 * scale;
            y = 40 * scale;
            // draw full heart
            for (currentHeartIndex = 0; currentHeartIndex < hudItemList["heart"] / 2; currentHeartIndex++)
            {
                if (currentHeartIndex == heartPerRow)
                {
                    x -= heartPerRow * width;
                    y -= height;
                }
                sourceRectangle = new Rectangle(0, 0, fullHeart.Width, fullHeart.Height);
                destinationRectangle = new Rectangle(x, y, width, height);

                spriteBatch.Draw(fullHeart, destinationRectangle, sourceRectangle, Color.White);

                x += width;
            }

            // draw half heart
            if (lostHeart % 2 != 0)
            {
                if (currentHeartIndex == heartPerRow)
                {
                    x -= heartPerRow * width;
                    y -= height;
                }
                sourceRectangle = new Rectangle(0, 0, halfHeart.Width, halfHeart.Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(halfHeart, destinationRectangle, sourceRectangle, Color.White);

                x += width;
                currentHeartIndex++;
            }

            //// draw empty heart
            for (int i = 0; i < lostHeart / 2; i++)
            {
                if (currentHeartIndex == heartPerRow)
                {
                    x -= heartPerRow * width;
                    y -= height;
                }

                sourceRectangle = new Rectangle(0, 0, emptyHeart.Width, emptyHeart.Height);
                destinationRectangle = new Rectangle(x, y, width, height);

                spriteBatch.Draw(emptyHeart, destinationRectangle, sourceRectangle, Color.White);

                x += width;
                currentHeartIndex++;
            }

        }
        public void UpdateCount()
        {
            

            //for (int i = 0; i < life_count; i++) {
            //    drawcount(spritebatch, location_x, location_y);
            
            //}

        }

    }
}
