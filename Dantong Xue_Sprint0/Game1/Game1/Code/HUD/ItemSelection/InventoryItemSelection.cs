using Game1.Code.HUD.Factory;
using Game1.Code.Item.ItemFactory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Mathematics.Interop;
using System;
using System.Collections.Generic;
using System.Drawing.Text;

namespace Game1.Code.HUD.Sprite
{
    public class InventoryItemSelection
    {
        private int scale;
        private int width;
        private int sideLength;
        private int spacing;
        private int index;
        private int x_selection;
        private int y_selection;
        private int x_display;
        private int y_display;
        private int xOffset;
        private int yOffset;
        private int id;

        private int texture_height;
        private int texture_width;

        private int Columns;
        private int Rows;
        private int TotalFrames;
        private int CurrentFrame;
        private int count = 0;
        //timer
        private int maxcount = 20;

        private Dictionary<string, int> hudItemList;
        private List<Tuple<string, int>> inventoryItemList;
        private Texture2D Selection;
        private Texture2D[] objects;

        public InventoryItemSelection(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //load selections
            Selection = HUDFactory.LoadInventorySelection();
            objects = new Texture2D[9];

            inventoryItemList = new List<Tuple<string, int>>();

            TotalFrames = 2;
            Rows = 1;
            Columns = 2;
            CurrentFrame = 0;

            scale = (int)LoadAll.Instance.scale;
            width = 7 * scale;
            sideLength = 16 * scale;
            spacing = 24 * scale;
            index = 0;
            id = 0;

            //position to display the seleccted item
            x_display = 68 * scale + (int)LoadAll.Instance.startPos.X;
            y_display = -176 * scale + 48 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
            x_selection = 128 * scale + (int)LoadAll.Instance.startPos.X;
            y_selection = -176 * scale + 48 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;   
            xOffset = 0;
            yOffset = 0;

            
            //get item list in order
            if (hudItemList["Bomb"] > 0)
            {
                objects[id] = ItemSpriteFactory.CreateBomb();
                inventoryItemList.Add(new Tuple<string, int>("Bomb", id));
                id++;

            }

            if (hudItemList["Boomerang"] > 0)
            {
                objects[id] = ItemSpriteFactory.CreateBoomerang();
                inventoryItemList.Add(new Tuple<string, int>("Boomerang", id));
                id++;
            }
            if (hudItemList["WoodenSword"] > 0)
            {
                objects[id] = ItemSpriteFactory.CreateWoodenSword();
                inventoryItemList.Add(new Tuple<string, int>("WoodenSword", id));
                id++;
            }
            if (hudItemList["SwordBeam"] > 0)
            {
                objects[id] = ItemSpriteFactory.CreateSwordBeam();       
                inventoryItemList.Add(new Tuple<string, int>("SwordBeam", id));
                id++;
            }
            if (hudItemList["Bow"] > 0)
            {
                objects[id] = ItemSpriteFactory.CreateBow();       
                inventoryItemList.Add(new Tuple<string, int>("Bow", id));
                id++;
            }
            if (hudItemList["Clock"] > 0)
            {
                objects[id] = ItemSpriteFactory.CreateClock();
                inventoryItemList.Add(new Tuple<string, int>("Clock", id));
                id++;
            }
            if (hudItemList["BlueCandle"] > 0)
            {
                objects[id] = ItemSpriteFactory.CreateBlueCandle();
                inventoryItemList.Add(new Tuple<string, int>("BlueCandle", id));
                id++;
            }
            if (hudItemList["BluePotion"] > 0)
            {
                objects[id] = ItemSpriteFactory.CreateBluePotion();
                inventoryItemList.Add(new Tuple<string, int>("BluePotion", id));
                id++;
            }
            if (hudItemList["BlueRing"] > 0)
            {
                objects[id] = ItemSpriteFactory.CreateBlueRing();
                inventoryItemList.Add(new Tuple<string, int>("BlueRing", id));
                id++;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            texture_width = Selection.Width / Columns;
            texture_height = Selection.Height/ Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(texture_width * column, texture_height * row, texture_width, texture_height);
            Rectangle destinationRectangle = new Rectangle(x_selection, y_selection, sideLength, sideLength);
            spriteBatch.Draw(Selection, destinationRectangle, sourceRectangle, Color.White);

            for (int i = 0; i < inventoryItemList.Count; i++)
            {
                if (inventoryItemList[i].Item2 == index) {
                    sourceRectangle = new Rectangle(0, 0, objects[i].Width, objects[i].Height);
                    destinationRectangle = new Rectangle(x_display, y_display, width, sideLength);
                    spriteBatch.Draw(objects[i], destinationRectangle, sourceRectangle, Color.White);
                }
            
            }
        }


        public void Update(float newStartX, float newStartY) 
        {
            count++;
            if (count == maxcount)
            {
                CurrentFrame++;
                if (CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
                count = 0;
            }

            x_selection = 128 * scale + (int)newStartX + xOffset;
            y_selection = -176 * scale + 48 * scale + (int)newStartY - 56 * scale + yOffset;

            x_display = 68 * scale + (int)LoadAll.Instance.startPos.X;
            y_display = -176 * scale + 48 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;

        }
     

        public void MoveNext()
        {
            if (index == 7)
            {
                index = -1;
                xOffset = 0;
                yOffset = 0;
            }
            else if (index == 3)
            {
                xOffset -= 3 * spacing;
                yOffset += sideLength;

            }
            else
            {
                xOffset += spacing;
            }

            index++;
        }

        public void MovePrev()
        {
            if (index == 0)
            {
                index = 8;
                xOffset += 3 * spacing;
                yOffset += sideLength;
            }
            else if (index == 4)
            {
                xOffset += 3 * spacing;
                yOffset -= sideLength;
            }
            else
            {
                xOffset -= spacing;
            }
            index--;
        }
    }

}
