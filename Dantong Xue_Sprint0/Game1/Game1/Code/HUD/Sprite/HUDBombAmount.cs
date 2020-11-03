using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.HUD.Sprite
{
    public class HUDBombAmount
    {
        private int bomb_count;
        private Texture2D symbol_X;
        private Texture2D[] countBombNumber = new Texture2D[2];

        private int scale;
        private int height;
        private int width;
        private int x;
        private int minY;
        private int y;
        private int maxY;
        private int factor;

        private Dictionary<string, int> hudItemList;

        public HUDBombAmount(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //initial values
            bomb_count = 0;
            symbol_X = HUDFactory.LoadX();
            countBombNumber = HUDFactory.LoadNumber(bomb_count);

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
            Rectangle sourceRectangle_0 = new Rectangle(0, 0, countBombNumber[0].Width, countBombNumber[0].Height);
            Rectangle destinationRectangle_0 = new Rectangle(x, y, width, height);
            Rectangle sourceRectangle_1 = new Rectangle(0, 0, countBombNumber[1].Width, countBombNumber[1].Height);
            Rectangle destinationRectangle_1 = new Rectangle(x, y, width, height);


            spriteBatch.Draw(symbol_X, destinationRectangle_x, sourceRectangle_x, Color.White);
            spriteBatch.Draw(countBombNumber[0], destinationRectangle_x, sourceRectangle_x, Color.White);
            spriteBatch.Draw(countBombNumber[1], destinationRectangle_x, sourceRectangle_x, Color.White);

        }
        public void UpdateCount()
        {
            for (int i = 0; i < hudItemList.Count; i++)
            {
                if (hudItemList.ContainsKey("bomb"))
                {
                    bomb_count = hudItemList["bomb"];
                }
            }

        }

    }
}
