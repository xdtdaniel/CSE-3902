﻿using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerCharacter;
using Game1.Code.Player.PlayerCharacter.LinkState;
using Game1.Code.Player.PlayerItem.PlayerItemState;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Zelda.Code.Player.PlayerCharacter;
using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;

namespace Game1.Code.Player.PlayerAbility
{
    class DeadlySlash : IPlayerAbility
    {
        private Link link;
        private ItemPool itemPool;
        private bool learned = false;

        private int x;
        private int y;

        private int currentFrame = 0;
        private int totalFrame = 180;
        private int stopVacuumFrame = 140;

        // cooldown: 9s
        private static int cooldown = 9;
        private int timeBetweenAbility = cooldown * 60;
        private int timeSinceAbility = cooldown * 60;
        private bool usingAbility = false;

        private SpriteFont des;
        private static int scale = (int)LoadAll.Instance.scale;
        private int posX;
        private int posY;
        private int namePre_x = 125 * scale;
        private int namePre_y = 240 * scale;
        private int descPre_x = 125 * scale;
        private int descPre_y = 260 * scale;

        private string abilityName = "[Deadly Slash]";
        private string description = "Stop the enmies in front\n of Link, then launch\n a huge sword beam.";
        public DeadlySlash(Link link, ItemPool itemPool)
        {
            this.link = link;
            this.itemPool = itemPool;
            des = HUDFactory.LoadSkillInstruction();
        }
        public void Update()
        {
            if (timeSinceAbility < timeBetweenAbility)
            {
                timeSinceAbility++;
            }
            if (usingAbility)
            {
                link.state = new UseItemLink(link);
                if (currentFrame >= totalFrame)
                {
                    usingAbility = false;
                    currentFrame = 0;

                    Camera.ShakeCamera(2);
                    itemPool.GetItemPool().Add(new Slash(link, link.GetDirectionAngle(), x, y));
                }
                else if (currentFrame % 10 == 0 && currentFrame < stopVacuumFrame)
                {
                    itemPool.GetItemPool().Add(new Radiation(link, link.direction, x, y));
                }
                currentFrame++;

            }
            else
            {
                x = link.x;
                y = link.y;
            }
        }
        public void Use()
        {
            if (timeSinceAbility >= timeBetweenAbility)
            {
                usingAbility = true;
                timeSinceAbility = 0;
            }
        }
        public string GetAbilityName()
        {
            return "BladeBarrage";
        }
        public bool IsLearned()
        {
            return learned;
        }
        public void Learn()
        {
            learned = true;
        }
        public float GetCooldownPercentage()
        {
            return (float)timeSinceAbility / timeBetweenAbility;
        }
        public float GetRemainingCooldown()
        {
            float cd = timeBetweenAbility - timeSinceAbility;
            return cd;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(des, abilityName, new Vector2(posX + namePre_x, posY + namePre_y), Color.White);
            sb.DrawString(des, description, new Vector2(posX + descPre_x, posY + descPre_y), Color.LimeGreen);
        }
        public void Updatelocation(float newStartX, float newStartY)
        {
            posX = (int)newStartX;
            posY = (int)newStartY;
        }
    }
}
