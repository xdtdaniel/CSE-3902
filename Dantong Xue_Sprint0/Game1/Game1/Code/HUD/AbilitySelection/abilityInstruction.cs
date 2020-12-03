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
    class abilityInstruction:IHUDSprite
    {
        SpriteFont prompt;
        private static int scale = (int)LoadAll.Instance.scale;
        private int x;
        private int y;
        private int offX = 125*scale;
        private int offY = 40 * scale;    
        private int preY = 176 * scale;
        private Game1 game;
        public abilityInstruction(Game1 game)
        {
            /*load sprite font with size 20, bold*/
            prompt = HUDFactory.LoadSkillInstruction();
            this.game = game;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(prompt, "Press [U] and [I] to select skill\n" +
                " from left and right branchs\npress [B] to light up the skill ", new Vector2(x+offX, y+offY), Color.LightBlue);

        }


        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX;
            y = (int)newStartY + preY;
        }
    }
}
