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
    class DeadLink : IPlayerLinkState
    {
        int currentFrame;
        int totalFrame;
        int secondFrame;
        int thirdFrame;

        IPlayerLinkSprite[] linkSprite;
        IPlayerLinkSprite[][] damagedLinkSprite;

        Link link;


        public DeadLink(Link link)
        {
            currentFrame = 0;
            totalFrame = 4;
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
            link.movable = false;
        }

        public void AttackN()
        {
        }
        public void AttackZ()
        {
        }
        public void UseItem()
        {
        }
        public void TakeDamage()
        {
        }
        public void PickUp(int pickUp)
        {
        }
        public void KnockedBack(string collisionSide)
        {
        }
        public void Update()
        {
            if (link.damageTimeCounter % 8 == 0)
            {
                thirdFrame++;
                if (thirdFrame == 4)
                {
                    thirdFrame = 0;
                }
            }

            secondFrame++;
            if (secondFrame == 5)
            {
                secondFrame = 0;
                currentFrame++;
            }
            if (currentFrame == totalFrame)
            {
                currentFrame = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!link.isDamaged)
            {
                linkSprite[currentFrame].Draw(spriteBatch, link.x, link.y, 0, link.direction);
            }
            else
            {
                damagedLinkSprite[link.directionIndex][thirdFrame].Draw(spriteBatch, link.x, link.y, 0, link.direction);
            }

        }
        public string GetStateName()
        {
            return "DeadLink";
        }
    }
}

