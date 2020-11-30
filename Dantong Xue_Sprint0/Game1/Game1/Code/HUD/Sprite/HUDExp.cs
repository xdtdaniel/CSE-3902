using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
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
        
        private int maxExpPerLine = 10;
        private int expCount;
        private int x;
        private int y;
        private int preX = 184 * scale;
        private int preY = -30 * scale;
        
        static public int level;


        public HUDExp(int killedEnemies)
        {
           expCount = killedEnemies;
            //initial values
            exp = HUDFactory.LoadExpPattern();   
        }

        public void Draw(SpriteBatch spriteBatch)
        {



            if ((expCount % maxExpPerLine != 0 || expCount == 0 )&& level!=8)
            {
                for (int i = 0; i < expCount-(level*maxExpPerLine); i++)
                {
                    Rectangle sourceRectangle = new Rectangle(0, 0, exp.Width, exp.Height);
                    Rectangle destinationRectangle = new Rectangle(x + i * width, y, width, height);
                    spriteBatch.Draw(exp, destinationRectangle, sourceRectangle, Color.White);
                }
            }
          

            if (expCount/maxExpPerLine==1) {
                level =1;
               
            }
            if (expCount / maxExpPerLine == 2) {
                level = 2;
            }
            if (expCount / maxExpPerLine ==3)
            {
                level = 3;
            }
            if (expCount / maxExpPerLine == 4)
            {
                level =4;
            }
            if (expCount / maxExpPerLine == 5)
            {
                level = 5;
            }
            if (expCount / maxExpPerLine == 6)
            {
                level = 6;
            }
            if (expCount / maxExpPerLine == 7)
            {
                level = 7;
            }
            if (expCount / maxExpPerLine == 8)
            {
                level = 8;
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

