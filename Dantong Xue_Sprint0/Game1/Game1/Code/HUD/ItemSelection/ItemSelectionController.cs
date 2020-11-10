using Microsoft.Xna.Framework.Input;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Game1.Code.HUD.Sprite;

namespace Game1.Code.HUD
{
    /*U for previous item, I for next item*/
    public class ItemSelectionController
    {
        Game1 game;
        private KeyboardState oldState;
        private KeyboardState newState;
        private InventoryItemSelection selection;
        private HUDInventoryAB hudAB;
        private int index;

        public ItemSelectionController(Game1 game)
        {
            this.game = game;
            selection = new InventoryItemSelection(game.link.itemList);
            hudAB = new HUDInventoryAB(game.link.itemList,index);
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
                index = selection.getIndex();               
               
            }

            this.oldState = this.newState;
            selection.Update(newStartX, newStartY);
            hudAB.Update(newStartX, newStartY,index);

        }

        public void Draw()
        {
            selection.Draw(game._spriteBatch);
            hudAB.Draw(game._spriteBatch);
        }
    }

}
