using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerCharacter;
using Game1.Code.Player.PlayerItem.PlayerItemState;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Zelda.Code.Player.PlayerCharacter;

namespace Game1.Code.Player.PlayerItem
{
    class BladeBarrage : IPlayerAbility
    {
        private Link link;
        private ItemPool itemPool;

        private int x;
        private int y;
        private float angle = 0;
        private float angleInterval = (float)((Math.PI / 180) * 45);
        private bool done = false;

        private int currentFrame = 0;
        private int secondFrame = 0;
        private int maxSecondFrame = 10;
        private int totalFrame = 8;

        public BladeBarrage(Link link, ItemPool itemPool)
        {
            this.link = link;
            this.itemPool = itemPool;
            x = link.x;
            y = link.y;
        }
        public void Update()
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
                done = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
        public string GetAbilityName()
        {
            return "BladeBarrage";
        }
        public bool IsDone()
        {
            return done;
        }
    }
}
