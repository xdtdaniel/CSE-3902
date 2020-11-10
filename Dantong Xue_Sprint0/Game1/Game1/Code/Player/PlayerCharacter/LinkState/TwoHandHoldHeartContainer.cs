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
    class TwoHandHoldHeartContainer : IPlayerLinkState
    {
        int currentFrame;
        IPlayerLinkSprite linkSprite;
        HeartContainer heartContainer;
        Link link;

        public TwoHandHoldHeartContainer(Link link)
        {
            currentFrame = 0;
            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            this.link = link;
            heartContainer = new HeartContainer(link.x, link.y - 40);

        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == 60) // decide how long the hold state will take
            {
                currentFrame = 0;
                link.state = new NormalLink(link);
            }
            heartContainer.Update();

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            linkSprite.Draw(spriteBatch, link.x, link.y, 1, link.direction);
            heartContainer.Draw(spriteBatch);

        }
        public string GetStateName()
        {
            return "TwoHandHoldHeartContainer";
        }

        public void WoodenSwordAttack()
        {

        }

        public void SwordBeamAttack()
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
