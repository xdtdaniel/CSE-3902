using Game1.Code.LoadFile;
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
    class FieldBlast : IPlayerAbility
    {
        private Link link;
        private ItemPool itemPool;
        private bool learned = false;

        private static int scale = (int)LoadAll.Instance.scale;

        private int x;
        private int y;
        private int offset_y = 26 * scale;
        private int radius = 15 * scale;

        private int currentFrame = 0;
        private int secondFrame = 0;
        private int maxSecondFrame = 10;
        private int totalFrame = 8;

        // cooldown: 30s
        private static int cooldown = 30;
        private int timeBetweenAbility = cooldown * 60;
        private int timeSinceAbility = cooldown * 60;
        private bool usingAbility = false;

        public FieldBlast(Link link, ItemPool itemPool)
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
                if (secondFrame >= maxSecondFrame)
                {
                    secondFrame = 0;
                    int Radius = radius + currentFrame * 20 * scale;
                    for (int i = 0; i < 8; i++)
                    {
                        float angle = (float)((Math.PI / 180) * 45 * i);
                        int swordOffset_x = (int)(Radius * Math.Sin(angle));
                        int swordOffset_y = -(int)(Radius * Math.Cos(angle));
                        itemPool.GetItemPool().Add(new DropBlade(link, x + swordOffset_x, y - offset_y + swordOffset_y));
                    }
                    currentFrame++;
                }

                if (currentFrame >= totalFrame)
                {
                    usingAbility = false;
                    currentFrame = 0;
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
