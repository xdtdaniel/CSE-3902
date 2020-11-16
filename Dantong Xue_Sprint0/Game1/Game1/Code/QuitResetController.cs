using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Game1.Code.Item.ItemInterface;
using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using System.Diagnostics;

namespace Game1
{
    class QuitResetController 
    {
        private KeyboardState oldState;
        private KeyboardState newState;
        public QuitResetController(){

    }
        public void Update(Game1 game)
        {
            this.newState = Keyboard.GetState();


            if (this.newState.IsKeyDown(Keys.Q) && !this.oldState.IsKeyDown(Keys.Q))
            {
                game.Exit();
            }
            if (this.newState.IsKeyDown(Keys.R) && !this.oldState.IsKeyDown(Keys.R))
            {
                game.Exit();
                Process.Start("Game1","");
            }
         

            this.oldState = this.newState;
        }
    }
}
