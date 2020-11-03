using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Game1.Code.LoadFile;

namespace Game1.Player.PlayerCharacter
{
    class UseArrow : IPlayerItemState
    {
        LinkItem item;
        bool used; 
        int direction;
        int x;
        int y;
        int currentFrame;

        int speed;
        int offsetX;
        int offsetY;

        IPlayerItemSprite frontArrow;
        IPlayerItemSprite rightArrow;
        IPlayerItemSprite backArrow;
        IPlayerItemSprite leftArrow;

        Rectangle rectangle;

        public UseArrow(LinkItem item)
        {
            used = false;
            direction = item.direction;
            x = item.x;
            y = item.y;

            currentFrame = 0;

            speed = 15;
            offsetX = 9;
            offsetY = 7;

            frontArrow = PlayerItemFactory.Instance.CreateFrontArrow();
            rightArrow = PlayerItemFactory.Instance.CreateRightArrow();
            backArrow = PlayerItemFactory.Instance.CreateBackArrow();
            leftArrow = PlayerItemFactory.Instance.CreateLeftArrow();

            this.item = item;

            rectangle = new Rectangle();
        }
        public void UseItem(string itemName) 
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
            if (currentFrame >= 120)
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
                        frontArrow.Draw(spriteBatch, x += (int)(13 * LoadAll.Instance.scale) / 2 - offsetX, y += (int)(13 * LoadAll.Instance.scale), currentFrame, direction);
                        break;
                    case 1: /* right */
                        rightArrow.Draw(spriteBatch, x += (int)(13 * LoadAll.Instance.scale), y += (int)(13 * LoadAll.Instance.scale) / 2 - offsetY, currentFrame, direction);
                        break;
                    case 2: /* back */
                        backArrow.Draw(spriteBatch, x += (int)(13 * LoadAll.Instance.scale) / 2 - offsetX, y -= (int)(13 * LoadAll.Instance.scale), currentFrame, direction);
                        break;
                    case 3: /* left */
                        leftArrow.Draw(spriteBatch, x -= (int)(13 * LoadAll.Instance.scale), y += (int)(13 * LoadAll.Instance.scale) / 2 - offsetY, currentFrame, direction);
                        break;
                    default:
                        break;
                }
            }
            switch (direction)
            {
                case 0: /* front */
                    y += speed;
                    rectangle = frontArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 1: /* right */
                    x += speed;
                    rectangle = rightArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 2: /* back */
                    y -= speed;
                    rectangle = backArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 3: /* left */
                    x -= speed;
                    rectangle = leftArrow.Draw(spriteBatch, x, y, currentFrame, direction);
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
        public bool IsDone()
        {
            return false;
        }
    }
}

