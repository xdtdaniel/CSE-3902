using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;

namespace Game1.Player.PlayerCharacter
{
    class NormalLink : IPlayerLinkState
    {
        private int currentFrame = 0;
        private int totalFrame = 2;
        private int secondFrame = 0;
        private int thirdFrame = 0;

        private int numberOfLinkSprite = 4;
        private int numberOfDamagedLinkSprite = 4;
        private int blinkFrequency = 8;
        private int maxSecondFrame = 15;
        private int maxThridFrame = 4;

        private IPlayerLinkSprite[] linkSprite;
        private IPlayerLinkSprite[][] damagedLinkSprite;

        private Link link;


        public NormalLink(Link link)
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
            link.movable = true;
            link.canAttack = true;
            link.isCollidible = true;
            link.isInvincible = false;
        }

        public void UseItem()
        {
            link.movable = false;
            link.state = new UseItemLink(link);
        }
        public void TakeDamage(int dmgAmount)
        {
            link.damageTimeCounter = 0;
            link.isDamaged = true;
            link.itemList["Heart"] -= dmgAmount;
        }
        public void PickUp(int pickUp)
        {
            link.movable = false;
            if (pickUp == 0)
            {
                link.state = new OneHandPickUpLink(link);
            }
            else if (pickUp == 1)
            {
                link.state = new TwoHandPickUpLink(link);
            }
            else if (pickUp == 2)
            {
                link.state = new TwoHandHoldTriforce(link);
            }
            else if (pickUp == 3)
            {
                link.state = new OneHandHoldBow(link);
            }
            else if (pickUp == 4) {
                link.state = new TwoHandHoldHeartContainer(link);
            }
        }
        public void KnockedBack(string collisionSide)
        {
            link.movable = false;
            link.state = new KnockedBackLink(link, collisionSide);
        }
        public void Update()
        {
            
            if (link.damageTimeCounter % blinkFrequency == 0) {
                thirdFrame++;
                if (thirdFrame == maxThridFrame)
                {
                    thirdFrame = 0;
                }
            }

            if (link.isMoving)
            {
                secondFrame++;
                if (secondFrame == maxSecondFrame)
                {
                    currentFrame++;
                    secondFrame = 0;
                }

                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                }
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
            return "NormalLink";
        }
    }
}

