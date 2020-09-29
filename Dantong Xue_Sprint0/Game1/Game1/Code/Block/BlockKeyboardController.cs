using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Game1.Code.Block
{
    class BlockKeyboardController : IController
    {

        private KeyboardState oldState;
        private KeyboardState newState;
        private BlockCollection blockCollection;

        public BlockKeyboardController()
        {
            blockCollection = new BlockCollection();
        }

        public void Update(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Game1 g)
        {
            this.newState = Keyboard.GetState();


            if (this.newState.IsKeyDown(Keys.T) && !this.oldState.IsKeyDown(Keys.T))
            {
                blockCollection.MovePrev();
            }
            if (this.newState.IsKeyDown(Keys.Y) && !this.oldState.IsKeyDown(Keys.Y))
            {
                blockCollection.MoveNext();
            }

            blockCollection.DrawCurrent(spriteBatch, new Vector2(150, 150));

            this.oldState = this.newState;
        }
    }
}
