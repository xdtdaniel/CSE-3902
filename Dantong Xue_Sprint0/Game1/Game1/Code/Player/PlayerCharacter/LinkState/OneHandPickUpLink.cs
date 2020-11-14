using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;

namespace Game1.Player.PlayerCharacter
{
    class OneHandPickUpLink : IPlayerLinkState
    {

        private int currentFrame = 0;
        private int secondFrame = 0;

        private int numberOfDamagedLinkSprite = 4;
        private int blinkFrequency = 8;
        private int maxCurrentFrame = 15;
        private int maxSecondFrame = 4;

        IPlayerLinkSprite linkSprite;
        IPlayerLinkSprite[] damagedLinkSprite;

        Link link;

        public OneHandPickUpLink(Link link)
        {
            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            
            damagedLinkSprite = new IPlayerLinkSprite[numberOfDamagedLinkSprite];
            damagedLinkSprite = PlayerCharacterFactory.Instance.CreateDamagedPickUpLink();
            
            this.link = link;

        }
        public void WoodenSwordAttack() { }
        public void SwordBeamAttack() { }
        public void UseItem() { }
        public void PickUp(int pickUp) { }
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
        public void Update()
        {
            if (link.damageTimeCounter % blinkFrequency == 0)
            {
                secondFrame++;
                if (secondFrame == maxSecondFrame)
                {
                    secondFrame = 0;
                }
            }

            currentFrame++;
            if (currentFrame == maxCurrentFrame)
            {
                currentFrame = 0;
                link.state = new NormalLink(link);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!link.isDamaged)
            {
                linkSprite.Draw(spriteBatch, link.x, link.y, 0, link.direction);
            }
            else
            {
                damagedLinkSprite[secondFrame].Draw(spriteBatch, link.x, link.y, 0, link.direction);
            }
        }
        public string GetStateName()
        {
            return "OneHandPickUpLink";
        }
    }
}

