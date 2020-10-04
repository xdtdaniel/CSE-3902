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
    class UseBoomerang : IPlayerItemDrawer
    {
        PlayerItem item;
        int direction;
        int x;
        int y;
        int boomerangSpeed;
        int currentFrame;
        int totalFrame;
        int secondFrame;

        IPlayerSprite frontBoomerang;
        IPlayerSprite rightBoomerang;
        IPlayerSprite backBoomerang;
        IPlayerSprite leftBoomerang;

        public UseBoomerang(PlayerItem item)
        {
            direction = item.direction;
            x = item.x;
            y = item.y;
            boomerangSpeed = 5;

            currentFrame = 0;
            totalFrame = 4;
            secondFrame = 0;

            frontBoomerang = PlayerItemFactory.Instance.CreateFrontBoomerang();
            rightBoomerang = PlayerItemFactory.Instance.CreateRightBoomerang();
            backBoomerang = PlayerItemFactory.Instance.CreateBackBoomerang();
            leftBoomerang = PlayerItemFactory.Instance.CreateLeftBoomerang();

            this.item = item;
        }
        public void UseItem(int itemNum) 
        {
        }
        public void Update() 
        {
            if (secondFrame > 120)
            {
                if (boomerangSpeed < 20)
                {
                    boomerangSpeed++;
                }
                double xDistance = Math.Abs(item.x - x);
                double yDistance = Math.Abs(item.y - y);
                double angle = Math.Atan(xDistance / yDistance);
                int xSpeed = Convert.ToInt32(boomerangSpeed * Math.Sin(angle));
                int ySpeed = Convert.ToInt32(boomerangSpeed * Math.Cos(angle));

                if (item.x < x)
                {
                    x -= xSpeed;
                }
                else if (item.x > x)
                {
                    x += xSpeed;
                }
                if (item.y < y)
                {
                    y -= ySpeed;
                }
                else if (item.y > y)
                {
                    y += ySpeed;
                }
                
                
                Point point = new Point(x + 30, y + 50);
                Rectangle rec = new Rectangle(item.x, item.y, 100, 100);
                if (rec.Contains(point))
                {
                    item.state = new NoItem(item);
                }
            }
            else
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
            }
           

            secondFrame++;
            if (secondFrame % 10 == 0 && secondFrame != 0)
            {
                currentFrame++;
            }
            if (currentFrame == totalFrame)
            {
                currentFrame = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (currentFrame)
            {
                case 0:
                    frontBoomerang.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 1:
                    rightBoomerang.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 2:
                    backBoomerang.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 3:
                    leftBoomerang.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                default:
                    break;
            }
        }
    }
}

