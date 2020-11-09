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
                selection.MovePrev();
            }
            if (this.newState.IsKeyDown(Keys.I) && !this.oldState.IsKeyDown(Keys.I))
            {
                selection.MoveNext();
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
