using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;
using Game1.Code.Item.ItemSprite;
using Game1.Code.LoadFile;

namespace Game1.Code.Player.PlayerCharacter.LinkState
{

    class CrownLink : IPlayerLinkState
    {
        private static int scale = (int)LoadAll.Instance.scale;

        private Link link;
        private IPlayerLinkSprite linkSprite;
        private Crown crown;
        private int offsetX = 6 * scale;
        private int offsetY = 25 * scale;
        private int currentFrame = 0;
        private int maxCurrentFrame = 90;

        public CrownLink(Link link)
        {
            link.state = new TwoHandHoldTriforce(link);
            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            this.link = link;
            link.movable = false;
            link.canAttack = false;
            crown = new Crown(link.x - (int)LoadAll.Instance.startPos.X-offsetX, link.y - (int)LoadAll.Instance.startPos.Y - offsetY);

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
            currentFrame++;
            if (currentFrame == maxCurrentFrame) // decide how long the hold state will take
            {
                currentFrame = 0;
                link.state = new CrownLink(link);
            }
            crown.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            linkSprite.Draw(spriteBatch, link.x, link.y, 1, link.direction);
            crown.Draw(spriteBatch);

        }
        public string GetStateName()
        {
            return "CrownLink";
        }
    }
}

