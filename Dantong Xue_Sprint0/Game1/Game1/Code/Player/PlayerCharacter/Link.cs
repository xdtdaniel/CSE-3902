using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Game1.Code.Player;
using Game1.Enemy;
using Game1.Code.LoadFile;

namespace Game1.Player.PlayerCharacter
{
    public class Link
    {
        public int x;
        public int y;
        public int damageTimeCounter;
        public bool isDamaged;
        public int hp;
        public int defaultSpeed;
        public int downSpeed, upSpeed, rightSpeed, leftSpeed;

        public string direction;

        public LinkItem item;

        private int timeBetweenAttack;
        private int timeSinceAttack;
        private int timeBetweenItem;
        private int timeSinceItem;
        private bool useItemDone;


        public IPlayerLinkState state;
        public Link()
        {
            x = 300;
            y = 300;
            damageTimeCounter = 0;
            isDamaged = false;
            hp = 100;
            defaultSpeed = downSpeed = upSpeed = rightSpeed = leftSpeed = 5;

            direction = "down";


            state = new NormalLink(this);

            item = new LinkItem();
            item.state = new NoItem(item);

            timeBetweenAttack = 45;
            timeSinceAttack = 0; 
            timeBetweenItem = 45;
            timeSinceItem = 0;
            useItemDone = true;

        }
        public void Attack(bool attackN, bool attackZ)
        {
            if (timeSinceAttack >= timeBetweenAttack)
            {
                if (attackN)
                {
                    state.AttackN();
                    timeSinceAttack = 0;
                }
                else if (attackZ)
                {
                    state.AttackZ();
                    timeSinceAttack = 0;
                }
            }
        }
        public void UseItem(int itemNum)
        {
            if (useItemDone && timeSinceItem >= timeBetweenItem)
            {
                state.UseItem();
                item.UseItem(itemNum);
                timeSinceItem = 0;
            }
            useItemDone = item.IsDone();
        }
        public void TakeDamage()
        {
            state.TakeDamage();
        }
        public void PickUp(int pickUp)
        {
            state.PickUp(pickUp);
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(x, y, (int)(13 * LoadAll.Instance.scale), (int)(13 * LoadAll.Instance.scale));
        }
        public void KnockedBack(string collisionSide)
        {
            state.KnockedBack(collisionSide);
        }
        public void Update(bool isMoving)
        {
            int directionIndex = 0;
            switch (direction)
            {
                case "down":
                    directionIndex = 0;
                    break;
                case "right":
                    directionIndex = 1;
                    break;
                case "up":
                    directionIndex = 2;
                    break;
                case "left":
                    directionIndex = 3;
                    break;
                default:
                    break;
            }
            state.Update(ref x, ref y, directionIndex, isMoving);
            item.Update(x, y, directionIndex);

            if (timeSinceAttack < timeBetweenAttack)
            {
                timeSinceAttack++;
            }
            if (timeSinceItem < timeBetweenItem)
            {
                timeSinceItem++;
            }

            if (isDamaged)
            {
                damageTimeCounter++;
            }
            if (damageTimeCounter == 90)
            {
                damageTimeCounter = 0;
                isDamaged = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int directionIndex = 0;
            switch (direction)
            {
                case "down":
                    directionIndex = 0;
                    break;
                case "right":
                    directionIndex = 1;
                    break;
                case "up":
                    directionIndex = 2;
                    break;
                case "left":
                    directionIndex = 3;
                    break;
                default:
                    break;
            }
            state.Draw(spriteBatch, x, y, directionIndex);
            item.Draw(spriteBatch);
        }
        public string GetStateName()
        {
            return state.GetStateName();
        }
    }
}
