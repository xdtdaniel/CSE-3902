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
    class ShootEmpoweredArrow : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;

        private int damageMultiplier = 7;
        private int currentDamage = 7;
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
        private int arrowTotalFrame = 90;
        private int shootSpeed = (int)(0.7 * scale);


        private bool hit = false;
        private int hitCurrentFrame = 0;
        private int hitPhase = 0;
        private int hitMaxPhase = 2;
        private int hitTotalFrame = 40;
        private int hit_x;
        private int hit_y;
        private int[] hitWidth = { 50 * scale, 100 * scale, 150 * scale };
        private int[] hitHeight = { 50 * scale, 100 * scale, 150 * scale };

        private float angle;

        private Texture2D arrow;
        private Texture2D[] hitExplosion;

        private Link link;

        private Rectangle rect = new Rectangle();


        public ShootEmpoweredArrow(Link link, float angle, int x, int y)
        {
            AudioPlayer.arrowShoot.Play();
            this.link = link;
            this.angle = angle;

            arrow_x = x + link.linkWidth / 2;
            arrow_y = y + link.linkHeight / 2;

            arrowOffset_x = (int)(arrowToLinkRadius * Math.Sin(angle));
            arrowOffset_y = -(int)(arrowToLinkRadius * Math.Cos(angle));


            arrow = PlayerAbilityFactory.Instance.GetArrow();
            hitExplosion = PlayerAbilityFactory.Instance.GetFireExplosion();
        }
        public string GetItemName()
        {
            if (!hit)
            {
                return "ShootArrow";
            }
            else
            {
                return "Explosion";
            }
        }
        public int GetDamage()
        {
            return link.basicAttackDamage * currentDamage;
        }
        public void CollisionResponse(int enemyIndex)
        {
            if (enemyIndex != -1)
            {
                Camera.ShakeCamera(1);
                hit = true;
            }
            

            if (hitEnemyList.Contains(enemyIndex) || !hit)
            {
                currentDamage = 0;
            }
            else
            {
                hitEnemyList.Add(enemyIndex);
                currentDamage = damageMultiplier;
            }

        }
        public void Update()
        {
            arrowCurrentFrame++;

            if (arrowCurrentFrame >= arrowTotalFrame)
            {
                arrowCurrentFrame = 0;
                hit = true;
            }

            int speed_x;
            int speed_y;
            speed_x = (int)(shootSpeed * Math.Sin(angle));
            speed_y = -(int)(shootSpeed * Math.Cos(angle));

            arrow_x += speed_x;
            arrow_y += speed_y;


            if (hit)
            {
                AudioPlayer.bombBlow.Play();
                hitCurrentFrame++;
                hitWidth[hitPhase]++;
                hitHeight[hitPhase]++;
                Camera.ShakeCamera(4);
            }
            else
            {
                hit_x = arrow_x + arrowOffset_x - arrowWidth / 2;
                hit_y = arrow_y + arrowOffset_y - arrowHeight / 2;
            }

            if (hitCurrentFrame >= hitTotalFrame)
            {
                hitCurrentFrame = 0;
                if (hitPhase < hitMaxPhase)
                {
                    hitPhase++;
                }
                else
                {
                    done = true;
                }
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;
            Vector2 origin;


            if (!hit)
            {
                sourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
                destinationRectangle = new Rectangle(arrow_x + arrowOffset_x, arrow_y + arrowOffset_y, arrowWidth, arrowHeight);
                origin = new Vector2(arrow.Width / 2, arrow.Height / 2);

                spriteBatch.Draw(arrow, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);

            }
            else
            {
                sourceRectangle = new Rectangle(0, 0, hitExplosion[hitPhase].Width, hitExplosion[hitPhase].Height);
                destinationRectangle = new Rectangle(hit_x, hit_y, hitWidth[hitPhase], hitHeight[hitPhase]);
                origin = new Vector2(hitExplosion[hitPhase].Width / 2, hitExplosion[hitPhase].Height / 2);


                spriteBatch.Draw(hitExplosion[hitPhase], destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);

            }

        }

        public Rectangle GetRectangle()
        {
            if (hit)
            {
                rect = new Rectangle(hit_x - hitWidth[hitPhase] / 2, hit_y - hitHeight[hitPhase] / 2, hitWidth[hitPhase], hitHeight[hitPhase]);
            }
            
            return rect;
        }
        public bool IsDone()
        {
            return done;
        }
    }
}

