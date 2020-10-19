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
    class UseArrow : IPlayerItemState
    {
        PlayerItem item;
        bool used; 
        int direction;
        int x;
        int y;
        int currentFrame;

        IPlayerItemSprite frontArrow;
        IPlayerItemSprite rightArrow;
        IPlayerItemSprite backArrow;
        IPlayerItemSprite leftArrow;

        Rectangle rectangle;

        public UseArrow(PlayerItem item)
        {
            used = false;
            direction = item.direction;
            x = item.x;
            y = item.y;

            currentFrame = 0;

            frontArrow = PlayerItemFactory.Instance.CreateFrontArrow();
            rightArrow = PlayerItemFactory.Instance.CreateRightArrow();
            backArrow = PlayerItemFactory.Instance.CreateBackArrow();
            leftArrow = PlayerItemFactory.Instance.CreateLeftArrow();

            this.item = item;

            rectangle = new Rectangle();
        }
        public void UseItem(int itemNum) 
        {
        }
        public string GetItemName()
        {
            return "Arrow";
        }
        public void CollisionResponse()
        {
            currentFrame = 120;
        }
        public void Update() 
        {
            
            currentFrame++;
            if (currentFrame == 120)
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
                        frontArrow.Draw(spriteBatch, x += 24, y += 48, currentFrame, direction);
                        break;
                    case 1: /* right */
                        rightArrow.Draw(spriteBatch, x += 48, y += 24, currentFrame, direction);
                        break;
                    case 2: /* back */
                        backArrow.Draw(spriteBatch, x += 24, y -= 48, currentFrame, direction);
                        break;
                    case 3: /* left */
                        leftArrow.Draw(spriteBatch, x -= 48, y += 24, currentFrame, direction);
                        break;
                    default:
                        break;
                }
            }
            switch (direction)
            {
                case 0: /* front */
                    rectangle = frontArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    y += 5;
                    break;
                case 1: /* right */
                    rectangle = rightArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    x += 5;
                    break;
                case 2: /* back */
                    rectangle = backArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    y -= 5;
                    break;
                case 3: /* left */
                    rectangle = leftArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    x -= 5;
                    break;
                default:
                    break;
            }
            used = true;
        }
        public Rectangle GetRectangle()
        {
            return rectangle;
        }
    }
}

