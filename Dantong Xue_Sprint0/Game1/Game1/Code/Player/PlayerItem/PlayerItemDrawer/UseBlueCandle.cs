using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Player.PlayerCharacter
{
    class UseBlueCandle : IPlayerItemDrawer
    {
        PlayerItem item;
        bool used;
        int direction;
        int x;
        int y;
        int currentFrame;

        IPlayerSprite blueCandle;

        Rectangle rectangle;
        public UseBlueCandle(PlayerItem item)
        {
            used = false;
            direction = item.direction;
            x = item.x;
            y = item.y;
            currentFrame = 0;

            blueCandle = PlayerItemFactory.Instance.CreateBlueCandle();

            this.item = item;

            rectangle = new Rectangle();
        }
        public void UseItem(int itemNum) 
        {
        }
        public void Update() 
        {
            currentFrame++;
            if (currentFrame == 10)
            {
                item.state = new NoItem(item);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!used)
            {
                switch (direction)
                {
                    case 0: /* front */
                        x += 12;
                        y += 100;
                        break;
                    case 1: /* right */
                        x += 115;
                        break;
                    case 2: /* back */
                        x += 12;
                        y -= 100;
                        break;
                    case 3: /* left */
                        x -= 90;
                        break;
                    default:
                        break;
                }
            }
            rectangle = blueCandle.Draw(spriteBatch, x, y, currentFrame, direction);
            used = true;
        }

        public Rectangle GetRectangle()
        {
            return rectangle;
        }
    }
}

