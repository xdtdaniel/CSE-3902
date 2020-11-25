using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;
using Game1.Code.Item.ItemSprite;
using Game1.Code.LoadFile;

namespace Game1.Code.Player.PlayerCharacter.LinkState
{
    class TwoHandHoldHeartContainer : IPlayerLinkState
    {
        private static int scale = (int)LoadAll.Instance.scale;

        private int currentFrame = 0;
        private int maxCurrentFrame = 60;

        private IPlayerLinkSprite linkSprite;
        private HeartContainer heartContainer;
        private Link link;
        private int offset = 16 * scale;

        public TwoHandHoldHeartContainer(Link link)
        {
            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            this.link = link;
            link.canAttack = false;
            heartContainer = new HeartContainer(link.x - (int)LoadAll.Instance.startPos.X, link.y - (int)LoadAll.Instance.startPos.Y-offset);

        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == maxCurrentFrame) // decide how long the hold state will take
            {
                currentFrame = 0;
                link.state = new NormalLink(link);
            }
            heartContainer.Update();

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            linkSprite.Draw(spriteBatch, link.x, link.y, 1, link.direction);
            heartContainer.Draw(spriteBatch);

        }
        public string GetStateName()
        {
            return "TwoHandHoldHeartContainer";
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

        public void KnockedBack(string collisionSide)
        {
            link.state = new KnockedBackLink(link, collisionSide);
        }

        public void PickUp(int pickUp)
        {

        }
    }
}
