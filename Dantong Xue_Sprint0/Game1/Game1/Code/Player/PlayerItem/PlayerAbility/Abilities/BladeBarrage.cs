using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerCharacter;
using Game1.Code.Player.PlayerItem.PlayerItemState;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Zelda.Code.Player.PlayerCharacter;

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

        private int timeBetweenAbility = 10;
        private int timeSinceAbility = 10;
        private bool usingAbility = false;


        public BladeBarrage(Link link, ItemPool itemPool)
        {
            this.link = link;
            this.itemPool = itemPool;
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
                    itemPool.GetItemPool().Add(new SingleBlade(link, angle, x, y));
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
        public void Use()
        {
            if (timeSinceAbility >= timeBetweenAbility)
            {
                usingAbility = true;
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
    }
}
