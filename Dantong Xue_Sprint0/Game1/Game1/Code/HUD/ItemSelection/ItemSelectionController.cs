using Microsoft.Xna.Framework.Input;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Game1.Code.HUD.Sprite;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;

namespace Game1.Code.HUD
{
    /*U for previous item, I for next item*/
    public class ItemSelectionController
    {
        private KeyboardState oldState;
        private KeyboardState newState;
        private InventoryItemSelection selection;
        private InventoryObject inventoryObject;
        private int previewedItemIndex;
        private int selectedItemIndex;
        private Game1 game;

        public ItemSelectionController(Game1 game, List<Tuple<string, int>> inventoryItemList)
        {
            this.game = game;
            selection = new InventoryItemSelection(inventoryItemList);
            inventoryObject = new InventoryObject(game.link.itemList, inventoryItemList);
        }
        public void Update(float newStartX, float newStartY)
        {
            this.newState = Keyboard.GetState();

            if (this.newState.IsKeyDown(Keys.U) && !this.oldState.IsKeyDown(Keys.U))
            {
                selection.MovePrev();
            }
            if (this.newState.IsKeyDown(Keys.I) && !this.oldState.IsKeyDown(Keys.I))
            {
                selection.MoveNext();
            }
            if (this.newState.IsKeyDown(Keys.B) && !this.oldState.IsKeyDown(Keys.B))
            {
                //get the current index and pass it to hudBA
                selectedItemIndex = selection.getIndex();
            }
            previewedItemIndex = selection.getIndex();

            this.oldState = this.newState;
            selection.Update(newStartX, newStartY);
            inventoryObject.Update(newStartX, newStartY, selectedItemIndex, previewedItemIndex);

        }

        public void Draw()
        {
            selection.Draw(game._spriteBatch);
            inventoryObject.Draw(game._spriteBatch);

        }

    }

}
