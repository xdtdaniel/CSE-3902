using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Game1.Code.Item.ItemInterface;
using Game1.Code.Item.ItemSprite;

namespace Game1.Player.PlayerCharacter
{
    class TwoHandHoldTriforceLink : IPlayerLinkState
    {
       int currentFrame;
        IPlayerLinkSprite linkSprite;
        Triforce triforce;
        Link link;

        public TwoHandHoldTriforceLink(Link link)
        {
            currentFrame = 0;

            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            this.link = link;
            triforce = new Triforce(link.x, link.y - 30);

        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == 90) // decide how long the hold state will take
            {
                currentFrame = 0;
                link.state = new NormalLink(link);
            }
            triforce.Update();

        }
        public void Draw(SpriteBatch spriteBatch)
        {           

                linkSprite.Draw(spriteBatch, link.x, link.y, 1, link.direction);
                triforce.Draw(spriteBatch);
          
        }
        public string GetStateName()
        {
            return "TwoHandHoldTriforceLink";
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
        public void TakeDamage(int dmgAmount)
        {
            link.damageTimeCounter = 0;
            link.isDamaged = true;
            link.itemList["Heart"] -= dmgAmount;
        }

        public void KnockedBack(string collisionSide)
        {
            link.state = new KnockedBackLink(link, collisionSide);
        }

        public void PickUp(int pickUp)
        {

        }
    }
}

