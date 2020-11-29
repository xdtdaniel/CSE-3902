using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Game1.Code.HUD.AbilitySelection
{
    public class InventoryAbilitySelection
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int sideLength = 25 * scale;
        private int spacing = 30 * scale;
        private static int preX = 33 * scale;
        private static int preY = 217 * scale;
        private int x;
        private int y;   
        private Vector2[] offsetList;
        private int numberOfAbilities = 8;

        private int texture_height;
        private int texture_width;

        private int Columns = 2;
        private int Rows = 1;
        private int TotalFrames = 2;
        private int CurrentFrame = 0;
        private int secondFrame = 0;
        //timer
        private int maxSecondFrame = 20;

        private Texture2D Selection;

        public InventoryAbilitySelection()
        {
            //load selections
            Selection = HUDFactory.LoadInventorySelection();

            offsetList = new Vector2[numberOfAbilities];
            for (int i = 0; i < numberOfAbilities; i++)
            {
                int xOffset = 0;
                int yOffset = 0;
                if (i >= numberOfAbilities / 2)
                {
                    yOffset = -spacing * 4; // reset y offset
                    xOffset = sideLength; // increment x offset
                }
                offsetList[i] = new Vector2(xOffset, yOffset + i * spacing);
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            texture_width = Selection.Width / Columns;
            texture_height = Selection.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(texture_width * column, texture_height * row, texture_width, texture_height);
            Rectangle destinationRectangle = new Rectangle(x, y, sideLength, sideLength);
            spriteBatch.Draw(Selection, destinationRectangle, sourceRectangle, Color.White);


        }

        public void Update(float newStartX, float newStartY, int index)
        {
            secondFrame++;
            if (secondFrame >= maxSecondFrame)
            {
                CurrentFrame++;
                if (CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
                secondFrame = 0; 
            }

            x = preX + (int)newStartX + (int)offsetList[index].X;
            y = preY + (int)newStartY + (int)offsetList[index].Y;
        }
    }

}
