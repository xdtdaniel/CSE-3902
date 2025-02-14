﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Game1.Code.LoadFile;
using Game1.Code.Audio;
using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerItem;
using Game1.Code.Player.PlayerCharacter.LinkState;
using Game1.Code.Player.CollisionHandler;
using Game1.Code.Player.PlayerItem.PlayerItemState;
using Zelda.Code.Player.PlayerCharacter;
using System.Diagnostics;

namespace Game1.Code.Player.PlayerCharacter
{
    public class Link
    {
        // link's properties
        private static int scale = (int)LoadAll.Instance.scale;
        public int x = (int)LoadAll.Instance.startPos.X + 122 * scale;
        public int y = (int)LoadAll.Instance.startPos.Y + 128 * scale;
        public int damageTimeCounter = 0;
        public bool isDamaged = false;
        public bool isMoving = false;
        public bool movable = true;
        public bool isInvincible = false;
        public bool isDead = false;
        public bool canAttack = true;
        public bool isCollidible = true;
        public int xSpeed = (int)(1.5 * scale);
        public int ySpeed = (int)(1.5 * scale);
        public int basicAttackDamage = 1;
        public int linkWidth = 13 * scale;
        public int linkHeight = 13 * scale;
        private int doorPositionOffset = 12 * scale;
        public string direction = "down";
        public int directionIndex = 0;
        public IPlayerLinkState state;

        // link's items
        public Dictionary<string, int> itemList;
        public Dictionary<string, int> buffList;
        public ItemPool itemPool;
        public bool useItemDone = true;
        private int swordBeamAttackDamage = 2;
        public int bombExplosionDamage = 5;

        public int abilityPoint = 1; // link has 1 ability point when started

        // time intervals
        public int timeBetweenAttack = 40;
        public int timeSinceAttack = 40;
        public int timeBetweenItem = 40;
        public int timeSinceItem = 40;
        public int timeBetweenJump = 15;
        public int timeSinceJump = 15;
        public int timeBetweenDash = 120;
        public int timeSinceDash = 120;
        private int timeBetweenCollision = 1;
        private int timeSinceCollision = 0;


        // environmental informations
        private int blockSideLength = 16 * scale;
        private int numberOfBlocksBetweenRoom = 5;
        public string collisionSide = "";

