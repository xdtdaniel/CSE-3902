using Game1.Code.HUD.Factory;
using Game1.Code.Item.ItemFactory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing.Text;

namespace Game1.Code.HUD.Sprite
{
    public class InventoryObject : IHUDSprite
    {
        private int scale;
        private int height;
        private int width;
        private int arrowHeight;
        private int arrowWidth;
        private int x;
        private int y;
        private int arrowX;
        private int arrowY;
        private int arrowNumberX;
        private int arrowNumberY;
        private int[] itemPosOffset;
        private int spacing;

        private Texture2D[] objects;
        private Texture2D arrow;
        private Texture2D[] arrowNumber;
        private Dictionary<string, int> hudItemList;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public InventoryObject(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //load all texture needed in inventory
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
            arrow = ItemSpriteFactory.CreateArrow();
            arrowNumber = new Texture2D[2];
            arrowNumber = HUDFactory.LoadNumber(0);           

            scale = (int)LoadAll.Instance.scale;
            height = 16 * scale;
            width = 8 * scale;
            arrowHeight = 16 * scale;
            arrowWidth = 6 * scale;

            itemPosOffset = new int[9];
            itemPosOffset[0] = 16 * scale + width;
            itemPosOffset[1] = 12 * scale + width;
            itemPosOffset[2] = width;
            itemPosOffset[3] = 12 * scale + width;
            itemPosOffset[4] = -40 * scale - 4 * width;
            itemPosOffset[5] = 16 * scale + width;
            itemPosOffset[6] = 16 * scale + width;
            itemPosOffset[7] = 16 * scale + width;

            spacing = 16 * scale;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // draw arrow symbol
            sourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
            destinationRectangle = new Rectangle(arrowX, arrowY, arrowWidth, arrowHeight);
            spriteBatch.Draw(arrow, destinationRectangle, sourceRectangle, Color.White);

            // draw arrow number
            for (int i = 0; i < 2; i++)
            {
                sourceRectangle = new Rectangle(0, 0, arrowNumber[i].Width, arrowNumber[i].Height);
                destinationRectangle = new Rectangle(arrowNumberX + i * width, arrowNumberY, width, width);
                spriteBatch.Draw(arrowNumber[i], destinationRectangle, sourceRectangle, Color.White);
            }

            // draw inventory items
            if (hudItemList["Bomb"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[0].Width, objects[0].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[0], destinationRectangle, sourceRectangle, Color.White);

            }

            x += itemPosOffset[0];
            if (hudItemList["Boomerang"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[1].Width, objects[1].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[1], destinationRectangle, sourceRectangle, Color.White);
            }

            x += itemPosOffset[1];
            if (hudItemList["WoodenSword"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[2].Width, objects[2].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[2], destinationRectangle, sourceRectangle, Color.White);
            }

            x += itemPosOffset[2];
            if (hudItemList["SwordBeam"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[3].Width, objects[3].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[3], destinationRectangle, sourceRectangle, Color.White);
            }

            x += itemPosOffset[3];
            if (hudItemList["Bow"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[4].Width, objects[4].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[4], destinationRectangle, sourceRectangle, Color.White);
            }

            x += itemPosOffset[4];
            y += spacing;
            if (hudItemList["Clock"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[5].Width, objects[5].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[5], destinationRectangle, sourceRectangle, Color.White);
            }

            x += itemPosOffset[5];
            if (hudItemList["BlueCandle"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[6].Width, objects[6].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[6], destinationRectangle, sourceRectangle, Color.White);
            }

            x += itemPosOffset[6];
            if (hudItemList["BluePotion"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[7].Width, objects[7].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[7], destinationRectangle, sourceRectangle, Color.White);
            }

            x += itemPosOffset[7];
            if (hudItemList["BlueRing"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[8].Width, objects[8].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[8], destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public void Update(float newStartX, float newStartY)
        {
            x = 132 * scale + (int)newStartX;
            y = -176 * scale + 48 * scale + (int)newStartY - 56 * scale;
            arrowX = 128 * scale + (int)newStartX;
            arrowY = -176 * scale + 24 * scale + (int)newStartY - 56 * scale;
            arrowNumberX = arrowX + 16 * scale;
            arrowNumberY = arrowY + 8 * scale;
            arrowNumber = HUDFactory.LoadNumber(hudItemList["Arrow"]);
           
        }




    }
       
}
