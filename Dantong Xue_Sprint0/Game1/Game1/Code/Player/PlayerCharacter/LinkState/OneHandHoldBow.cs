using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using Game1.Code.Item.ItemSprite;
using Game1.Code.LoadFile;

namespace Game1.Player.PlayerCharacter
{
    class OneHandHoldBow : IPlayerLinkState
    {
        private static int scale = (int)LoadAll.Instance.scale;

        private int currentFrame = 0;
        private int secondFrame = 0;

        private int numberOfDamagedLinkSprite = 4;
        private int blinkFrequency = 8;
        private int maxCurrentFrame = 60;
        private int maxSecondFrame = 60;

        private IPlayerLinkSprite linkSprite;
        private IPlayerLinkSprite[] damagedLinkSprite;

        private Bow bow;

        private Link link;
        private int offset = 66 * scale;

        public OneHandHoldBow(Link link)
        {
            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            
            damagedLinkSprite = new IPlayerLinkSprite[numberOfDamagedLinkSprite];
            damagedLinkSprite = PlayerCharacterFactory.Instance.CreateDamagedPickUpLink();
            
            this.link = link;

            bow = new Bow(link.x, link.y - offset);

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
                damagedLinkSprite[secondFrame].Draw(spriteBatch, link.x, link.y, 0, link.direction);
                bow.Draw(spriteBatch);
            }
        }
        public string GetStateName()
        {
            return "OneHandHoldBow";
        }
    }
}

