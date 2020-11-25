using Game1.Code.HUD.Factory;
using Game1.Code.Item.ItemFactory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Game1.Code.HUD.ItemSelection
{
    public class InventoryObject 
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int height = 16 * scale;
        private int width = 8 * scale;
        private int arrowHeight = 16 * scale;
        private int arrowWidth = 6 * scale;
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
        private int spacing = 24 * scale;

        private int preInventoryItemX = 132 * scale;
        private int preInventoryItemY = -184 * scale;
        private int preArrowX = 128 * scale;
        private int preArrowY = -208 * scale;
        private int preArrowNumberX = 16 * scale;
        private int preArrowNumberY = 8 * scale;
        private int preSwordX = 152 * scale;
        private int preSwordY = -32 * scale;
        private int preSelectedItemX = 128 * scale;
        private int preSelectedItemY = -32 * scale;
        private int prePreviewedItemX = 68 * scale;
        private int prePreviewedItemY = -184 * scale;


        private Dictionary<string, Texture2D> inventoryItemDict;
        public List<Tuple<string, int>> inventoryItemList;

        private Texture2D arrow;
        private Texture2D sword;
        private Texture2D selectedItem;
        private Texture2D previewedItem;
        private Texture2D[] arrowNumber;
        private Dictionary<string, int> hudItemList;


        private Game1 game;
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
            inventoryItemDict.Add("BlueCandle", ItemSpriteFactory.CreateBlueCandle());
            inventoryItemDict.Add("BluePotion", ItemSpriteFactory.CreateBluePotion());
            inventoryItemDict.Add("BlueRing", ItemSpriteFactory.CreateBlueRing());
            arrow = ItemSpriteFactory.CreateArrow();
            sword = ItemSpriteFactory.CreateWoodenSword();
            selectedItem = HUDFactory.LoadBlackSpot(); // nothing when no item is selected
            previewedItem = HUDFactory.LoadBlackSpot();
            arrowNumber = new Texture2D[2];
            arrowNumber = HUDFactory.LoadNumber(0);           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // draw sword on tab A
            Rectangle sourceRectangle = new Rectangle(0, 0, sword.Width, sword.Height);
            Rectangle destinationRectangle = new Rectangle(swordX, swordY, width, height);
            spriteBatch.Draw(sword, destinationRectangle, sourceRectangle, Color.White);

            // draw item on tab B, except for clock, not draw clock at inventory but use it when pick up
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
                if (i > 3) // when index > 3, inventory items will be displayed in next row
                {
                    inventoryItemX -= spacing * 4; // reset x
                    inventoryItemY += height; // increment y
                }

                Texture2D texture = inventoryItemDict[inventoryItemList[i].Item1];
                sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
                destinationRectangle = new Rectangle(inventoryItemX + i * spacing, inventoryItemY, width, height);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

            }
        }

  
        public void Update(float newStartX, float newStartY, int selectedItemIndex, int previewedItemIndex)
        {
            inventoryItemX = preInventoryItemX + (int)newStartX;
            inventoryItemY = preInventoryItemY + (int)newStartY;
            arrowX = preArrowX + (int)newStartX;
            arrowY = preArrowY + (int)newStartY;
            arrowNumberX = arrowX + preArrowNumberX;
            arrowNumberY = arrowY + preArrowNumberY;
            swordX = (int)newStartX + preSwordX;
            swordY = (int)newStartY + preSwordY;
            selectedItemX = (int)newStartX + preSelectedItemX;
            selectedItemY = (int)newStartY + preSelectedItemY;
            previewedItemX = (int)newStartX + prePreviewedItemX;
            previewedItemY = (int)newStartY + prePreviewedItemY;

            arrowNumber = HUDFactory.LoadNumber(hudItemList["Arrow"]);

            if (inventoryItemList.Count > 0)
            {
                string selectedItemName = inventoryItemList[selectedItemIndex].Item1;
                string previewedItemName = inventoryItemList[previewedItemIndex].Item1;
                selectedItem = inventoryItemDict[selectedItemName];
                game.selectedItemName = selectedItemName;
                previewedItem = inventoryItemDict[previewedItemName];

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

                // boomerang is special. 
                // It is still considered held by link after thrown out, so we don't remove it even if its amount becomes 0 after link acquires it. 
                else if (itemName != "Boomerang" && hudItemList[itemName] <= 0 && found)
                {
                    inventoryItemList.RemoveAt(index);
                }
            }
        }
    }
}
