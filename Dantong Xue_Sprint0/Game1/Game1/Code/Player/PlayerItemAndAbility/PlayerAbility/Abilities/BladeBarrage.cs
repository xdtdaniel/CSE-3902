﻿using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerCharacter;
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
    class BladeBarrage : IPlayerAbility
    {
        private Link link;
        private ItemPool itemPool;
        private bool learned = false;

        private int x;
        private int y;
        private float angle = 0;
        private float angleInterval = (float)((Math.PI / 180) * 45);

        private int currentFrame = 0;
        private int secondFrame = 0;
        private int maxSecondFrame = 10;
        private int totalFrame = 8;

        // cooldown: 15s
        private static int cooldown = 15;
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

        private string abilityName = "[Blade Barrage]";
        private string description = "Generate 8 swords around Link,\n then launch them in turn\n to different diretions. ";

        public BladeBarrage(Link link, ItemPool itemPool)
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
                secondFrame++;
                if (secondFrame == maxSecondFrame)
                {
                    secondFrame = 0;
                    currentFrame++;
                    itemPool.GetItemPool().Add(new ShootBlade(link, angle, x, y));
                    angle += angleInterval;
                }
                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                    usingAbility = false;
                }
            }
            else
            {
                x = link.x;
                y = link.y;
            }
        }
        public void Draw(SpriteBatch sb)
        {
            //display below instruction
            sb.DrawString(des, abilityName, new Vector2(posX + namePre_x, posY + namePre_y), Color.White);
            sb.DrawString(des, description, new Vector2(posX + descPre_x, posY + descPre_y), Color.LimeGreen);

        }
        public void Updatelocation(float newStartX, float newStartY)
        {
            posX = (int)newStartX;
            posY = (int)newStartY;
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

       
    }
}
