using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.LoadFile
{
    class MouseEnemyController
    {

        // This is a test controller class for Sprint3. Be aware that this class does NOT implement the IController Interface.

        private MouseState oldState;
        private MouseState newState;

        public MouseEnemyController()
        {

        }

        public void Update(LoadEnemy enemyLoader)
        {
            newState = Mouse.GetState();

            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton != ButtonState.Pressed)
            {
                enemyLoader.Next();               
            }
            else if (newState.RightButton == ButtonState.Pressed && oldState.RightButton != ButtonState.Pressed)
            {
                enemyLoader.Previous();
            }

            oldState = newState;
        }
    }
}
