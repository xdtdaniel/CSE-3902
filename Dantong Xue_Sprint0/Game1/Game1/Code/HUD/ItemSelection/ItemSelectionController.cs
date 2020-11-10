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

        public ItemSelectionController(Game1 game)
        {
            this.game = game;
            selection = new InventoryItemSelection(game.link.itemList);
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
                //add to a list used in hudBA
                //display on inventory 
            }


            this.oldState = this.newState;
            selection.Update(newStartX, newStartY);

        }

        public void Draw()
        {
            selection.Draw(game._spriteBatch);
        }
    }

}
