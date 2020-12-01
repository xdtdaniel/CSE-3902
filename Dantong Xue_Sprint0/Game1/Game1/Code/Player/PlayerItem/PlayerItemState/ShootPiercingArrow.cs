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

namespace Game1.Code.Player.PlayerItem.PlayerItemState
{
    class ShootPiercingArrow : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;

        private int damageMultiplier = 2;
        private int currentDamage = 2;
        private bool done = false;
        private List<int> hitEnemyList = new List<int>();

        private int x;
        private int y;
        private int offset_x;
        private int offset_y;
        private int radius = 15 * scale;
        private int arrowWidth = 6 * scale;
        private int arrowHeight = 13 * scale;
        private int currentFrame = 0;
        private int secondFrame = 0;
        private int maxSecondFrame = 30;
        private int thirdFrame = 0;
        private int maxThirdFrame = 10;
        private int totalFrame = 3000;
        private int floatSpeed = 1 * scale;
        private int shootSpeed = 10 * scale;

        private int sfxWidth = 35 * scale;
        private int sfxHeight = 60 * scale;
        private int sfxCurrentFrame = 0;
        private int sfxSecondFrame = 0;
        private int sfxTotalFrame = 3;
        private int sfxMaxSecondFrame = 30;

        private float angle;

        private Texture2D arrow;
        private Texture2D sfxRing;

        private Link link;

        private Rectangle rect = new Rectangle();


        public ShootPiercingArrow(Link link, float angle, int x, int y)
        {
            AudioPlayer.arrowShoot.Play();
            this.link = link;
            this.angle = angle;
            this.x = x + link.linkWidth / 2;
            this.y = y + link.linkHeight / 2;

            offset_x = (int)(radius * Math.Sin(angle));
            offset_y = -(int)(radius * Math.Cos(angle));

            arrow = PlayerAbilityFactory.Instance.GetArrow();
            sfxRing = PlayerAbilityFactory.Instance.GetBurstRing()[1];
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
                currentDamage = damageMultiplier;
                hitEnemyList.Add(enemyIndex);
            }

        }
        public void Update()
        {
            secondFrame++;
            if (secondFrame >= maxSecondFrame)
            {
                currentFrame++;
                thirdFrame++;
                int speed_x;
                int speed_y;
                if (thirdFrame < maxThirdFrame)
                {
                    speed_x = (int)(floatSpeed * Math.Sin(angle));
                    speed_y = -(int)(floatSpeed * Math.Cos(angle));
                }
                else
                {
                    speed_x = (int)(shootSpeed * Math.Sin(angle));
                    speed_y = -(int)(shootSpeed * Math.Cos(angle));
                    sfxSecondFrame++;
                    if (sfxSecondFrame >= sfxMaxSecondFrame)
                    {
                        sfxCurrentFrame++;
                    }
                    if (sfxCurrentFrame >= sfxTotalFrame)
                    {
                        sfxCurrentFrame = 0;
                    }
                }
                x += speed_x;
                y += speed_y;
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

            Debug.Print("offset y: " + offset_y.ToString());
            Debug.Print("y: " + y.ToString());
            Debug.Print("link y: " + link.y.ToString());
            spriteBatch.Draw(arrow, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);

            if (thirdFrame >= maxThirdFrame)
            {

                sourceRectangle = new Rectangle(0, 0, sfxRing.Width, sfxRing.Height);
                destinationRectangle = new Rectangle(x, y, sfxWidth, sfxHeight);
                origin = new Vector2(sfxRing.Width / 2, sfxRing.Height / 2);

                spriteBatch.Draw(sfxRing, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);


            }

        }

        public Rectangle GetRectangle()
        {
            if (thirdFrame >= maxThirdFrame)
            {
                rect = new Rectangle(x + offset_x - sfxWidth / 2, y + offset_y - sfxHeight / 2, sfxWidth, sfxHeight);
            }
            return rect;
        }
        public bool IsDone()
        {
            return done;
        }
    }
}

