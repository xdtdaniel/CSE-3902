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
    class ItemSelectionController
    {
         
        private KeyboardState oldState;
        private KeyboardState newState;
        private InventoryObject inventoryObj;
        private string[] BA;
        private float x;
        private float y;

        public ItemSelectionController(Dictionary<string, int> itemList)
        {
            inventoryObj = new InventoryObject(itemList);
            //get 2 selectino from inventory obj?
            BA = inventoryObj.getBA();

            x = (int)LoadAll.Instance.startPos.X;
            y = (int)LoadAll.Instance.startPos.Y;

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

            inventoryObj.Update(x,y);

            this.oldState = this.newState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            inventoryObj.Draw(spriteBatch);
        }
    }

}
