using Microsoft.Xna.Framework.Input;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Game1.Code.HUD.Sprite;
using System.Collections.Generic;
using System;
using Game1.Code.Player.PlayerItem;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Game1.Code.HUD.AbilitySelection
{
    /*U for previous item, I for next item*/
    public class AbilitySelectionController
    {
        private KeyboardState oldState;
        private KeyboardState newState;
        private InventoryAbilitySelection inventoryAbilitySelection = new InventoryAbilitySelection();
        private PlayerAbilityPanel playerAbilityPanel;

        private int type = 0;
        private int index = 0;

        public AbilitySelectionController(PlayerAbilityPanel playerAbilityPanel)
        {
            this.playerAbilityPanel = playerAbilityPanel;
        }
        public void Update(float newStartX, float newStartY)
        {
            if (index < 0)
            {
                type = playerAbilityPanel.treeList.Count - 1;
                index = playerAbilityPanel.treeList[type].Count - 1;
            }
            else if (index > playerAbilityPanel.treeList[type].Count - 1)
            {
                type++;
                index = 0;
            }
            if (type > playerAbilityPanel.treeList.Count - 1)
            {
                type = 0;
            }
            Debug.Print("type: " + type.ToString());
            Debug.Print("index: " + index.ToString());
            Debug.Print("global Index: " + playerAbilityPanel.GetGlobalIndex(type, index).ToString());
            inventoryAbilitySelection.Update(newStartX, newStartY, playerAbilityPanel.GetGlobalIndex(type, index));

            newState = Keyboard.GetState();

            // update index when U is pressed
            if (newState.IsKeyDown(Keys.U) && !oldState.IsKeyDown(Keys.U))
            {
                index--;
            }

            // update index when I is pressed
            if (newState.IsKeyDown(Keys.I) && !oldState.IsKeyDown(Keys.I))
            {
                index++;
            }

            // update selected item index when B is pressed or it is out of bound
            if ((newState.IsKeyDown(Keys.B) && !oldState.IsKeyDown(Keys.B)))
            {
                playerAbilityPanel.Learn(type, index);

            }
            // always update previewed item index

            // update keyboard state
            oldState = newState;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            inventoryAbilitySelection.Draw(spriteBatch);
        }
    }
}
