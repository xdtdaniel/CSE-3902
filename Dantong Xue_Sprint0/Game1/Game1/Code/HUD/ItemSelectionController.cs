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
        Game1 game;
        private KeyboardState oldState;
        private KeyboardState newState;
        private InventoryObject inventoryObj;

        public ItemSelectionController(Game1 game)
        {
            this.game = game;
            inventoryObj = new InventoryObject(game.link.itemList);

 

        }
        public void Update(float newStartX, float newStartY)
        {
            this.newState = Keyboard.GetState();


            if (this.newState.IsKeyDown(Keys.U) && !this.oldState.IsKeyDown(Keys.U))
            {
                inventoryObj.MovePrev(newStartX, newStartY);
            }
            if (this.newState.IsKeyDown(Keys.I) && !this.oldState.IsKeyDown(Keys.I))
            {
                inventoryObj.MoveNext(newStartX, newStartY);
            }

            this.oldState = this.newState;

            //inventoryObj.UpdateSelection(newStartX, newStartY);
        }

        public void Draw()
        {
            inventoryObj.DrawSelection(game._spriteBatch);
        }
    }

}
