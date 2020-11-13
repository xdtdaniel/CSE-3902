using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
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
        private int offset;

        public OneHandHoldBow(Link link)
        {
            currentFrame = 0;
            thirdFrame = 0;

            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            
            damagedLinkSprite = new IPlayerLinkSprite[4];
            damagedLinkSprite = PlayerCharacterFactory.Instance.CreateDamagedPickUpLink();
            
            this.link = link;
            offset = 200;
            bow = new Bow(link.x, link.y-offset);

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

