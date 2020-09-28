using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Player.PlayerCharacter
{
    class UseArrow : IPlayerItemDrawer
    {
        PlayerItem item;
        bool used; 
        int direction;
        int x;
        int y;
        int currentFrame;

        IPlayerSprite frontArrow;
        IPlayerSprite rightArrow;
        IPlayerSprite backArrow;
        IPlayerSprite leftArrow;

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
        }
        public void UseItem(int itemNum) 
        {
        }
        public void Update() 
        {
            switch (direction)
            {
                case 0: /* front */
                    y += 10;
                    break;
                case 1: /* right */
                    x += 10;
                    break;
                case 2: /* back */
                    y -= 10;
                    break;
                case 3: /* left */
                    x -= 10;
                    break;
                default:
                    break;
            }
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
                        frontArrow.Draw(spriteBatch, x += 40, y += 75, currentFrame, direction);
                        break;
                    case 1: /* right */
                        rightArrow.Draw(spriteBatch, x += 100, y += 40, currentFrame, direction);
                        break;
                    case 2: /* back */
                        backArrow.Draw(spriteBatch, x += 40, y -= 100, currentFrame, direction);
                        break;
                    case 3: /* left */
                        leftArrow.Draw(spriteBatch, x -= 50, y += 40, currentFrame, direction);
                        break;
                    default:
                        break;
                }
            }
            switch (direction)
            {
                case 0: /* front */
                    frontArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 1: /* right */
                    rightArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 2: /* back */
                    backArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 3: /* left */
                    leftArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                default:
                    break;
            }
            used = true;
        }
    }
}

