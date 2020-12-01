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
    class ShootQuickArrow : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;

        private int damageMultiplier = 1;
        private int currentDamage = 1;
        private bool done = false;
        private List<int> hitEnemyList = new List<int>();


        private int x;
        private int y;
        private int offset_x;
        private int offset_y;
        private int radius = 15 * scale;
        private int arrowWidth = 6 * scale;
        private int arrowHeight = 12 * scale;
        private int currentFrame = 0;
        private int secondFrame = 0;
        private int maxSecondFrame = 30;
        private int totalFrame = 3000;
        private int shootSpeed = 5 * scale;

        private int minRange = -10 * scale;
        private int maxRange = 10 * scale;
        

        private int sfxWidth = 6 * scale;
        private int sfxHeight = 15 * scale;

        private int ring_x;
        private int ring_y;
        private int ringWidth = 15 * scale;
        private int ringHeight = 5 * scale;
        private int ringCurrentFrame = 0;
        private int ringTotalFrame = 5;

        private float angle;

        private Texture2D arrow;
        private Texture2D sfx;
        private Texture2D collision;

        private Link link;

        private Rectangle rect = new Rectangle();


        public ShootQuickArrow(Link link, float angle, int x, int y)
        {
            AudioPlayer.arrowShoot.Play();
            this.link = link;
            this.angle = angle;

            Random rd = new Random();
            this.x = x + link.linkWidth / 2 + rd.Next(minRange, maxRange);
            this.y = y + link.linkHeight / 2 + rd.Next(minRange, maxRange);

            offset_x = (int)(radius * Math.Sin(angle));
            offset_y = -(int)(radius * Math.Cos(angle));
            ring_x = this.x + offset_x;
            ring_y = this.y + offset_y;


            arrow = PlayerAbilityFactory.Instance.GetArrow();
            sfx = PlayerAbilityFactory.Instance.GetBurstRing()[0];
            collision = PlayerAbilityFactory.Instance.GetBurstRing()[2];
        }
        public string GetItemName()
        {
            return "ShootArrow";
        }
        public int GetDamage()
        {
            return link.basicAttackDamage * currentDamage;
        }
        public void CollisionResponse(int enemyIndex)
        {
            done = true;
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
                hitEnemyList.Add(enemyIndex);
                currentFrame = damageMultiplier;
            }

        }
        public void Update()
        {
            secondFrame++;
            ringCurrentFrame++;
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
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;
            Vector2 origin;

            if (ringCurrentFrame < ringTotalFrame)
            {
                sourceRectangle = new Rectangle(0, 0, collision.Width, collision.Height);
                destinationRectangle = new Rectangle(ring_x, ring_y, ringWidth, ringHeight);
                origin = new Vector2(collision.Width / 2, collision.Height / 2);


                spriteBatch.Draw(collision, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);
            }

            sourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
            destinationRectangle = new Rectangle(x + offset_x, y + offset_y, arrowWidth, arrowHeight);
            origin = new Vector2(arrow.Width / 2, arrow.Height / 2);

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

