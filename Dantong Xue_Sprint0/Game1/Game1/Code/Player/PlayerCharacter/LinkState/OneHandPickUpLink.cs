using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Player.PlayerCharacter
{
    class OneHandPickUpLink : IPlayerLinkState
    {
        int currentFrame;
        int thirdFrame;

        IPlayerSprite linkSprite;
        IPlayerSprite[] damagedLinkSprite;

        Link link;

        Rectangle rectangle;
        public OneHandPickUpLink(Link link)
        {
            currentFrame = 0;
            thirdFrame = 0;

            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            
            damagedLinkSprite = new IPlayerSprite[4];
            damagedLinkSprite = PlayerCharacterFactory.Instance.CreateDamagedPickUpLink();
            
            this.link = link;

            rectangle = new Rectangle();
        }
        public void AttackN() { }
        public void AttackZ() { }
        public void UseItem() { }
        public void PickUp(int pickUp) { }
        public void TakeDamage()
        {
            link.damageTimeCounter = 0;
            link.isDamaged = true;
            // test collision
            link.hp -= 10;
        }
        public void KnockedBack(string collisionSide)
        {
            link.state = new KnockedBackLink(link, collisionSide);
        }
        public void Update(ref int x, ref int y, int direction, bool isMoving)
        {
            if (link.isDamaged)
            {
                link.damageTimeCounter++;
            }
            if (link.damageTimeCounter == 90)
            {
                link.damageTimeCounter = 0;
                link.isDamaged = false;
            }
            if (link.damageTimeCounter % 8 == 0)
            {
                thirdFrame++;
                if (thirdFrame == 4)
                {
                    thirdFrame = 0;
                }
            }

            currentFrame++;
            if (currentFrame == 15)
            {
                currentFrame = 0;
                link.state = new NormalLink(link);
            }
        }
        public void Draw(SpriteBatch spriteBatch, int x, int y, int direction)
        {
            if (!link.isDamaged)
            {
                rectangle = linkSprite.Draw(spriteBatch, x, y, 0, direction);
            }
            else
            {
                rectangle = damagedLinkSprite[thirdFrame].Draw(spriteBatch, x, y, 0, direction);
            }
        }
        public Rectangle GetRectangle()
        {
            return rectangle;
        }
    }
}

