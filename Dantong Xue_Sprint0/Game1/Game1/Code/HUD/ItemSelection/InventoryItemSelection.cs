using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace Game1.Code.HUD.Sprite
{
    public class InventoryItenSelection
    {
        private int scale;
        private int width;
        private int sideLength;
        private int spacing;
        private int index;
        private int x_selection;
        private int y_selection;
        private int xOffset;
        private int yOffset;


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
        private List<string> inventoryItemList;
        private Texture2D Selection;
        public InventoryItenSelection(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //load selections
            Selection = HUDFactory.LoadInventorySelection();

            TotalFrames = 2;
            Rows = 1;
            Columns = 2;
            CurrentFrame = 0;

            scale = (int)LoadAll.Instance.scale;
            width = 7 * scale;
            sideLength = 16 * scale;
            spacing = 24 * scale;

            index = 0;

            inventoryItemList = new List<string>();
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
