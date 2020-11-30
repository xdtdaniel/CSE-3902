using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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
        
        private int maxExpPerLine = 8;
        private int expCount;

        private int preX = 150 * scale;
        private int preY = -30 * scale;
        private int x;
        private int y;
        static public int level = 0;

        Rectangle sourceRectangle;
        Rectangle destinationRectangle;

        public HUDExp(int killedEnemies)
        {
           expCount = killedEnemies;
            //initial values
            exp = HUDFactory.LoadExpPattern();   
            sourceRectangle = new Rectangle();
            destinationRectangle = new Rectangle();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            for (int i = 0; i < (expCount % maxExpPerLine); i++)
            {
                sourceRectangle = new Rectangle(0, 0, exp.Width, exp.Height);
                if ( expCount % maxExpPerLine == 0 && level != 8)
                {
                    level++;
                    destinationRectangle = new Rectangle(x, y, width, height);
                    spriteBatch.Draw(exp, destinationRectangle, sourceRectangle, Color.White);
                }
                else if (expCount % maxExpPerLine != 0 && level != 8)
                {
                    destinationRectangle = new Rectangle(x + (expCount % maxExpPerLine) * width, y, width, height);
                    spriteBatch.Draw(exp, destinationRectangle, sourceRectangle, Color.White);
                }
                else {
                    break;
                }
               
            }
        }
        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX + preX;
            y = (int)newStartY + preY;
            expCount = Enemy.DrawAndUpdateEnemy.numberOfKilled();
        }
    }
}

