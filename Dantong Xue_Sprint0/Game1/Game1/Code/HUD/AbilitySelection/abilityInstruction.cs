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
    class abilityInstruction 
    {
        SpriteFont prompt;
        private int x;
        private int y;
        public abilityInstruction(int position_x, int position_y)
        {
            /*load sprite font with size 20, bold*/
            prompt = HUDFactory.LoadSkillInstruction();
            x = position_x;
            y = position_y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(prompt, "Press [I] to select skill\npress [B] to light up the skill ", new Vector2(LoadAll.Instance.startPos.X+x, LoadAll.Instance.startPos.Y+y), Color.BlanchedAlmond);

        }

        public void Update()
        {       

        }
   
    }
}
