using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Game1.Code.Item.ItemSprite;

namespace Game1.Player.PlayerCharacter
{

    class WinLink : IPlayerLinkState
    {

        Link link;
        IPlayerLinkSprite linkSprite;
        Triforce triforce;

        public WinLink(Link link)
        {
            link.state = new TwoHandHoldTriforce(link);
            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            this.link = link;
            triforce = new Triforce(link.x, link.y - 30);
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

