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
    class TwoHandPickUpLink : IPlayerLinkState
    {
        int currentFrame;
        int thirdFrame;

        IPlayerLinkSprite linkSprite;
        IPlayerLinkSprite[] damagedLinkSprite;

        Link link;

        public TwoHandPickUpLink(Link link)
        {
            currentFrame = 0;
            thirdFrame = 0;

            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            

            damagedLinkSprite = new IPlayerLinkSprite[4];
            damagedLinkSprite = PlayerCharacterFactory.Instance.CreateDamagedPickUpLink();
            

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
            link.hp -= 10;
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

            // delete currentFrame later
            currentFrame++;
            if (currentFrame == 15)
            {
                currentFrame = 0;
                link.state = new NormalLink(link);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!link.isDamaged)
            {
                linkSprite.Draw(spriteBatch, link.x, link.y, 1, link.direction);
            }
            else
            {
                damagedLinkSprite[thirdFrame].Draw(spriteBatch, link.x, link.y, 1, link.direction);

            }
        }
        public string GetStateName()
        {
            return "TwoHandPickUpLink";
        }
    }
}

