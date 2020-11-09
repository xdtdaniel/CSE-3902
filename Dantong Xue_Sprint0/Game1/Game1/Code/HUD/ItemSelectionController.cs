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
        private InventoryItenSelection selection;

        public ItemSelectionController(Game1 game)
        {
            this.game = game;
            selection = new InventoryItenSelection(game.link.itemList);

 

        }
        public void Update(float newStartX, float newStartY)
        {
            this.newState = Keyboard.GetState();

            if (this.newState.IsKeyDown(Keys.U) && !this.oldState.IsKeyDown(Keys.U))
            {
                selection.MovePrev(newStartX, newStartY);
            }
            if (this.newState.IsKeyDown(Keys.I) && !this.oldState.IsKeyDown(Keys.I))
            {
                selection.MoveNext(newStartX, newStartY);
            }
            selection.UpdateSelection();
            this.oldState = this.newState;

        }

        public void Draw()
        {
            selection.DrawSelection(game._spriteBatch);
        }
    }

}
