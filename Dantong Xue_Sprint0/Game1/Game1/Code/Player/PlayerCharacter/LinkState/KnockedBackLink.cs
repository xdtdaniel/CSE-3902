using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using Game1.Code.LoadFile;

namespace Game1.Player.PlayerCharacter
{
    class KnockedBackLink : IPlayerLinkState
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int currentFrame = 0;
        private int secondFrame = 0;
        private string collisionSide;

        private int knockedBackSpeed = 5 * scale;
        private int knockedBackSpeedDecay = (int)(1/3.0 * scale);
        private int blinkFrequency = 8;
        private int maxSecondFrame = 4;

        private IPlayerLinkSprite[] damagedLinkSprite;

        private Link link;

        public KnockedBackLink(Link link, string collisionSide)
        {
            this.collisionSide = collisionSide;


            damagedLinkSprite = new IPlayerLinkSprite[4];
            damagedLinkSprite = PlayerCharacterFactory.Instance.CreateDamagedLink(link.directionIndex);
             

            this.link = link;
            link.movable = false;
            link.canAttack = false;
        }
        public void UseItem() { }
        public void PickUp(int pickUp) { }

        public void TakeDamage(int dmgAmount)
        {
        }
        public void KnockedBack(string collisionSide)
        {
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

            switch (collisionSide)
            {
                case "down":
                    link.y -= knockedBackSpeed;
                    break;
                case "right":
                    link.x -= knockedBackSpeed;
                    break;
                case "up":
                    link.y += knockedBackSpeed;
                    break;
                case "left":
                    link.x += knockedBackSpeed;
                    break;
                default:
                    break;
            }
            knockedBackSpeed -= knockedBackSpeedDecay;
            currentFrame++;
            if (currentFrame > knockedBackSpeed / knockedBackSpeedDecay)
            {
                currentFrame = 0;
                link.state = new NormalLink(link);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            damagedLinkSprite[secondFrame].Draw(spriteBatch, link.x, link.y, 1, link.direction);
            
        }
        public string GetStateName()
        {
            return "KnockedBackLink";
        }
    }
}

