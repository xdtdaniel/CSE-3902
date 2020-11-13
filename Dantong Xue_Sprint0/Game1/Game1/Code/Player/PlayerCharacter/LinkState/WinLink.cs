using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using Game1.Code.Item.ItemSprite;

namespace Game1.Player.PlayerCharacter
{

    class WinLink : IPlayerLinkState
    {

        Link link;
        IPlayerLinkSprite linkSprite;
        Triforce triforce;
        private int offset;

        public WinLink(Link link)
        {
            link.state = new TwoHandHoldTriforce(link);
            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            this.link = link;
            offset = 200;
            triforce = new Triforce(link.x, link.y - offset);
        }


        public void WoodenSwordAttack()
        {
        }
        public void SwordBeamAttack()
        {
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