        // experience 
        public int linkLevel = 1;
        public int exp;
        public int expPerLevel = 10;
        private int prevKills;
        public Link()
        {
            state = new NormalLink(this);

            itemList = new Dictionary<string, int>();
            itemList.Add("Arrow", 0);
            itemList.Add("Bomb", 2);
            itemList.Add("Boomerang", 0);
            itemList.Add("Bow", 0);
            itemList.Add("Clock", 0);
            itemList.Add("Compass", 0);
            itemList.Add("Heart", 6);                      // default current health = 6
            itemList.Add("HeartContainer", 6);             // default max health = 6, heart container cannot be odd number
            itemList.Add("Key", 0);
            itemList.Add("Map", 0);
            itemList.Add("Ruby", 0);
            itemList.Add("Triforce", 0);
            itemList.Add("Fairy", 0);
            itemList.Add("BlueCandle", 0);
            itemList.Add("BluePotion", 0);
            itemList.Add("BlueRing", 0);
            itemList.Add("WoodenSword", 1);                // default weapon
            itemList.Add("SwordBeam", 0);
            itemList.Add("Crown", 0);

            buffList = new Dictionary<string, int>();
            buffList.Add("IceSword", 0);                   // no buffs at default

            itemPool = new ItemPool(this);

            exp = 0;   // an int used to count killed enemy
        }
        public void Upgrade()
        {
            AudioPlayer.getRupee.Play();
            linkLevel++;
            abilityPoint++;
        }
        public void Dash()
        {
            if (timeSinceDash >= timeBetweenDash && state.GetStateName() == "NormalLink")
            {
                timeSinceDash = 0;
                state = new DashLink(this);
            }
        }
        public void Jump()
        {
            if (timeSinceJump >= timeBetweenJump)
            {
                timeSinceJump = 0;
                state = new JumpLink(this);
            }
        }
        public void Attack()
        {
            // check buffed sword first
            if (buffList["IceSword"] > 0)
            {
                state = new IceSwordLink(this);
            }
            // if no buffs are applied, draw default sword sprite
            else
            {
                if (itemList["WoodenSword"] > 0)
                {
                    state = new WoodenSwordLink(this);
                }
                else if (itemList["SwordBeam"] > 0)
                {
                    state = new SwordBeamLink(this);
                }
            }

        }
        public void TakeDamage(int dmgAmount)
        {
            if (!this.isDead && !isInvincible)
            {
                state.TakeDamage(dmgAmount);

                AudioPlayer.linkHurt.Play();
            }
        }
        public void PickUp(int pickUp)
        {
            state.PickUp(pickUp);
        }
        public Rectangle GetRectangle()
        {
            if (isCollidible)
            {
                return new Rectangle(x, y, linkWidth, linkHeight);
            }
            else
            {
                return new Rectangle();
            }
        }
        public void KnockedBack(string collisionSide)
        {
            if (!isInvincible)
            {
                state.KnockedBack(collisionSide);
            }
        }
        public void StopMoving(string side, Rectangle interRect)
        {
            collisionSide = side;
            if (collisionSide == "down")
            {
                y -= interRect.Height;

                // if link is colliding with the edge of a block
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
            if (collisionSide == "right")
            {
                x -= interRect.Width;

                // if link is colliding with the edge of a block
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
            if (collisionSide == "up")
            {
                y += interRect.Height;

                // if link is colliding with the edge of a block
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
            if (collisionSide == "left")
            {
                x += interRect.Width;

                // if link is colliding with the edge of a block
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
                    y -= (numberOfBlocksBetweenRoom * blockSideLength - doorPositionOffset);
                    break;
                case "down":
                    y += (numberOfBlocksBetweenRoom * blockSideLength - doorPositionOffset);
                    break;
                case "left":
                    x -= (numberOfBlocksBetweenRoom * blockSideLength - doorPositionOffset);
                    break;
                case "right":
                    x += (numberOfBlocksBetweenRoom * blockSideLength - doorPositionOffset);
                    break;
                case "stairs":
                    // special case for rooms 1 and 3, move link to specific position
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
                    x = (int)(LoadAll.Instance.startPos.X + 35 * (int)scale);
                    y = (int)(LoadAll.Instance.startPos.Y + 56 * (int)scale + 35 * (int)scale);

                    break;
            }
        }
        public void Die()
        {
            isDead = true;
            state = new DeadLink(this);
            AudioPlayer.linkDead.Play();
        }

        public void Win()
        {
            state = new WinLink(this);
            LoadAll.Instance.ChangeMapColor(Color.Yellow);
        }


        public void Update()
        {
            if (exp >= expPerLevel)
            {
                prevKills = Enemy.DrawAndUpdateEnemy.numberOfKilled();
                Upgrade();
            }
            exp = Enemy.DrawAndUpdateEnemy.numberOfKilled() - prevKills;

            if (timeSinceCollision < timeBetweenCollision && collisionSide != "")
            {
                timeSinceCollision++;
            }
            else
            {
                collisionSide = "";
                timeSinceCollision = 0;
            }

            if (itemList["Heart"] == 1)
            {
                AudioPlayer.linkLowHealth.Play();
            }
            else
            {
                AudioPlayer.linkLowHealth.Stop();
            }
            // SwordBeam is the upgraded version of WoodenSword
            if (itemList["SwordBeam"] > 0)
            {
                itemList["WoodenSword"] = 0;
                basicAttackDamage = swordBeamAttackDamage;
            }


            // update direction index based on current direction
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

            // update state
            state.Update();

            // update item pool
            itemPool.Update();



            // increment time between attack and item
            if (timeSinceAttack < timeBetweenAttack)
            {
                timeSinceAttack++;
            }
            if (timeSinceItem < timeBetweenItem)
            {
                timeSinceItem++;
            }
            if (timeSinceJump < timeBetweenJump)
            {
                timeSinceJump++;
            }
            if (timeSinceDash < timeBetweenDash)
            {
                timeSinceDash++;
            }

            // update damage time if link is hurt
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
            // draw link
            state.Draw(spriteBatch);

            // draw item
            itemPool.Draw(spriteBatch);
        }
        public string GetStateName()
        {
            return state.GetStateName();
        }
        public float GetDirectionAngle()
        {
            return (float)((Math.PI / 180) * (360 - 90 * (directionIndex + 2)));
        }
    }
}
