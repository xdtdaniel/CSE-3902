using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Code.LoadFile;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;

namespace Game1.Code.Player.PlayerCharacter.LinkState
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

            // update the location
            newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.W) || newState.IsKeyDown(Keys.Up))
            {
                jumpY -= link.ySpeed;
            }
            if (newState.IsKeyDown(Keys.S) || newState.IsKeyDown(Keys.Down))
            {
                jumpY += link.ySpeed;
            }
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
                link.timeSinceJump = 0;
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

