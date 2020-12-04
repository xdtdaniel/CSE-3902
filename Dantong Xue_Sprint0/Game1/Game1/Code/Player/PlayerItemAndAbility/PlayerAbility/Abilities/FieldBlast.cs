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
using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;

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

        private SpriteFont des;
        private int posX;
        private int posY;

        public FieldBlast(Link link, ItemPool itemPool)
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
        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(des, "Press[1] ", new Vector2(posX + 125 * scale, posY + 236 * scale), Color.LightBlue);

        }
        public void Updatelocation(float newStartX, float newStartY)
        {
            posX = (int)newStartX;
            posY = (int)newStartY;
        }
    }
}
