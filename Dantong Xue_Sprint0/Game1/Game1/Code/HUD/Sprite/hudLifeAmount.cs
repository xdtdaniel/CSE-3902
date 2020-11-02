using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
namespace Game1.Code.HUD.Sprite
{
    public class hudLifeAmount
    {
        private int life_count;
        private Texture2D life_Amount;

        private int scale;
        private int height;
        private int width;
        private int x;
        private int minY;
        private int y;
        private int maxY;
        private int factor;

        private Dictionary<string, int> hudItemList;

        public hudLifeAmount(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //initial values
            life_count = 0;
            life_Amount = HUDFactory.LoadFullHeart();
            //need to change later, value is incorrect
            scale = (int)LoadAll.Instance.scale;
            height = 8 * scale;
            width = 8 * scale;
            x = 0;
            minY = 0;
            y = minY;
            maxY = 176 * scale;
            factor = 1;
        }

        public void DrawCount(SpriteBatch spriteBatch, int x,  int y)
        {
            
            Rectangle sourceRectangle_x = new Rectangle(0, 0, life_Amount.Width, life_Amount.Height);
            Rectangle destinationRectangle_x = new Rectangle(x, y, width, height);
            spriteBatch.Draw(life_Amount, destinationRectangle_x, sourceRectangle_x, Color.White);
          

        }
        public void UpdateCount()
        {
            for (int i = 0; i < hudItemList.Count; i++)
            {
                if (hudItemList.ContainsKey("heart"))
                {
                   life_count = hudItemList["heart"];
                }
            }

            //for (int i = 0; i < life_count; i++) {
            //    drawcount(spritebatch, location_x, location_y);
            
            //}

        }

    }
}
