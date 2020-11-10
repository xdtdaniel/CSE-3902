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
        private int spacing;
        private List<Tuple<string, int>> inventoryItemList;
        private Dictionary<string, Texture2D> inventoryItemDict;
        
        private Texture2D arrow;
        private Texture2D[] arrowNumber;
        private Dictionary<string, int> hudItemList;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public InventoryObject(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //load all texture needed in inventory
            inventoryItemList = new List<Tuple<string, int>>();
            inventoryItemList.Add(new Tuple<string, int>("WoodenSword", hudItemList["WoodenSword"]));
            inventoryItemDict = new Dictionary<string, Texture2D>();
            inventoryItemDict.Add("WoodenSword", ItemSpriteFactory.CreateWoodenSword());
            inventoryItemDict.Add("SwordBeam", ItemSpriteFactory.CreateSwordBeam());
            inventoryItemDict.Add("Bomb", ItemSpriteFactory.CreateBomb());
            inventoryItemDict.Add("Boomerang", ItemSpriteFactory.CreateBoomerang());
            inventoryItemDict.Add("Bow", ItemSpriteFactory.CreateBow());
            inventoryItemDict.Add("Clock", ItemSpriteFactory.CreateClock());
            inventoryItemDict.Add("BlueCandle", ItemSpriteFactory.CreateBlueCandle());
            inventoryItemDict.Add("BluePotion", ItemSpriteFactory.CreateBluePotion());
            inventoryItemDict.Add("BlueRing", ItemSpriteFactory.CreateBlueRing());
            arrow = ItemSpriteFactory.CreateArrow();
            arrowNumber = new Texture2D[2];
            arrowNumber = HUDFactory.LoadNumber(0);           

            scale = (int)LoadAll.Instance.scale;
            height = 16 * scale;
            width = 8 * scale;
            arrowHeight = 16 * scale;
            arrowWidth = 6 * scale;

            spacing = 24 * scale;

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
            for (int i = 0; i < inventoryItemList.Count; i++)
            {
                if (i > 3)
                {
                    x -= spacing * 4;
                    y += height;
                }
                Texture2D texture = inventoryItemDict[inventoryItemList[i].Item1];
                sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
                destinationRectangle = new Rectangle(x + i * spacing, y, width, height);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
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

            foreach (KeyValuePair<string, Texture2D> kvp in inventoryItemDict)
            {
                Tuple<string, int> tuple = new Tuple<string, int>(kvp.Key, hudItemList[kvp.Key]);
                string itemName = kvp.Key;
                bool found = false;
                int index = 0;
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    // check if already exists
                    if (inventoryItemList[i].Item1 == itemName && !found)
                    {
                        found = true;
                        index = i;
                    }
                }
                if (hudItemList[itemName] > 0 && !found)
                {
                    inventoryItemList.Add(tuple);
                }

                else if (hudItemList[itemName] <= 0 && found)
                {
                    inventoryItemList.RemoveAt(index);
                }
                
            }

        }




    }
       
}
