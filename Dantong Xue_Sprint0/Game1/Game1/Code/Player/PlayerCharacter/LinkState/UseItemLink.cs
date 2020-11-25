using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;

namespace Game1.Code.Player.PlayerCharacter.LinkState
{
    class UseItemLink : IPlayerLinkState
    {
        private int currentFrame = 0;
        private int secondFrame = 0;

        private int numberOfLinkSprite = 4;
        private int numberOfDamagedLinkSprite = 4;
        private int blinkFrequency = 8;
        private int maxCurrentFrame = 15;
        private int maxSecondFrame = 4;

        private IPlayerLinkSprite[] linkSprite;
        private IPlayerLinkSprite[][] damagedLinkSprite;

        private Link link;

        public UseItemLink(Link link)
        {
            linkSprite = new IPlayerLinkSprite[numberOfLinkSprite];
            for (int i = 0; i < numberOfLinkSprite; i++)
            {
                linkSprite[i] = PlayerCharacterFactory.Instance.CreateUseItemLink(i);
            }

            damagedLinkSprite = new IPlayerLinkSprite[numberOfDamagedLinkSprite][];
            for (int i = 0; i < numberOfDamagedLinkSprite; i++)
            {
                damagedLinkSprite[i] = PlayerCharacterFactory.Instance.CreateDamagedUseItemLink(i);
            }

            this.link = link;
            link.canAttack = false;
        }
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
                linkSprite[link.directionIndex].Draw(spriteBatch, link.x, link.y, currentFrame, link.direction);
            }
            else
            {
                damagedLinkSprite[link.directionIndex][secondFrame].Draw(spriteBatch, link.x, link.y, currentFrame, link.direction);

            }
        }
        public string GetStateName()
        {
            return "UseItemLink";
        }
    }
}

