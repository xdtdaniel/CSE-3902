using Game1.Code.HUD.Factory;
using Game1.Code.Item.ItemFactory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Game1.Code.HUD.Sprite
{
    public class HUDInventoryAB : IHUDSprite
    {

        private Texture2D[] InventoryAB;
        private int scale;
        private int height;
        private int width;
        private int x;
        private int y;
        private string B;
        private string A;

        private Dictionary<string, int> hudItemList;

        public HUDInventoryAB(Dictionary<string, int> itemList, string[] ba)
        {
            hudItemList = itemList;
           // B = ba[0];
          //  A = ba[1];
            InventoryAB = new Texture2D[2];
            //CHANGE TO SWITCH CASE
            InventoryAB[0] = HUDFactory.LoadSword();
            InventoryAB[1] = ItemSpriteFactory.CreateBomb();

            scale = (int)LoadAll.Instance.scale;
            height = 16 * scale;
            width = 8 * scale;
            x = 128 * scale + (int)LoadAll.Instance.startPos.X;
            y = 24 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, InventoryAB[0].Width, InventoryAB[0].Height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);
            spriteBatch.Draw(InventoryAB[0], destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(0, 0, InventoryAB[1].Width, InventoryAB[1].Height);
            destinationRectangle = new Rectangle(x+width*scale, y, width, height);
            spriteBatch.Draw(InventoryAB[1], destinationRectangle, sourceRectangle, Color.White);


        }

        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX + 128 * scale;
            y = (int)newStartY - 56 * scale + 24 * scale;
        }
    }
}
