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
        private Texture2D Selection;
        private Texture2D[] objects;

        public InventoryItemSelection(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;

            //load selections
            Selection = HUDFactory.LoadInventorySelection();
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

            x_selection = 128 * scale + (int)LoadAll.Instance.startPos.X;
            y_selection = -176 * scale + 48 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;   
            xOffset = 0;
            yOffset = 0;

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

            foreach (int i in hudItemList.Values)
            {
                if (i > 0)
                {
                    sourceRectangle = new Rectangle(0, 0, objects[index].Width, objects[index].Height);
                    destinationRectangle = new Rectangle(x_display, y_display, width, sideLength);
                    spriteBatch.Draw(objects[index], destinationRectangle, sourceRectangle, Color.White);
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

            x_display = 68 * scale + (int)newStartX;
            y_display = -176 * scale + 48 * scale + (int)newStartY - 56 * scale;

        }
     

        public void MoveNext()
        {
            if (index == 8)
            {
                index = -1;
                xOffset = 0;
                yOffset = 0;

            }
            else if (index == 4)
            {
                xOffset -= 3 * spacing;
                yOffset += sideLength;
      
            }
            else if (index==2)
            {

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
            else if (index == 3) { 
            
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
        public int getIndex() {

            return index;
        }
    }

}
