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
    class QuickShot : IPlayerAbility
    {
        private Link link;
        private ItemPool itemPool;
        private bool learned = false;

        private int currentFrame = 0;
        private int totalFrame = 36;
        private int secondFrame = 0;
        private int maxSecondFrame = 5;

        // cooldown: 17s
        private static int cooldown = 17;
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

        private string abilityName = "[Quick Shot]";
        private string description = "Rapidly fire a number of \narrows for seconds";

        public QuickShot(Link link, ItemPool itemPool)
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
                    currentFrame++;
                    itemPool.GetItemPool().Add(new ShootQuickArrow(link, link.GetDirectionAngle(), link.x, link.y));
                }
                if (currentFrame >= totalFrame)
                {
                    currentFrame = 0;
                    usingAbility = false;
                }
                
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
