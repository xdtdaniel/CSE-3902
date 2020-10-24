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

        IPlayerLinkSprite[] linkSprite;
        IPlayerLinkSprite[][] damagedLinkSprite;

        Link link;


        public NormalLink(Link link)
        {
            currentFrame = 0;
            totalFrame = 2;
            secondFrame = 0;
            thirdFrame = 0;

            linkSprite = new IPlayerLinkSprite[4];
            for (int i = 0; i < 4; i++)
            {
                linkSprite[i] = PlayerCharacterFactory.Instance.CreateNormalLink(i);
            }

            damagedLinkSprite = new IPlayerLinkSprite[4][];
            for (int i = 0; i < 4; i++)
            {
                damagedLinkSprite[i] = PlayerCharacterFactory.Instance.CreateDamagedLink(i);
            }
            this.link = link;
            link.movable = true;
        }

        public void AttackN()
        {
            link.movable = false;
            link.state = new WoodenSwordLink(link);
        }
        public void AttackZ()
        {
            link.movable = false;
            link.state = new SwordBeamLink(link);
        }
        public void UseItem()
        {
            link.movable = false;
            link.state = new UseItemLink(link);
        }
        public void TakeDamage()
        {
            link.damageTimeCounter = 0;
            link.isDamaged = true;
            // test collision
            link.hp -= 10;
        }
        public void PickUp(int pickUp)
        {
            link.movable = false;
            if (pickUp == 0)
            {
                link.state = new OneHandPickUpLink(link);
            }
            else if (pickUp == 1)
            {
                link.state = new TwoHandPickUpLink(link);
            }
            else if (pickUp == 2)
            {
                link.state = new TwoHandHoldTriforceLink(link);
            }
            else if (pickUp == 3) {
                link.state = new OneHandHoldBow(link);
            }
        }
        public void KnockedBack(string collisionSide)
        {
            link.movable = false;
            link.state = new KnockedBackLink(link, collisionSide);
        }
        public void Update()
        {
            
            if (link.damageTimeCounter % 8 == 0) {
                thirdFrame++;
                if (thirdFrame == 4)
                {
                    thirdFrame = 0;
                }
            }

            if (link.isMoving)
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
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!link.isDamaged)
            {
                linkSprite[link.directionIndex].Draw(spriteBatch, link.x, link.y, currentFrame, link.direction);
            }
            else
            {
                damagedLinkSprite[link.directionIndex][thirdFrame].Draw(spriteBatch, link.x, link.y, currentFrame, link.direction);
            }
        }
        public string GetStateName()
        {
            return "NormalLink";
        }
    }
}

