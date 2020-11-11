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
        // link's properties
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
        private int doorPositionOffset;
        public string direction;
        public int directionIndex;
        public IPlayerLinkState state;

        // link's items
        public Dictionary<string, int> itemList;
        public LinkItem[] itemPool;
        public bool useItemDone;
        public int itemIndex;
        private const int MAX_ITEM_SPRITE_NUM = 1000;

        // time intervals
        public int timeBetweenAttack;
        public int timeSinceAttack;
        public int timeBetweenItem;
        public int timeSinceItem;

        // environmental informations
        private int blockSideLength;
        private int numberOfBlocksBetweenRoom;


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
            doorPositionOffset = 12;

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
            itemList.Add("WoodenSword", 1);
            itemList.Add("SwordBeam", 0);

            // for test
            itemList["Key"] = 66;
            itemList["Ruby"] = 99;
            itemList["Arrow"] = 99;

            state = new NormalLink(this);

            itemPool = new LinkItem[MAX_ITEM_SPRITE_NUM];
            for (int i = 0; i < MAX_ITEM_SPRITE_NUM; i++)
            {
                itemPool[i] = new LinkItem(this);
                itemPool[i].state = new NoItem(itemPool[i]);
            }

            timeBetweenAttack = 30;
            timeSinceAttack = 0; 
            timeBetweenItem = 30;
            timeSinceItem = 0;
            useItemDone = true;

        }
        public void TakeDamage(int dmgAmount)
        {
            state.TakeDamage(dmgAmount);
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
                    y -= (numberOfBlocksBetweenRoom * blockSideLength - doorPositionOffset * scale);
                    break;
                case "down":
                    y += (numberOfBlocksBetweenRoom * blockSideLength - doorPositionOffset * scale);
                    break;
                case "left":
                    x -= (numberOfBlocksBetweenRoom * blockSideLength - doorPositionOffset * scale);
                    break;
                case "right":
                    x += (numberOfBlocksBetweenRoom * blockSideLength - doorPositionOffset * scale);
                    break;
                case "stairs":
                    if (LoadAll.Instance.GetCurrentMapID() == 3)
                    {
                        x -= 2 * blockSideLength;
                        y -= blockSideLength;
                    }
                    else if (LoadAll.Instance.GetCurrentMapID() == 1)
                    {
                        x += blockSideLength;
                        y += 2 * blockSideLength;
                    }
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
            // SwordBeam is the upgraded version of WoodenSword
            if (itemList["SwordBeam"] > 0)
            {
                itemList["WoodenSword"] = 0;
                attackDamage = 2;
            }

            if (!itemPool[itemIndex].IsDone())
            {
                itemIndex++;
            }
            else if (itemIndex > 0 && itemPool[itemIndex - 1].IsDone())
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
                itemPool[i].Update(x, y, directionIndex);
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
                itemPool[i].Draw(spriteBatch);
            }
        }
        public string GetStateName()
        {
            return state.GetStateName();
        }
        public int GetMaxSpriteNumOnScreen()
        {
            return MAX_ITEM_SPRITE_NUM;
        }
    }
}
