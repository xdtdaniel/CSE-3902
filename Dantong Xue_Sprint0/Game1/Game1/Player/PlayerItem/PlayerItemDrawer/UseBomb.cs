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
    class UseBomb : IPlayerItemDrawer
    {
        PlayerItem item;
        bool used; /* indicate if an item is used */
        int x;
        int y;
        int direction;
        int currentFrame;
        int totalFrame;
        int secondFrame;

        IPlayerSprite bomb;
        IPlayerSprite bombExplosion;

        Rectangle rectangle;
        public UseBomb(PlayerItem item)
        {
            used = false;
            this.x = item.x;
            this.y = item.y;
            this.direction = item.direction;

            currentFrame = 0;
            totalFrame = 3;
            secondFrame = 0;

            bomb = PlayerItemFactory.Instance.CreateBomb();
            bombExplosion = PlayerItemFactory.Instance.CreateBombExplosion();

            this.item = item;
        }
        public void UseItem(int itemNum) 
        {
        }
        public void Update() 
        { 
            secondFrame++;
            /* explode after 60 frames */
            if (secondFrame == 80)
            {
                currentFrame++;
                secondFrame = 60;
            }
            if (currentFrame == totalFrame)
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
                        x += 20;
                        y += 100;
                        break;
                    case 1: /* right */
                        x += 135;
                        break;
                    case 2: /* back */
                        x += 20;
                        y -= 100;
                        break;
                    case 3: /* left */
                        x -= 100;
                        break;
                    default:
                        break;
                }
            }
            if (currentFrame == 0)
            {
                rectangle = bomb.Draw(spriteBatch, x, y, currentFrame, direction);
            }
            else 
            {
                rectangle = bombExplosion.Draw(spriteBatch, x, y, currentFrame, direction);
            }
            used = true;
        }

        public Rectangle GetRectangle()
        {
            return rectangle;
        }
    }
}

