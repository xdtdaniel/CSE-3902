using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Game1.Code.Item.ItemSprite;

namespace Game1.Player.PlayerCharacter
{
    class OneHandHoldBow : IPlayerLinkState
    {
        int currentFrame;
        int thirdFrame;

        IPlayerLinkSprite linkSprite;
        IPlayerLinkSprite[] damagedLinkSprite;

        Bow bow;

        Link link;

        public OneHandHoldBow(Link link)
        {
            currentFrame = 0;
            thirdFrame = 0;

            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            
            damagedLinkSprite = new IPlayerLinkSprite[4];
            damagedLinkSprite = PlayerCharacterFactory.Instance.CreateDamagedPickUpLink();
            
            this.link = link;
            bow = new Bow(link.x, link.y-40);

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
            link.itemList["Heart"] -= 1;
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
                if (thirdFrame == 60)
                {
                    thirdFrame = 0;
                }
            }

            currentFrame++;
            if (currentFrame == 60)
            {
                currentFrame = 0;
                link.state = new NormalLink(link);
            }
            bow.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!link.isDamaged)
            {
                linkSprite.Draw(spriteBatch, link.x, link.y, 0, link.direction);
                bow.Draw(spriteBatch);
            }
            else
            {
                damagedLinkSprite[thirdFrame].Draw(spriteBatch, link.x, link.y, 0, link.direction);
                bow.Draw(spriteBatch);
            }
        }
        public string GetStateName()
        {
            return "OneHandHoldBow";
        }
    }
}

