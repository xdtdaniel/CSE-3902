using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Game1.Code.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;
namespace Game1.Code.HUD.Sprite
{
    public class HUDExp : IHUDSprite
    {
        private Texture2D exp;

        private static int scale = (int)LoadAll.Instance.scale;
        private int height = 6 * scale;
        private int width = 4  * scale;
        
        private int x;
        private int y;
        private int preX = 184 * scale;
        private int preY = -30 * scale;
        private int numOfExp;
        
        static public int level;

        private Link link;

        public HUDExp(Link link)
        {
            this.link = link;
            //initial values
            exp = HUDFactory.LoadExpPattern();   
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < numOfExp; i++)
            {
                Rectangle sourceRectangle = new Rectangle(0, 0, exp.Width, exp.Height);
                Rectangle destinationRectangle = new Rectangle(x + i * width, y, width, height);
                spriteBatch.Draw(exp, destinationRectangle, sourceRectangle, Color.White);
            }

        }
        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX + preX;
            y = (int)newStartY + preY;
            numOfExp = link.exp % link.expPerLevel;
        }
    }
}

