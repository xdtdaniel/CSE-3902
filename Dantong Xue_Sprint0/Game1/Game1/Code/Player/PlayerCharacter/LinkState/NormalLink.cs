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
    class NormalLink : IPlayerLinkState
    {
        int currentFrame;
        int totalFrame;
        int secondFrame;
        int thirdFrame;

        IPlayerSprite[] linkSprite;
        IPlayerSprite[][] damagedLinkSprite;

        Link link;

        public NormalLink(Link link)
        {
            currentFrame = 0;
            totalFrame = 2;
            secondFrame = 0;
            thirdFrame = 0;

            linkSprite = new IPlayerSprite[4];
            for (int i = 0; i < 4; i++)
            {
                linkSprite[i] = PlayerCharacterFactory.Instance.CreateNormalLink(i);
            }

            damagedLinkSprite = new IPlayerSprite[4][];
            for (int i = 0; i < 4; i++)
            {
                damagedLinkSprite[i] = PlayerCharacterFactory.Instance.CreateDamagedLink(i);
            }
            this.link = link;
        }

        public void AttackN()
        {
            link.state = new WoodenSwordLink(link);
        }
        public void AttackZ()
        {
            link.state = new SwordBeamLink(link);
        }
        public void UseItem()
        {
            link.state = new UseItemLink(link);
        }
        public void TakeDamage()
        {
            link.damageTimeCounter = 0;
            link.isDamaged = true;
        }
        public void PickUp(int pickUp)
        {
            if (pickUp == 0)
            {
                link.state = new OneHandPickUpLink(link);
            }
            else if (pickUp == 1)
            {
                link.state = new TwoHandPickUpLink(link);
            }
        }
        public void Update(ref int x, ref int y, int direction, bool isMoving)
        {
            link.damageTimeCounter++;
            if (link.damageTimeCounter == 90)
            {
                link.damageTimeCounter = 0;
                link.isDamaged = false;
            }

            if (link.damageTimeCounter % 8 == 0) {
                thirdFrame++;
                if (thirdFrame == 4)
                {
                    thirdFrame = 0;
                }
            }
            if (isMoving)
            {
                secondFrame++;
                if (secondFrame == 15)
                {
                    currentFrame++;
                    secondFrame = 0;
                }

                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                }

                switch (direction)
                {
                    case 0: /* front */
                        if (y < 2560)
                        {
                            y += 5;
                        }
                        break;
                    case 1: /* right */
                        if (x < 1440)
                        {
                            x += 5;
                        }
                        break;
                    case 2: /* back */
                        if (y > 0)
                        {
                            y -= 5;
                        }
                        break;
                    case 3: /* left */
                        if (x > 0)
                        {
                            x -= 5;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, int x, int y, int direction)
        {
            if (!link.isDamaged)
            {
                linkSprite[direction].Draw(spriteBatch, x, y, currentFrame, direction);
            }
            else
            {
                damagedLinkSprite[direction][thirdFrame].Draw(spriteBatch, x, y, currentFrame, direction);
                
            }
        }
    }
}

