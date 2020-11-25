using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;

namespace Game1.Code.Player.PlayerCharacter.LinkState
{
    class DeadLink : IPlayerLinkState
    {
        private int currentFrame = 0;
        private int totalFrame = 4;
        private int secondFrame = 0;
        private int thirdFrame = 0;
        private int numberOfLinkSprite = 4;
        private int numberOfDamagedLinkSprite = 4;
        private int blinkFrequency = 8;
        private int maxSecondFrame = 5;

        private IPlayerLinkSprite[] linkSprite;
        private IPlayerLinkSprite[][] damagedLinkSprite;

        private Link link;
        public DeadLink(Link link)
        {
            linkSprite = new IPlayerLinkSprite[numberOfLinkSprite];
            for (int i = 0; i < numberOfLinkSprite; i++)
            {
                linkSprite[i] = PlayerCharacterFactory.Instance.CreateNormalLink(i);
            }

            damagedLinkSprite = new IPlayerLinkSprite[numberOfDamagedLinkSprite][];
            for (int i = 0; i < numberOfDamagedLinkSprite; i++)
            {
                damagedLinkSprite[i] = PlayerCharacterFactory.Instance.CreateDamagedLink(i);
            }
            this.link = link;
            link.movable = false;
            link.canAttack = false;
        }

        public void UseItem()
        {
        }
        public void TakeDamage(int dmgAmount)
        {
        }
        public void PickUp(int pickUp)
        {
        }
        public void KnockedBack(string collisionSide)
        {
        }
        public void Update()
        {
            if (link.damageTimeCounter % blinkFrequency == 0)
            {
                thirdFrame++;
                if (thirdFrame == numberOfDamagedLinkSprite)
                {
                    thirdFrame = 0;
                }
            }

            secondFrame++;
            if (secondFrame == maxSecondFrame)
            {
                secondFrame = 0;
                currentFrame++;
            }
            if (currentFrame == totalFrame)
            {
                currentFrame = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!link.isDamaged)
            {
                linkSprite[currentFrame].Draw(spriteBatch, link.x, link.y, 0, link.direction);
            }
            else
            {
                damagedLinkSprite[link.directionIndex][thirdFrame].Draw(spriteBatch, link.x, link.y, 0, link.direction);
            }

        }
        public string GetStateName()
        {
            return "DeadLink";
        }
    }
}

