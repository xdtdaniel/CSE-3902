using Microsoft.Xna.Framework.Input;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Game1.Code.HUD.Sprite;
using System.Collections.Generic;
using System;
using Game1.Code.Player.PlayerItem;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Game1.Code.Player.PlayerAbility;

namespace Game1.Code.HUD.AbilitySelection
{
    /*U for previous item, I for next item*/
    public class AbilitySelectionController
    {
        private KeyboardState oldState;
        private KeyboardState newState;
        private InventoryAbilitySelection inventoryAbilitySelection;
        private PlayerAbilityPanel playerAbilityPanel;

        private int type = 0;
        private int index = 0;


        public AbilitySelectionController(PlayerAbilityPanel playerAbilityPanel)
        {
            this.playerAbilityPanel = playerAbilityPanel;
            inventoryAbilitySelection = new InventoryAbilitySelection(playerAbilityPanel);
        }
        public void Update(float newStartX, float newStartY)
        {
            if (index < 0)
            {
                type--;
                if (type < 0)
                {
                    type = playerAbilityPanel.abilityDictList.Count - 1;
                }
                index = playerAbilityPanel.abilityDictList[type].Count - 1;
            }
            else if (index > playerAbilityPanel.abilityDictList[type].Count - 1)
            {
                type++;
                index = 0;
            }
            if (type > playerAbilityPanel.abilityDictList.Count - 1)
            {
                type = 0;
            }
            inventoryAbilitySelection.Update(newStartX, newStartY, index, type);

            newState = Keyboard.GetState();

            if (Camera.pausedType == 2)
            {
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
            }

            // update keyboard state
            oldState = newState;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            inventoryAbilitySelection.Draw(spriteBatch);
        }
    }
}
