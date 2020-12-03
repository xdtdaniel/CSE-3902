using System;
using System.Collections.Generic;
using System.Text;
using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;


namespace Game1.Code.HUD.Sprite
{    
    class promptText 
    {
        SpriteFont prompt;
        private int x;
        private int y;
        public promptText(int position_x, int position_y)
        {
            /*load sprite font with size 32, bold*/
            prompt =  HUDFactory.LoadLevelUpPrompt();
            x = position_x;
            y = position_y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(prompt, "Level Up\nPress [O] to assign ability points", new Vector2(LoadAll.Instance.startPos.X+x, LoadAll.Instance.startPos.Y+y), Color.Azure);

        }

        public void Update()
        {       

        }
   
    }
}
