using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Player.PlayerCharacter
{
    class WoodenSwordLink : IPlayerLinkState
    {
        int currentFrame;
        int totalFrame;
        int secondFrame;
        int thirdFrame;

        IPlayerSprite[] linkSprite;
        IPlayerSprite[][] damagedLinkSprite;

        Link link;
        public WoodenSwordLink(Link link)
        {
            currentFrame = 0;
            totalFrame = 4;
            secondFrame = 0;
            thirdFrame = 0;

            linkSprite = new IPlayerSprite[4];
            for (int i = 0; i < 4; i++)
            {
                linkSprite[i] = PlayerCharacterFactory.Instance.CreateWoodenSwordLink(i);
            }

            damagedLinkSprite = new IPlayerSprite[4][];
            for (int i = 0; i < 4; i++)
            {
                damagedLinkSprite[i] = PlayerCharacterFactory.Instance.CreateDamagedWoodenSwordLink(i);
            }

            this.link = link;
        }
        public void AttackN() { }
        public void AttackZ() { }
        public void UseItem() { }
        public void PickUp(int pickUp) { }

        public void TakeDamage()
        {
            link.damageTimeCounter = 0;
            link.isDamaged = true;
        }
        public void Update(ref int x, ref int y, int direction, bool isMoving)
        {
            link.damageTimeCounter++;
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

            secondFrame++;
            if (secondFrame == 10)
            {
                currentFrame++;
                secondFrame = 0;
            }
            if (currentFrame == totalFrame)
            {
                currentFrame = 0;
                link.state = new NormalLink(link);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y, int direction)
        {
            if (!link.isDamaged)
            {
                linkSprite[direction].Draw(spriteBatch, x, y, currentFrame, direction);
            }
            else
            {
                damagedLinkSprite[direction][thirdFrame].Draw(spriteBatch, x, y, currentFrame, direction);

            }
        }
    }
}

