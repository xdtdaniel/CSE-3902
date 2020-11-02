using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.HUD.Sprite
{
    public class hudKeyAmount
    {
        private int key_count;
        private Texture2D symbol_X;
        private Texture2D[] countKeyNumber = new Texture2D[2];

        private int scale;
        private int height;
        private int width;
        private int x;
        private int minY;
        private int y;
        private int maxY;
        private int factor;

        private Dictionary<string, int> hudItemList;

        public hudKeyAmount(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //initial values
            key_count = 0;
            symbol_X = HUDFactory.LoadX();
            countKeyNumber = HUDFactory.LoadNumber(key_count);

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

        public void DrawCount(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle_x = new Rectangle(0, 0, symbol_X.Width, symbol_X.Height);
            Rectangle destinationRectangle_x = new Rectangle(x, y, width, height);
            Rectangle sourceRectangle_0 = new Rectangle(0, 0, countKeyNumber[0].Width, countKeyNumber[0].Height);
            Rectangle destinationRectangle_0 = new Rectangle(x, y, width, height);
            Rectangle sourceRectangle_1 = new Rectangle(0, 0, countKeyNumber[1].Width, countKeyNumber[1].Height);
            Rectangle destinationRectangle_1 = new Rectangle(x, y, width, height);


            spriteBatch.Draw(symbol_X, destinationRectangle_x, sourceRectangle_x, Color.White);
            spriteBatch.Draw(countKeyNumber[0], destinationRectangle_x, sourceRectangle_x, Color.White);
            spriteBatch.Draw(countKeyNumber[1], destinationRectangle_x, sourceRectangle_x, Color.White);

        }
        public void UpdateCount()
        {
            for (int i = 0; i < hudItemList.Count; i++)
            {
                if (hudItemList.ContainsKey("key"))
                {
                    key_count = hudItemList["key"];
                }
            }

        }

    }
}
