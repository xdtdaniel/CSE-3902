using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Game1.Code.Item.ItemInterface;

namespace Game1.Code.Item
{
    class ItemKeyboardController
    {
        private KeyboardState oldState;
        private KeyboardState newState;
        private ItemList itemlist;

        public ItemKeyboardController() {
            itemlist = new ItemList();
        }
        public void Update(Game1 game)
        {
            this.newState = Keyboard.GetState();


            if (this.newState.IsKeyDown(Keys.U) && !this.oldState.IsKeyDown(Keys.U))
            {
                itemlist.MovePrev();
            }
            if (this.newState.IsKeyDown(Keys.I) && !this.oldState.IsKeyDown(Keys.I))
            {
                itemlist.MoveNext();
            }

            itemlist.Update();
            game.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 10.0f);

            this.oldState = this.newState;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y) {
            itemlist.Draw(spriteBatch, x, y);
        }
    }
}
