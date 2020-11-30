using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerCharacter;
using Game1.Code.Player.PlayerCharacter.LinkState;
using Game1.Code.Player.PlayerItem.PlayerItemState;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Zelda.Code.Player.PlayerCharacter;

namespace Game1.Code.Player.PlayerAbility
{
    class LineImpact : IPlayerAbility
    {
        private Link link;
        private ItemPool itemPool;
        private bool learned = false;

        private int x;
        private int y;
        private int offset_x;
        private int offset_y;

        private int currentFrame = 0;
        private int totalFrame = 180;
        private int stopVacuumFrame = 140;

        private int timeBetweenAbility = 10;
        private int timeSinceAbility = 10;
        private bool usingAbility = false;


        public LineImpact(Link link, ItemPool itemPool)
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
                link.state = new UseItemLink(link);
                usingAbility = false;
                currentFrame = 0;

                itemPool.GetItemPool().Add(new Impact(link, link.direction, x, y));
                if (link.collisionSide != "")
                {
                    itemPool.GetItemPool().Add(new Impact(link, link.direction, x, y));
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
    }
}
