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
    public class HUDInventoryAB 
    {

        private Texture2D[] objects;
        private int scale;
        private int height;
        private int width;
        private int x;
        private int y;
        private int i;


        private Dictionary<string, int> hudItemList;

        public HUDInventoryAB(Dictionary<string, int> itemList, int index)
        {
            i = index;
           
            hudItemList = itemList;
            objects = new Texture2D[9];
            objects[0] = ItemSpriteFactory.CreateBomb();
            objects[1] = ItemSpriteFactory.CreateBoomerang();
            objects[2] = ItemSpriteFactory.CreateWoodenSword();
            objects[3] = ItemSpriteFactory.CreateSwordBeam();
            objects[4] = ItemSpriteFactory.CreateBow();
            objects[5] = ItemSpriteFactory.CreateClock();
            objects[6] = ItemSpriteFactory.CreateBlueCandle();
            objects[7] = ItemSpriteFactory.CreateBluePotion();
            objects[8] = ItemSpriteFactory.CreateBlueRing();

            scale = (int)LoadAll.Instance.scale;
            height = 16 * scale;
            width = 8 * scale;
            x = 128 * scale + (int)LoadAll.Instance.startPos.X;
            y = 24 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, objects[i].Width, objects[i].Height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);
            spriteBatch.Draw(objects[i], destinationRectangle, sourceRectangle, Color.White);

            sourceRectangle = new Rectangle(0, 0, objects[2].Width, objects[2].Height);
            destinationRectangle = new Rectangle(x+width*scale, y, width, height);
            spriteBatch.Draw(objects[2], destinationRectangle, sourceRectangle, Color.White);


        }

        public void Update(float newStartX, float newStartY, int index)
        {
            x = (int)newStartX + 128 * scale;
            y = (int)newStartY - 56 * scale + 24 * scale;
            i = index;
        }
    }
}
