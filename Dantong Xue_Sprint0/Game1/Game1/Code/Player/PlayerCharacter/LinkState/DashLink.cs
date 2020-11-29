using Microsoft.Xna.Framework.Graphics;
using Game1.Code.LoadFile;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;

namespace Game1.Code.Player.PlayerCharacter.LinkState
{
    class DashLink : IPlayerLinkState
    {
        private static int scale = (int)LoadAll.Instance.scale;

        private int thirdFrame = 0;

        private int dashSpeed = 15;
        private int maxSteps = 6;
        private int dashedSteps = 0;

        private int numberOfLinkSprite = 4;
        private int blinkFrequency = 8;
        private int maxThridFrame = 4;

        private IPlayerLinkSprite[] linkSprite;

        private Link link;


        public DashLink(Link link)
        {
            linkSprite = new IPlayerLinkSprite[numberOfLinkSprite];
            for (int i = 0; i < numberOfLinkSprite; i++)
            {
                linkSprite[i] = PlayerCharacterFactory.Instance.CreateDashLink(i);
            }

            this.link = link;
            link.movable = false;
            link.canAttack = false;
            link.isCollidible = true;
            link.isInvincible = true;

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
        public void PickUp(int pickUp)
        {
        }
        public void KnockedBack(string collisionSide)
        {
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


            if (dashedSteps < maxSteps)
            {
                dashedSteps++;

                switch (link.direction)
                {
                    case "up":
                        link.y -= dashSpeed;
                        break;
                    case "down":
                        link.y += dashSpeed;
                        break;
                    case "left":
                        link.x -= dashSpeed;
                        break;
                    case "right":
                        link.x += dashSpeed;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                link.state = new NormalLink(link);
            }
            


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            linkSprite[link.directionIndex].Draw(spriteBatch, link.x, link.y, 1, link.direction);

        }
        public string GetStateName()
        {
            return "DashLink";
        }
    }
}

