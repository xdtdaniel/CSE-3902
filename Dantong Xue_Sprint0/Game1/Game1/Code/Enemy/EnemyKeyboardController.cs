using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Enemy
{
    class EnemyKeyboardController
    {
        private KeyboardState OldState;
        private KeyboardState NewState;
        private EnemyCollection EnemyCollection;

        public EnemyKeyboardController()
        {
            EnemyCollection = new EnemyCollection();
        }

        public void Update(Game game)
        {
            NewState = Keyboard.GetState();

            if (NewState.IsKeyDown(Keys.O) && !OldState.IsKeyDown(Keys.O))
            {
                EnemyCollection.Previous();
            }
            if (NewState.IsKeyDown(Keys.P) && !OldState.IsKeyDown(Keys.P))
            {
                EnemyCollection.Next();
            }

            EnemyCollection.Update(game);
            OldState = NewState;
        }

        public void Draw(SpriteBatch spriteBatch) {
            EnemyCollection.Draw(spriteBatch);
        }
    }
}
