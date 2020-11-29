using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Game1.Code.Player.PlayerItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Game1.Code.Player.PlayerAbility;

namespace Game1.Code.HUD.AbilitySelection
{
    public class InventoryAbilitySelection
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int sideLength = 25 * scale;
        private int spacing_x = 36 * scale;
        private int spacing_y = 54 * scale;
        private static int preX = 31 * scale;
        private static int preY = 217 * scale;
        private int selection_x;
        private int selection_y;
        private int black_x;
        private int black_y;
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

        private PlayerAbilityPanel playerAbilityPanel;

        private Texture2D Selection;
        private Texture2D blackSpot;

        public InventoryAbilitySelection(PlayerAbilityPanel playerAbilityPanel)
        {
            this.playerAbilityPanel = playerAbilityPanel;
            //load selections
            Selection = HUDFactory.LoadInventorySelection();

            offsetList = new Vector2[numberOfAbilities];
            for (int i = 0; i < numberOfAbilities; i++)
            {
                int xOffset = 0;
                int yOffset = 0;
                if (i >= numberOfAbilities / 2)
                {
                    yOffset = -spacing_x * 4; // reset y offset
                    xOffset = spacing_y; // increment x offset
                }
                offsetList[i] = new Vector2(xOffset, yOffset + i * spacing_x);
            }
            blackSpot = HUDFactory.LoadBlackSpot();

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            texture_width = Selection.Width / Columns;
            texture_height = Selection.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            for (int i = 0; i < playerAbilityPanel.abilityDictList.Count; i++)
            {
                for (int j = 0; j < playerAbilityPanel.abilityDictList[i].Count; j++) {
                    if (!playerAbilityPanel.abilityDictList[i][j].IsLearned())
                    {
                        int index = playerAbilityPanel.GetGlobalIndex(i, j);
                        sourceRectangle = new Rectangle(0, 0, blackSpot.Width, blackSpot.Height);
                        destinationRectangle = new Rectangle(black_x + (int)offsetList[index].X, black_y + (int)offsetList[index].Y, sideLength, sideLength);

                        spriteBatch.Draw(blackSpot, destinationRectangle, sourceRectangle, Color.White * 0.8f);
                    }
                }
            }
            sourceRectangle = new Rectangle(texture_width * column, texture_height * row, texture_width, texture_height);
            destinationRectangle = new Rectangle(selection_x, selection_y, sideLength, sideLength);
            spriteBatch.Draw(Selection, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(float newStartX, float newStartY, int index, int type)
        {
            int globalIndex = playerAbilityPanel.GetGlobalIndex(type, index);
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

            selection_x = preX + (int)newStartX + (int)offsetList[globalIndex].X;
            selection_y = preY + (int)newStartY + (int)offsetList[globalIndex].Y;
            black_x = preX + (int)newStartX;
            black_y = preY + (int)newStartY;
        }
    }

}
