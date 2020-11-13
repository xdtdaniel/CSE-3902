using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.HUD.Sprite
{
    public class InventoryItemSelection
    {
        private int scale;
        private int sideLength;
        private int spacing;
        private int x;
        private int y;
        private Vector2[] offsetList;

        private int texture_height;
        private int texture_width;

        private int Columns;
        private int Rows;
        private int TotalFrames;
        private int CurrentFrame;
        private int count = 0;
        //timer
        private int maxcount = 20;
        private int listLength;

        private Texture2D Selection;

        public InventoryItemSelection()
        {
            //load selections
            Selection = HUDFactory.LoadInventorySelection();

            TotalFrames = 2;
            Rows = 1;
            Columns = 2;
            CurrentFrame = 0;

            scale = (int)LoadAll.Instance.scale;
            sideLength = 16 * scale;
            spacing = 24 * scale;
            

            x = 128 * scale + (int)LoadAll.Instance.startPos.X;
            y = -176 * scale + 48 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;   
            offsetList = new Vector2[8];
            for (int i = 0; i < 8; i++)
            {
                int xOffset = 0;
                int yOffset = 0;
                if (i == 4)
                {
                    xOffset = -spacing * 3;
                    yOffset = sideLength;
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

            x = 128 * scale + (int)newStartX + (int)offsetList[index].X;
            y = -176 * scale + 48 * scale + (int)newStartY - 56 * scale + (int)offsetList[index].Y;
        }
     


    }

}
