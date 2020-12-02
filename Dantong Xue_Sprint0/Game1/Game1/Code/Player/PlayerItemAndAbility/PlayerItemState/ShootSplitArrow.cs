using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;
using Game1.Code.LoadFile;
using System;
using Game1.Code.Player.PlayerCharacter;
using Game1.Code.Audio;
using System.Diagnostics;
using System.Collections.Generic;
using Zelda.Code.Player.PlayerCharacter;

namespace Game1.Code.Player.PlayerItem.PlayerItemState
{
    class ShootSplitArrow : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;

        private int currentDamage;
        private bool done = false;
        private List<int> hitEnemyList = new List<int>();


        private int x;
        private int y;
        private int offset_x;
        private int offset_y;
        private int radius = 15 * scale;
        private int arrowWidth = 1 * scale;
        private int arrowHeight = 2 * scale;
        private int currentFrame = 0;
        private int secondFrame = 0;
        private int maxSecondFrame = 30;
        private int totalFrame = 3000;
        private int shootSpeed = 5 * scale;

        private int sfxWidth = 2 * scale;
        private int sfxHeight = 5 * scale;

        private float angle;
        private int scaler;

        private Texture2D arrow;
        private Texture2D sfx;

        private Link link;

        private Rectangle rect = new Rectangle();
        private ItemPool itemPool;


        public ShootSplitArrow(Link link, float angle, int x, int y, int scaler, ItemPool itemPool)
        {
            AudioPlayer.arrowShoot.Play();
            this.link = link;
            this.angle = angle;
            this.x = x + link.linkWidth / 2;
            this.y = y + link.linkHeight / 2;
            this.itemPool = itemPool;

            offset_x = (int)(radius * Math.Sin(angle));
            offset_y = -(int)(radius * Math.Cos(angle));

            this.scaler = scaler;
            this.arrowWidth *= scaler;
            this.arrowHeight *= scaler;
            this.sfxWidth *= scaler;
            this.sfxHeight *= scaler;

            currentDamage = scaler;

            arrow = PlayerAbilityFactory.Instance.GetArrow();
            sfx = PlayerAbilityFactory.Instance.GetBurstRing()[0];
        }
        public string GetItemName()
        {
            return "ShootArrow";
        }
        public int GetDamage()
        {
            return currentDamage;
        }
        public void CollisionResponse(int enemyIndex)
        {
            done = true;
            if (scaler > 2)
            {
                float angleOffset = (float)((Math.PI / 180) * 90); // split to two sides
                itemPool.GetItemPool().Add(new ShootSplitArrow(link, angle - angleOffset, x, y, --scaler, itemPool));
                itemPool.GetItemPool().Add(new ShootSplitArrow(link, angle + angleOffset, x, y, --scaler, itemPool));
            }
            
            if (enemyIndex != -1)
            {
                Camera.ShakeCamera(1);
            }

            if (hitEnemyList.Contains(enemyIndex))
            {
                currentDamage = 0;
            }
            else
            {
                currentDamage = scaler;
                hitEnemyList.Add(enemyIndex);
            }

        }
        public void Update()
        {
            secondFrame++;
            int speed_x;
            int speed_y;
            speed_x = (int)(shootSpeed * Math.Sin(angle));
            speed_y = -(int)(shootSpeed * Math.Cos(angle));

            x += speed_x;
            y += speed_y;
            if (secondFrame >= maxSecondFrame)
            {
                currentFrame++;
            }
            if (currentFrame >= totalFrame)
            {
                currentFrame = 0;
                done = true;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
            Rectangle destinationRectangle = new Rectangle(x + offset_x, y + offset_y, arrowWidth, arrowHeight);
            Vector2 origin = new Vector2(arrow.Width / 2, arrow.Height / 2);

            spriteBatch.Draw(arrow, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);

            sourceRectangle = new Rectangle(0, 0, sfx.Width, sfx.Height);
            destinationRectangle = new Rectangle(x + offset_x, y + offset_y, sfxWidth, sfxHeight);
            origin = new Vector2(sfx.Width / 2, sfx.Height / 2);

            spriteBatch.Draw(sfx, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);


        }

        public Rectangle GetRectangle()
        {
            rect = new Rectangle(x + offset_x - arrowWidth / 2, y + offset_y - arrowHeight / 2, arrowWidth, arrowHeight);
            
            return rect;
        }
        public bool IsDone()
        {
            return done;
        }
    }
}

