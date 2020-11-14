using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.HUD.Sprite
{
    public class InventoryItemSelection
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int sideLength = 16 * scale;
        private int spacing = 24 * scale;
        private static int preX = 128 * scale;
        private static int preY = -184 * scale;
        private int x;
        private int y;   
        private Vector2[] offsetList;
        private int numberOfInventoryItem = 8;

        private int texture_height;
        private int texture_width;

        private int Columns = 2;
        private int Rows = 1;
        private int TotalFrames = 2;
        private int CurrentFrame = 0;
        private int count = 0;
        //timer
        private int maxcount = 20;
        private int listLength;

        private Texture2D Selection;

        public InventoryItemSelection()
        {
            //load selections
            Selection = HUDFactory.LoadInventorySelection();

            offsetList = new Vector2[numberOfInventoryItem];
            for (int i = 0; i < numberOfInventoryItem; i++)
            {
                int xOffset = 0;
                int yOffset = 0;
                if (i == numberOfInventoryItem / 2)
                {
                    xOffset = -spacing * 3; // reset x offset
                    yOffset = sideLength; // increment y offset
                }
                offsetList[i] = new Vector2(xOffset + i * spacing, yOffset);
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (listLength > 0)
            {
                texture_width = Selection.Width / Columns;
                texture_height = Selection.Height / Rows;
                int row = (int)((float)CurrentFrame / (float)Columns);
                int column = CurrentFrame % Columns;

                Rectangle sourceRectangle = new Rectangle(texture_width * column, texture_height * row, texture_width, texture_height);
                Rectangle destinationRectangle = new Rectangle(x, y, sideLength, sideLength);
                spriteBatch.Draw(Selection, destinationRectangle, sourceRectangle, Color.White);

            }
        }

        public void Update(float newStartX, float newStartY, int index, int listLength)
        {
            this.listLength = listLength;

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

            x = preX + (int)newStartX + (int)offsetList[index].X;
            y = preY + (int)newStartY + (int)offsetList[index].Y;
        }
     


    }

}
