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
    class UseBluePotion : IPlayerItemState
    {
        LinkItem item;
        bool used;
        int direction;
        int x;
        int y;
        int currentFrame;

        IPlayerItemSprite bluePotion;

        Rectangle rectangle;

        public UseBluePotion(LinkItem item)
        {
            used = false;
            direction = item.direction;
            x = item.x;
            y = item.y;
            currentFrame = 0;

            bluePotion = PlayerItemFactory.Instance.CreateBluePotion();

            this.item = item;

            rectangle = new Rectangle();
        }
        public void UseItem(string itemName) 
        {
        }
        public string GetItemName()
        {
            return "BluePotion";
        }
        public void CollisionResponse()
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
            rectangle = bluePotion.Draw(spriteBatch, x, y, currentFrame, direction);
            used = true;
        }

        public Rectangle GetRectangle()
        {
            return rectangle;
        }
        public bool IsDone()
        {
            return false;
        }
    }
}

