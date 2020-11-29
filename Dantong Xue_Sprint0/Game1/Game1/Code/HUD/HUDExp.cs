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
        private int x;
        private int y;
        private int maxExpPerLine = 16;
        private int expCount;

        private int preX = 172 * scale;
        private int preY = -28 * scale;
        private int level = 0;

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

            for (int i = 0; i < expCount; i++)
            {
                if (i % maxExpPerLine!=0)
                {
                    sourceRectangle = new Rectangle(0, 0, exp.Width, exp.Height);
                    destinationRectangle = new Rectangle(x + i * width, y, width, height);
                    spriteBatch.Draw(exp, destinationRectangle, sourceRectangle, Color.White);
                }

                else {
                   
                    i = 0;
                    //spriteBatch.Draw(exp, destinationRectangle, sourceRectangle, Color.White);
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

