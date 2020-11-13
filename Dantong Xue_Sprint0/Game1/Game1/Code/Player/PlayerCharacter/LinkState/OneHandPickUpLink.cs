using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;

namespace Game1.Player.PlayerCharacter
{
    class OneHandPickUpLink : IPlayerLinkState
    {
        int currentFrame;
        int thirdFrame;

        IPlayerLinkSprite linkSprite;
        IPlayerLinkSprite[] damagedLinkSprite;

        Link link;

        public OneHandPickUpLink(Link link)
        {
            currentFrame = 0;
            thirdFrame = 0;

            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            
            damagedLinkSprite = new IPlayerLinkSprite[4];
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
            if (link.damageTimeCounter % 8 == 0)
            {
                thirdFrame++;
                if (thirdFrame == 4)
                {
                    thirdFrame = 0;
                }
            }

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
                linkSprite.Draw(spriteBatch, link.x, link.y, 0, link.direction);
            }
            else
            {
                damagedLinkSprite[thirdFrame].Draw(spriteBatch, link.x, link.y, 0, link.direction);
            }
        }
        public string GetStateName()
        {
            return "OneHandPickUpLink";
        }
    }
}

