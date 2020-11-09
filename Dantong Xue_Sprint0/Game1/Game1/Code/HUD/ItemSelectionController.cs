using Game1.Code.HUD.Factory;
using Game1.Code.Item.ItemFactory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using System.Diagnostics;
using Game1.Code.HUD.Sprite;
using Game1.Code.HUD;
using System.Windows.Forms.VisualStyles;

namespace Game1.Code.HUD
{
    /*U for previous item, I for next item*/
    public class ItemSelectionController
    {
         
        private KeyboardState oldState;
        private KeyboardState newState;
        private InventoryObject inventoryObj;

        public ItemSelectionController(Dictionary<string, int> itemList)
        {
            inventoryObj = new InventoryObject(itemList);

 

        }
        public void Update(Game1 game)
        {
            this.newState = Keyboard.GetState();


            if (this.newState.IsKeyDown(Keys.U) && !this.oldState.IsKeyDown(Keys.U))
            {
                inventoryObj.MovePrev();
            }
            if (this.newState.IsKeyDown(Keys.I) && !this.oldState.IsKeyDown(Keys.I))
            {
                inventoryObj.MoveNext();
            }
            // pass start position to update method.
            inventoryObj.Update(0,  56 * 3);

            this.oldState = this.newState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            inventoryObj.DrawSelection(spriteBatch);
        }
    }

}
