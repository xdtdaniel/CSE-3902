using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;
using System;
using Game1.Code.LoadFile;
using Game1.Code.Audio;

namespace Game1.Code.Player.PlayerItem.PlayerItemState
{
    class UseBoomerang : IPlayerItemState
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private LinkItem item;
        private int direction;
        private int x;
        private int y;
        private int boomerangSpeed = 2 * scale;
        private int maxBoomerangSpeed = 3 * scale;
        private int currentFrame = 0;
        private int totalFrame = 4;
        private int secondFrame = 0;
        private int maxSecondFrame = 120;
        private int boomerangHitboxOffset = 7 * scale;
        private int linkHitboxSize = 20 * scale;
        private int boomerangSpinFrequency = 10;

        private IPlayerItemSprite frontBoomerang;
        private IPlayerItemSprite rightBoomerang;
        private IPlayerItemSprite backBoomerang;
        private IPlayerItemSprite leftBoomerang;

        private Rectangle rectangle;

        public UseBoomerang(LinkItem item)
        {
            direction = item.direction;
            x = item.x;
            y = item.y;

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
            secondFrame = maxSecondFrame;
        }
        public void Update() 
        {
            // boomerang sounds same as arrow does
            AudioPlayer.arrowShoot.Play();
            if (secondFrame >= maxSecondFrame)
            {
                if (boomerangSpeed <= maxBoomerangSpeed)
                {
                    boomerangSpeed++;
                }
                double xDistance = Math.Abs(item.lastLinkX - x);
                double yDistance = Math.Abs(item.lastLinkY - y);
                double angle = Math.Atan(xDistance / yDistance);
                int xSpeed = Convert.ToInt32(boomerangSpeed * Math.Sin(angle));
                int ySpeed = Convert.ToInt32(boomerangSpeed * Math.Cos(angle));

                if (item.lastLinkX < x)
                {
                    x -= xSpeed;
                }
                else if (item.lastLinkX > x)
                {
                    x += xSpeed;
                }
                if (item.lastLinkY < y)
                {
                    y -= ySpeed;
                }
                else if (item.lastLinkY > y)
                {
                    y += ySpeed;
                }
                
                
                Point point = new Point(x + boomerangHitboxOffset, y + boomerangHitboxOffset);
                Rectangle rec = new Rectangle(item.lastLinkX, item.lastLinkY, linkHitboxSize, linkHitboxSize);
                if (rec.Contains(point))
                {
                    AudioPlayer.arrowShoot.Stop();
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
            if (secondFrame % boomerangSpinFrequency == 0 && secondFrame != 0)
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

