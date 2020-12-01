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


        private int arrow_x;
        private int arrow_y;
        private int arrowOffset_x;
        private int arrowOffset_y;
        private int arrowToLinkRadius = 15 * scale;
        private int arrowWidth = 6 * scale;
        private int arrowHeight = 12 * scale;
        private int arrowCurrentFrame = 0;
        private int arrowSecondFrame = 0;
        private int arrwMaxSecondFrame = 30;
        private int arrowTotalFrame = 3000;
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

        private bool hit = false;
        private int hitCurrentFrame = 0;
        private int hitTotalFrame = 10;
        private int hit_x;
        private int hit_y;
        private int hitWidth = 10 * scale;
        private int hitHeight = 10 * scale;

        private float angle;

        private Texture2D arrow;
        private Texture2D sfx;
        private Texture2D collision;
        private Texture2D hitExplosion;

        private Link link;

        private Rectangle rect = new Rectangle();


        public ShootQuickArrow(Link link, float angle, int x, int y)
        {
            AudioPlayer.arrowShoot.Play();
            this.link = link;
            this.angle = angle;

            Random rd = new Random();
            this.arrow_x = x + link.linkWidth / 2 + rd.Next(minRange, maxRange);
            this.arrow_y = y + link.linkHeight / 2 + rd.Next(minRange, maxRange);

            arrowOffset_x = (int)(arrowToLinkRadius * Math.Sin(angle));
            arrowOffset_y = -(int)(arrowToLinkRadius * Math.Cos(angle));
            ring_x = this.arrow_x + arrowOffset_x;
            ring_y = this.arrow_y + arrowOffset_y;


            arrow = PlayerAbilityFactory.Instance.GetArrow();
            sfx = PlayerAbilityFactory.Instance.GetBurstRing()[0];
            collision = PlayerAbilityFactory.Instance.GetBurstRing()[2];
            hitExplosion = PlayerAbilityFactory.Instance.GetFireExplosion();
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
            hit = true;
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
                arrowCurrentFrame = damageMultiplier;
            }

        }
        public void Update()
        {
            arrowSecondFrame++;
            ringCurrentFrame++;
            int speed_x;
            int speed_y;
            speed_x = (int)(shootSpeed * Math.Sin(angle));
            speed_y = -(int)(shootSpeed * Math.Cos(angle));

            arrow_x += speed_x;
            arrow_y += speed_y;
            if (arrowSecondFrame >= arrwMaxSecondFrame)
            {
                arrowCurrentFrame++;
            }
            if (arrowCurrentFrame >= arrowTotalFrame)
            {
                arrowCurrentFrame = 0;
                done = true;
            }
            if (hit)
            {
                hitCurrentFrame++;
            }
            else
            {
                hit_x = arrow_x + arrowOffset_x - arrowWidth / 2;
                hit_y = arrow_y + arrowOffset_y - arrowHeight / 2;
            }
            if (hitCurrentFrame >= hitTotalFrame)
            {
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

            if (!hit)
            {
                sourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
                destinationRectangle = new Rectangle(arrow_x + arrowOffset_x, arrow_y + arrowOffset_y, arrowWidth, arrowHeight);
                origin = new Vector2(arrow.Width / 2, arrow.Height / 2);

                spriteBatch.Draw(arrow, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);

                sourceRectangle = new Rectangle(0, 0, sfx.Width, sfx.Height);
                destinationRectangle = new Rectangle(arrow_x + arrowOffset_x, arrow_y + arrowOffset_y, sfxWidth, sfxHeight);
                origin = new Vector2(sfx.Width / 2, sfx.Height / 2);

                spriteBatch.Draw(sfx, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);
            }
            else
            {
                sourceRectangle = new Rectangle(0, 0, hitExplosion.Width, hitExplosion.Height);
                destinationRectangle = new Rectangle(hit_x, hit_y, hitWidth, hitHeight);
                origin = new Vector2(hitExplosion.Width / 2, hitExplosion.Height / 2);


                spriteBatch.Draw(hitExplosion, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);

            }

        }

        public Rectangle GetRectangle()
        {
            rect = new Rectangle(arrow_x + arrowOffset_x - arrowWidth / 2, arrow_y + arrowOffset_y - arrowHeight / 2, arrowWidth, arrowHeight);
            
            return rect;
        }
        public bool IsDone()
        {
            return done;
        }
    }
}

