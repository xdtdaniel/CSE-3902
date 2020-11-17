using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using Game1.Code.Item.ItemSprite;
using Game1.Code.LoadFile;

namespace Game1.Player.PlayerCharacter
{

    class WinLink : IPlayerLinkState
    {
        private static int scale = (int)LoadAll.Instance.scale;

        private Link link;
        private IPlayerLinkSprite linkSprite;
        private Triforce triforce;
        private int offset = 16 * scale;
        private int currentFrame = 0;
        private int maxCurrentFrame = 90;

        public WinLink(Link link)
        {
            link.state = new TwoHandHoldTriforce(link);
            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            this.link = link;
            link.canAttack = false;
            triforce = new Triforce(link.x - (int)LoadAll.Instance.startPos.X, link.y - (int)LoadAll.Instance.startPos.Y - offset);

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
                link.state = new WinLink(link);
            }
            triforce.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            linkSprite.Draw(spriteBatch, link.x, link.y, 1, link.direction);
            triforce.Draw(spriteBatch);

        }
        public string GetStateName()
        {
            return "WinLink";
        }
    }
}

