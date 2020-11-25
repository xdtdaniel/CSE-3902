using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;

namespace Game1.Code.Player.PlayerCharacter.LinkState
{
    class SwordBeamLink : IPlayerLinkState
    {
        private int currentFrame = 0;
        private int totalFrame = 4;
        private int secondFrame = 0;
        private int thirdFrame = 0;


        private int numberOfLinkSprite = 4;
        private int numberOfDamagedLinkSprite = 4;
        private int blinkFrequency = 8;
        private int maxSecondFrame = 5;
        private int maxThirdFrame = 4;

        private IPlayerLinkSprite[] linkSprite;
        private IPlayerLinkSprite[][] damagedLinkSprite;

        private Link link;

        public SwordBeamLink(Link link)
        {
            linkSprite = new IPlayerLinkSprite[numberOfLinkSprite];
            for (int i = 0; i < numberOfLinkSprite; i++)
            {
                linkSprite[i] = PlayerCharacterFactory.Instance.CreateSwordBeamLink(i);
            }

            damagedLinkSprite = new IPlayerLinkSprite[numberOfDamagedLinkSprite][];
            for (int i = 0; i < numberOfDamagedLinkSprite; i++)
            {
                damagedLinkSprite[i] = PlayerCharacterFactory.Instance.CreateDamagedSwordBeamLink(i);
            }

            this.link = link;
            link.movable = false;
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
                thirdFrame++;
                if (thirdFrame == maxThirdFrame)
                {
                    thirdFrame = 0;
                }
            }

            secondFrame++;
            if (secondFrame == maxSecondFrame)
            {
                currentFrame++;
                secondFrame = 0;
            }
            if (currentFrame == totalFrame)
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
                damagedLinkSprite[link.directionIndex][thirdFrame].Draw(spriteBatch, link.x, link.y, currentFrame, link.direction);

            }
        }
        public string GetStateName()
        {
            return "SwordBeamLink";
        }
    }
}

