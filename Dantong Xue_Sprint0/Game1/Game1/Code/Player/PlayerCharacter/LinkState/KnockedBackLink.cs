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

        int knockedBackSpeed;
        int knockedBackSpeedDecay;

        IPlayerLinkSprite[] damagedLinkSprite;

        Link link;

        public KnockedBackLink(Link link, string collisionSide)
        {
            currentFrame = 0;
            thirdFrame = 0;
            this.collisionSide = collisionSide;

            knockedBackSpeed = 15;
            knockedBackSpeedDecay = 1;

            damagedLinkSprite = new IPlayerLinkSprite[4];
            damagedLinkSprite = PlayerCharacterFactory.Instance.CreateDamagedLink(link.directionIndex);
             

            this.link = link;
        }
        public void WoodenSwordAttack() { }
        public void SwordBeamAttack() { }
        public void UseItem() { }
        public void PickUp(int pickUp) { }

        public void TakeDamage(int dmgAmount)
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

            switch (collisionSide)
            {
                case "down":
                    link.y -= knockedBackSpeed;
                    break;
                case "right":
                    link.x -= knockedBackSpeed;
                    break;
                case "up":
                    link.y += knockedBackSpeed;
                    break;
                case "left":
                    link.x += knockedBackSpeed;
                    break;
                default:
                    break;
            }
            knockedBackSpeed -= knockedBackSpeedDecay;
            currentFrame++;
            if (currentFrame > knockedBackSpeed / knockedBackSpeedDecay)
            {
                currentFrame = 0;
                link.state = new NormalLink(link);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            damagedLinkSprite[thirdFrame].Draw(spriteBatch, link.x, link.y, 1, link.direction);
            
        }
        public string GetStateName()
        {
            return "KnockedBackLink";
        }
    }
}

