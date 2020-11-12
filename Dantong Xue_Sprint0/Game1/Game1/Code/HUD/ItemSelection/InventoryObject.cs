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
    public class InventoryObject 
    {
        private int scale;
        private int height;
        private int width;
        private int arrowHeight;
        private int arrowWidth;
        private int inventoryItemX;
        private int inventoryItemY;
        private int arrowX;
        private int arrowY;
        private int arrowNumberX;
        private int arrowNumberY;
        private int swordX;
        private int swordY;
        private int selectedItemX;
        private int selectedItemY;
        private int previewedItemX;
        private int previewedItemY;
        private int spacing;
        private int mapID;
        private Dictionary<string, Texture2D> inventoryItemDict;
        public List<Tuple<string, int>> inventoryItemList;

        private Texture2D arrow;
        private Texture2D sword;
        private Texture2D selectedItem;
        private Texture2D previewedItem;
        private Texture2D[] arrowNumber;
        private Dictionary<string, int> hudItemList;


        private Game1 game;
        private bool clock;
        public InventoryObject(Game1 game, List<Tuple<string, int>> inventoryItemList)
        {
            this.game = game;
            hudItemList = game.link.itemList;
            //load all texture needed in inventory

            this.inventoryItemList = inventoryItemList;
            inventoryItemDict = new Dictionary<string, Texture2D>();
            inventoryItemDict.Add("Bomb", ItemSpriteFactory.CreateBomb());
            inventoryItemDict.Add("Boomerang", ItemSpriteFactory.CreateBoomerang());
            inventoryItemDict.Add("Bow", ItemSpriteFactory.CreateBow());
            inventoryItemDict.Add("Clock", ItemSpriteFactory.CreateClock());
            inventoryItemDict.Add("BlueCandle", ItemSpriteFactory.CreateBlueCandle());
            inventoryItemDict.Add("BluePotion", ItemSpriteFactory.CreateBluePotion());
            inventoryItemDict.Add("BlueRing", ItemSpriteFactory.CreateBlueRing());
            arrow = ItemSpriteFactory.CreateArrow();
            sword = ItemSpriteFactory.CreateWoodenSword();
            selectedItem = HUDFactory.LoadBlackSpot(); // nothing when no item is selected
            previewedItem = HUDFactory.LoadBlackSpot();
            arrowNumber = new Texture2D[2];
            arrowNumber = HUDFactory.LoadNumber(0);           

            scale = (int)LoadAll.Instance.scale;
            height = 16 * scale;
            width = 8 * scale;
            arrowHeight = 16 * scale;
            arrowWidth = 6 * scale;

            spacing = 24 * scale;

            clock = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // draw sword on tab A
            Rectangle sourceRectangle = new Rectangle(0, 0, sword.Width, sword.Height);
            Rectangle destinationRectangle = new Rectangle(swordX, swordY, width, height);
            spriteBatch.Draw(sword, destinationRectangle, sourceRectangle, Color.White);

            // draw item on tab B
            sourceRectangle = new Rectangle(0, 0, selectedItem.Width, selectedItem.Height);
            destinationRectangle = new Rectangle(selectedItemX, selectedItemY, width, height);
            spriteBatch.Draw(selectedItem, destinationRectangle, sourceRectangle, Color.White);

            // draw previewed item on the left of inventory
            sourceRectangle = new Rectangle(0, 0, previewedItem.Width, previewedItem.Height);
            destinationRectangle = new Rectangle(previewedItemX, previewedItemY, width, height);
            spriteBatch.Draw(previewedItem, destinationRectangle, sourceRectangle, Color.White);

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
                    inventoryItemX -= spacing * 4;
                    inventoryItemY += height;
                }
                Texture2D texture = inventoryItemDict[inventoryItemList[i].Item1];
                sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
                destinationRectangle = new Rectangle(inventoryItemX + i * spacing, inventoryItemY, width, height);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public bool useClock()
        {
            return clock;

        }
        public int getMapID() {

            return mapID;
        }
        public void Update(float newStartX, float newStartY, int selectedItemIndex, int previewedItemIndex)
        {
            inventoryItemX = 132 * scale + (int)newStartX;
            inventoryItemY = -176 * scale + 48 * scale + (int)newStartY - 56 * scale;
            arrowX = 128 * scale + (int)newStartX;
            arrowY = -176 * scale + 24 * scale + (int)newStartY - 56 * scale;
            arrowNumberX = arrowX + 16 * scale;
            arrowNumberY = arrowY + 8 * scale;
            swordX = (int)newStartX + 152 * scale;
            swordY = (int)newStartY - 56 * scale + 24 * scale;
            selectedItemX = (int)newStartX + 128 * scale;
            selectedItemY = (int)newStartY - 56 * scale + 24 * scale;
            previewedItemX = (int)newStartX + 68 * scale;
            previewedItemY = (int)newStartY - 56 * scale + 48 * scale - 176 * scale;
            arrowNumber = HUDFactory.LoadNumber(hudItemList["Arrow"]);

            if (inventoryItemList.Count > 0)
            {
                string selectedItemName = inventoryItemList[selectedItemIndex].Item1;
                string previewedItemName = inventoryItemList[previewedItemIndex].Item1;
                selectedItem = inventoryItemDict[selectedItemName];
                game.selectedItemName = selectedItemName;
                previewedItem = inventoryItemDict[previewedItemName];

                //get current mapID
                if (inventoryItemList[selectedItemIndex].Item1 == "Clock")
                {
                    clock = true;
                    mapID = LoadAll.Instance.GetCurrentMapID();
                }
            }
            else
            {
                game.selectedItemName = "";
                selectedItem = HUDFactory.LoadBlackSpot();
                previewedItem = HUDFactory.LoadBlackSpot();
            }

            if (hudItemList["SwordBeam"] > 0)
            {
                sword = ItemSpriteFactory.CreateSwordBeam();
            }

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
