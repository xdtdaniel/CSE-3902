using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using Microsoft.Xna.Framework.Input;
using Game1.Code.LoadFile;

namespace Game1.Player.PlayerCharacter
{
    class JumpLink : IPlayerLinkState
    {
        private static int scale = (int)LoadAll.Instance.scale;

        private KeyboardState newState;

        private int thirdFrame = 0;

        private int jumpSpeed = 10;
        private int gravAcceleration = 1;
        private int maxSteps = 10;
        private int jumpThreshold = 3;
        private int stepsBeforeFalling = 1;
        private int jumpedSteps = 0;
        private int jumpX;
        private int jumpY;

        private int numberOfLinkSprite = 4;
        private int numberOfDamagedLinkSprite = 4;
        private int blinkFrequency = 8;
        private int maxThridFrame = 4;

        private int xLowerBound = 32 * scale;
        private int xUpperBound = 211 * scale;
        private int yLowerBound = 128 * scale;
        private int yUpperBound = 147 * scale;

        private IPlayerLinkSprite[] linkSprite;
        private IPlayerLinkSprite[][] damagedLinkSprite;

        private Link link;


        public JumpLink(Link link)
        {
            jumpX = link.x;
            jumpY = link.y;

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
            link.canAttack = false;
            link.isCollidible = false;
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

            // can't jump over walls
            if (link.y > yUpperBound || link.y < yLowerBound)
            {
                if (link.x > xUpperBound)
                {
                    link.x = xUpperBound;
                }
                else if (link.x < xLowerBound)
                {
                    link.x = xLowerBound;
                }
            }


            // update the location
            newState = Keyboard.GetState();
            jumpX = link.x;
            
            // hold key J to jump higher
            jumpY -= jumpSpeed;
            jumpedSteps++;
            if (newState.IsKeyDown(Keys.J) && jumpedSteps > jumpThreshold && stepsBeforeFalling < maxSteps)
            {
                stepsBeforeFalling++;
            }
            if (jumpedSteps > stepsBeforeFalling)
            {
                jumpY += (gravAcceleration * (jumpedSteps - stepsBeforeFalling));

            }

            // link lands
            if (jumpY > link.y)
            {
                jumpY = link.y;
                link.state = new NormalLink(link);
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!link.isDamaged)
            {
                linkSprite[link.directionIndex].Draw(spriteBatch, jumpX, jumpY, 1, link.direction);
            }
            else
            {
                damagedLinkSprite[link.directionIndex][thirdFrame].Draw(spriteBatch, jumpX, jumpY, 1, link.direction);
            }
        }
        public string GetStateName()
        {
            return "JumpLink";
        }
    }
}

