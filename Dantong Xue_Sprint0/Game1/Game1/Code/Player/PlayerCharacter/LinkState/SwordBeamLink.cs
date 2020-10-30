using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Player.PlayerCharacter
{
    class SwordBeamLink : IPlayerLinkState
    {
        int currentFrame;
        int totalFrame;
        int secondFrame;
        int thirdFrame;

        IPlayerLinkSprite[] linkSprite;
        IPlayerLinkSprite[][] damagedLinkSprite;

        Link link;

        public SwordBeamLink(Link link)
        {
            currentFrame = 0;
            totalFrame = 4;
            secondFrame = 0;
            thirdFrame = 0;

            linkSprite = new IPlayerLinkSprite[4];
            for (int i = 0; i < 4; i++)
            {
                linkSprite[i] = PlayerCharacterFactory.Instance.CreateSwordBeamLink(i);
            }

            damagedLinkSprite = new IPlayerLinkSprite[4][];
            for (int i = 0; i < 4; i++)
            {
                damagedLinkSprite[i] = PlayerCharacterFactory.Instance.CreateDamagedSwordBeamLink(i);
            }

            this.link = link;
        }
        public void AttackN() { }
        public void AttackZ() { }
        public void UseItem() { }
        public void PickUp(int pickUp) { }

        public void TakeDamage()
        {
            link.damageTimeCounter = 0;
            link.isDamaged = true;
            // test collision
            link.health -= 10;
        }
        public void KnockedBack(string collisionSide)
        {
            link.state = new KnockedBackLink(link, collisionSide);
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
                currentFrame++;
                secondFrame = 0;
            }
            if (currentFrame == totalFrame)
            {
                currentFrame = 0;
                link.state = new NormalLink(link);
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
            return "SwordBeamLink";
        }
    }
}

