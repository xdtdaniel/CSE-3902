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
    class KnockedBackLink : IPlayerLinkState
    {
        int currentFrame;
        int thirdFrame;
        string collisionSide;

        IPlayerSprite[] damagedLinkSprite;

        Link link;

        Rectangle rectangle;
        public KnockedBackLink(Link link, string direction, string collisionSide)
        {
            currentFrame = 0;
            thirdFrame = 0;
            this.collisionSide = collisionSide;

            int index = 0;
            switch (direction)
            {
                case "down":
                    index = 0;
                    break;
                case "right":
                    index = 1;
                    break;
                case "up":
                    index = 2;
                    break;
                case "left":
                    index = 3;
                    break;
                default:
                    break;
            }
            damagedLinkSprite = new IPlayerSprite[4];
            damagedLinkSprite = PlayerCharacterFactory.Instance.CreateDamagedLink(index);
             

            this.link = link;

            rectangle = new Rectangle();
        }
        public void AttackN() { }
        public void AttackZ() { }
        public void UseItem() { }
        public void PickUp(int pickUp) { }

        public void TakeDamage()
        {
        }
        public void KnockedBack(string direction, string collisionSide)
        {
        }
        public void Update(ref int x, ref int y, int direction, bool isMoving)
        {
            if (link.isDamaged)
            {
                link.damageTimeCounter++;
            }
            if (link.damageTimeCounter == 90)
            {
                link.damageTimeCounter = 0;
                link.isDamaged = false;
            }
            if (link.damageTimeCounter % 8 == 0)
            {
                thirdFrame++;
                if (thirdFrame == 4)
                {
                    thirdFrame = 0;
                }
            }

            switch (collisionSide)
            {
                case "down":
                    y -= 10;
                    break;
                case "right":
                    x -= 10;
                    if (currentFrame < 10)
                    {
                        y -= 5;
                    }
                    else
                    {
                        y += 5;
                    }
                    break;
                case "up":
                    y += 10;
                    break;
                case "left":
                    x += 10;
                    if (currentFrame < 10)
                    {
                        y -= 5;
                    }
                    else
                    {
                        y += 5;
                    }
                    break;
                default:
                    break;
            }

            currentFrame++;
            if (currentFrame == 20)
            {
                currentFrame = 0;
                link.state = new NormalLink(link);
            }
        }
        public void Draw(SpriteBatch spriteBatch, int x, int y, int direction)
        {
            
            rectangle = damagedLinkSprite[thirdFrame].Draw(spriteBatch, x, y, 1, direction);
            
        }
        public Rectangle GetRectangle()
        {
            return rectangle;
        }
    }
}

