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
using SharpDX.Direct2D1.Effects;

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
        public bool isDead;
        public int defaultSpeed;
        public int xSpeed, ySpeed;
        public int attackDamage;
        private int linkWidth;
        private int linkHeight;
        private int scale;

        public string direction;
        public int directionIndex;

        public Dictionary<string, int> itemList;

        public LinkItem[] item;

        public int timeBetweenAttack;
        public int timeSinceAttack;
        public int timeBetweenItem;
        public int timeSinceItem;
        public bool useItemDone;

        private int blockSideLength;
        private int numberOfBlocksBetweenRoom;

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
            isDead = false;
            defaultSpeed = xSpeed = ySpeed = 5;
            attackDamage = 1;
            scale = (int)LoadAll.Instance.scale;

            linkWidth = 13 * scale;
            linkHeight = 13 * scale;

            blockSideLength = 16 * scale;
            numberOfBlocksBetweenRoom = 5;

            itemIndex = 0;

            direction = "down";
            directionIndex = 0;

            itemList = new Dictionary<string, int>();
            itemList.Add("Arrow", 0);
            itemList.Add("Bomb", 0);
            itemList.Add("Boomerang", 0);
            itemList.Add("Bow", 0);
            itemList.Add("Clock", 0);
            itemList.Add("Compass", 0);
            itemList.Add("Heart", 6);                      // default current health = 6
            itemList.Add("HeartContainer", 6);             // default max health = 6
            itemList.Add("Key", 0);
            itemList.Add("Map", 0);
            itemList.Add("Ruby", 0);
            itemList.Add("Triforce", 0);
            itemList.Add("Fairy", 0);
            itemList.Add("BlueCandle", 0);
            itemList.Add("BluePotion", 0);
            itemList.Add("BlueRing", 0);
            itemList.Add("Sword", 1);

            // test
            itemList["HeartContainer"] = 30;
            itemList["Heart"] = 17;
            itemList["Bomb"] = 0;
            itemList["Key"] = 0;
            itemList["Ruby"] = 0;

            state = new NormalLink(this);

            item = new LinkItem[MAX_ITEM_SPRITE_NUM];
            for (int i = 0; i < MAX_ITEM_SPRITE_NUM; i++)
            {
                item[i] = new LinkItem(this);
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
            string doorSide = PlayerAndBlockCollisionHandler.doorSide;

            switch (doorSide)
            {
                case "up":
                    y -= numberOfBlocksBetweenRoom * blockSideLength;
                    break;
                case "down":
                    y += numberOfBlocksBetweenRoom * blockSideLength;
                    break;
                case "left":
                    x -= numberOfBlocksBetweenRoom * blockSideLength;
                    break;
                case "right":
                    x += numberOfBlocksBetweenRoom * blockSideLength;
                    break;
                default:
                    break;
            }
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
