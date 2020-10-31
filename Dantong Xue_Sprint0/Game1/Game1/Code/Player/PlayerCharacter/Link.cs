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
using System.Linq.Expressions;
using System.Drawing.Text;

namespace Game1.Player.PlayerCharacter
{
    public class Link
    {
        public int x;
        public int y;
        public int damageTimeCounter;
        public bool isDamaged;
        public bool isMoving;
        public bool movable;
        public int maxHealth;
        public int health;
        public bool isDead;
        public int defaultSpeed;
        public int xSpeed, ySpeed;
        public int attackDamage;
        private int linkWidth;
        private int linkHeight;

        public string direction;
        public int directionIndex;

        public Dictionary<string, int> itemList;

        public LinkItem[] item;

        public int timeBetweenAttack;
        public int timeSinceAttack;
        public int timeBetweenItem;
        public int timeSinceItem;
        public bool useItemDone;

        public int itemIndex;
        private const int MAX_ITEM_SPRITE_NUM = 1000;
        public IPlayerLinkState state;
        public Link()
        {
            x = 300;
            y = 300;
            damageTimeCounter = 0;
            isDamaged = false;
            isMoving = false;
            movable = true;
            maxHealth = 60;
            health = maxHealth;
            isDead = false;
            defaultSpeed = xSpeed = ySpeed = 5;
            attackDamage = 10;

            linkWidth = (int)(13 * LoadAll.Instance.scale);
            linkHeight = (int)(13 * LoadAll.Instance.scale);

            itemIndex = 0;

            direction = "down";
            directionIndex = 0;

            itemList = new Dictionary<string, int>();
            itemList.Add("arrow", 0);
            itemList.Add("bomb", 0);
            itemList.Add("boomerang", 0);
            itemList.Add("bow", 0);
            itemList.Add("clock", 0);
            itemList.Add("compass", 0);
            itemList.Add("heart", 0);
            itemList.Add("heart_container", 0);
            itemList.Add("key", 0);
            itemList.Add("map", 0);
            itemList.Add("ruby", 0);
            itemList.Add("triforce", 0);
            itemList.Add("fairy", 0);

            state = new NormalLink(this);

            item = new LinkItem[MAX_ITEM_SPRITE_NUM];
            for (int i = 0; i < MAX_ITEM_SPRITE_NUM; i++)
            {
                item[i] = new LinkItem();
                item[i].state = new NoItem(item[i]);
            }

            timeBetweenAttack = 30;
            timeSinceAttack = 0; 
            timeBetweenItem = 30;
            timeSinceItem = 0;
            useItemDone = true;

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
            return new Rectangle(x, y, linkWidth, linkHeight);
        }
        public void KnockedBack(string collisionSide)
        {
            movable = false;
            state.KnockedBack(collisionSide);
        }
        public void StopMoving(string side, Rectangle interRect)
        {
            if (side == "down")
            {
                y -= interRect.Height;
                if (Math.Abs(interRect.Width - linkWidth) > linkWidth / 2)
                {
                    if (interRect.X == x)
                    {
                        x++;
                    }
                    else if (interRect.X != x)
                    {
                        x--;
                    }
                }
            }
            if (side == "right")
            {
                x -= interRect.Width;
                if (Math.Abs(interRect.Height - linkHeight) > linkHeight / 2)
                {
                    if (interRect.Y == y)
                    {
                        y++;
                    }
                    else if (interRect.Y != y)
                    {
                        y--;
                    }
                }
            }
            if (side == "up")
            {
                y += interRect.Height;
                if (Math.Abs(interRect.Width - linkWidth) > linkWidth / 2)
                {
                    if (interRect.X == x)
                    {
                        x++;
                    }
                    else if (interRect.X != x)
                    {
                        x--;
                    }
                }
            }
            if (side == "left")
            {
                x += interRect.Width;
                if (Math.Abs(interRect.Height - linkHeight) > linkHeight / 2)
                {
                    if (interRect.Y == y)
                    {
                        y++;
                    }
                    else if (interRect.Y != y)
                    {
                        y--;
                    }
                }
            }
        }
        public void ResetPos()
        {
            // temp for sprint 3
            x = 98;
            y = 242;
        }
        public void Die()
        {
            isDead = true;
            state = new DeadLink(this);
        }
        public void Update()
        {
            if (!item[itemIndex].IsDone())
            {
                itemIndex++;
            }
            else if (itemIndex > 0 && item[itemIndex - 1].IsDone())
            {
                itemIndex--;
            }

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
            state.Update();
            for (int i = 0; i < MAX_ITEM_SPRITE_NUM; i++)
            {
                item[i].Update(x, y, directionIndex);
            }

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
            state.Draw(spriteBatch);
            for (int i = 0; i < MAX_ITEM_SPRITE_NUM; i++)
            {
                item[i].Draw(spriteBatch);
            }
        }
        public string GetStateName()
        {
            return state.GetStateName();
        }
    }
}
