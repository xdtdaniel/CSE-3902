using Microsoft.Xna.Framework.Input;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Game1.Code.HUD.Sprite;
using System.Collections.Generic;
using System;

namespace Game1.Code.HUD
{
    /*U for previous item, I for next item*/
    public class ItemSelectionController
    {
        private KeyboardState oldState;
        private KeyboardState newState;
        private InventoryItemSelection inventoryItemSelection;
        private InventoryObject inventoryObject;
        private int previewedItemIndex;
        private int selectedItemIndex;
        private Game1 game;
        private int inventoryItemIndex;
        private List<Tuple<string, int>> inventoryItemList;

        public ItemSelectionController(Game1 game, List<Tuple<string, int>> inventoryItemList)
        {
            this.game = game;
            inventoryItemSelection = new InventoryItemSelection();
            inventoryObject = new InventoryObject(game, inventoryItemList);
            inventoryItemIndex = 0;
            this.inventoryItemList = inventoryItemList;
        }
        public void Update(float newStartX, float newStartY)
        {
            
            inventoryItemSelection.Update(newStartX, newStartY, inventoryItemIndex, inventoryItemList.Count);
            inventoryObject.Update(newStartX, newStartY, selectedItemIndex, previewedItemIndex);

            newState = Keyboard.GetState();

            // update index when U is pressed
            if (newState.IsKeyDown(Keys.U) && !oldState.IsKeyDown(Keys.U))
            {
                if (inventoryItemList.Count > 0)
                {
                    inventoryItemIndex--;
                    if (inventoryItemIndex == -1)
                    {
                        inventoryItemIndex = inventoryItemList.Count - 1;
                    }
                }
            }

            // update index when I is pressed
            if (newState.IsKeyDown(Keys.I) && !oldState.IsKeyDown(Keys.I))
            {
                if (inventoryItemList.Count > 0)
                {
                    inventoryItemIndex++;
                    if (inventoryItemIndex == inventoryItemList.Count)
                    {
                        inventoryItemIndex = 0;
                    }
                }
            }

            // make sure index is not out of bound
            if (inventoryItemList.Count > 0 && inventoryItemIndex >= inventoryItemList.Count)
            {
                inventoryItemIndex = inventoryItemList.Count - 1;
               
            }

            // update selected item index when B is pressed or it is out of bound
            if ((newState.IsKeyDown(Keys.B) && !oldState.IsKeyDown(Keys.B)) || selectedItemIndex >= inventoryItemList.Count)
            {
                selectedItemIndex = inventoryItemIndex;
              
            }
            // always update previewed item index
            previewedItemIndex = inventoryItemIndex;
            //if (newState.IsKeyDown(Keys.Z) && !oldState.IsKeyDown(Keys.Z) && inventoryObject.useClock()==true)
            //{
            //    clock = !clock;
            //}


            // update keyboard state
            oldState = newState;

        }
        public bool getClock()
        {
            return inventoryObject.useClock();       
        }
        public int getMapID() 
        {
            return inventoryObject.getMapID();
        }

        public void Draw()
        {
            inventoryItemSelection.Draw(game._spriteBatch);
            inventoryObject.Draw(game._spriteBatch);
        }
    }
}
