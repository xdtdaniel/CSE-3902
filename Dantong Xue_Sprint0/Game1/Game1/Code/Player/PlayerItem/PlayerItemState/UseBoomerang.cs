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
    class UseBoomerang : IPlayerItemState
    {
        LinkItem item;
        int direction;
        int x;
        int y;
        int boomerangSpeed;
        int currentFrame;
        int totalFrame;
        int secondFrame;

        IPlayerItemSprite frontBoomerang;
        IPlayerItemSprite rightBoomerang;
        IPlayerItemSprite backBoomerang;
        IPlayerItemSprite leftBoomerang;

        Rectangle rectangle;

        public UseBoomerang(LinkItem item)
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

            rectangle = new Rectangle();
        }
        public void UseItem(string itemName) 
        {
        }
        public string GetItemName()
        {
            return "Boomerang";
        }
        public void CollisionResponse()
        {
            secondFrame = 120;
        }
        public void Update() 
        {
            if (secondFrame >= 120)
            {
                if (boomerangSpeed <= 10)
                {
                    boomerangSpeed++;
                }
                double xDistance = Math.Abs(item.linkX - x);
                double yDistance = Math.Abs(item.linkY - y);
                double angle = Math.Atan(xDistance / yDistance);
                int xSpeed = Convert.ToInt32(boomerangSpeed * Math.Sin(angle));
                int ySpeed = Convert.ToInt32(boomerangSpeed * Math.Cos(angle));

                if (item.linkX < x)
                {
                    x -= xSpeed;
                }
                else if (item.linkX > x)
                {
                    x += xSpeed;
                }
                if (item.linkY < y)
                {
                    y -= ySpeed;
                }
                else if (item.linkY > y)
                {
                    y += ySpeed;
                }
                
                
                Point point = new Point(x + (int)(7 * LoadAll.Instance.scale), y + (int)(7 * LoadAll.Instance.scale));
                Rectangle rec = new Rectangle(item.linkX, item.linkY, 50, 50);
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
                        y += boomerangSpeed;
                        break;
                    case 1: /* right */
                        x += boomerangSpeed;
                        break;
                    case 2: /* back */
                        y -= boomerangSpeed;
                        break;
                    case 3: /* left */
                        x -= boomerangSpeed;
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
                    rectangle = frontBoomerang.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 1:
                    rectangle = rightBoomerang.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 2:
                    rectangle = backBoomerang.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 3:
                    rectangle = leftBoomerang.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                default:
                    break;
            }
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

