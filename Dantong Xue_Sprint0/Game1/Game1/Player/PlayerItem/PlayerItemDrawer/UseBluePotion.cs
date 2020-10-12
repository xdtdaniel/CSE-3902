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
    class UseBluePotion : IPlayerItemDrawer
    {
        PlayerItem item;
        bool used;
        int direction;
        int x;
        int y;
        int currentFrame;

        IPlayerSprite bluePotion;

        public UseBluePotion(PlayerItem item)
        {
            used = false;
            direction = item.direction;
            x = item.x;
            y = item.y;
            currentFrame = 0;

            bluePotion = PlayerItemFactory.Instance.CreateBluePotion();

            this.item = item;
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
                        x += 25;
                        y += 100;
                        break;
                    case 1: /* right */
                        x += 120;
                        break;
                    case 2: /* back */
                        x += 25;
                        y -= 100;
                        break;
                    case 3: /* left */
                        x -= 70;
                        break;
                    default:
                        break;
                }
            }
            bluePotion.Draw(spriteBatch, x, y, currentFrame, direction);
            used = true;
        }
    }
}

