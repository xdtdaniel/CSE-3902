using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;
using Game1.Code.LoadFile;
using System;
using Game1.Code.Player.PlayerCharacter;
using Game1.Code.Audio;
using System.Diagnostics;
using Game1.Code.HUD.Factory;
using System.Collections.Generic;

namespace Game1.Code.Player.PlayerItem.PlayerItemState
{
    class Slash : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;

        private int damageMultiplier = 3; // test
        private int currentDamage = 3;
        private bool done = false;
        private List<int> hitEnemyList = new List<int>();


        private Link link;

        private Texture2D slash;
        private int width = 50 * scale;
        private int height = 50 * scale;
        private int drawWidth;
        private int drawHeight;
        private int speed = 7 * scale;
        private int x;
        private int y;
        private int offset_x;
        private int offset_y;
        private int hitbox_x;
        private int hitbox_y;
        private int hitboxWidth = 50 * scale;
        private int hitboxHeight = 50 * scale;

        private int distance = 20 * scale;

        private int radius = 20 * scale;
        private float angle;
        private int currentFrame = 0;
        private int totalFrame = 1000;

        private Rectangle rect = new Rectangle();


        public Slash(Link link, float angle, int x, int y)
        {
            AudioPlayer.swordSlash.Play();

            this.link = link;
            this.angle = angle;
            this.x = x + link.linkWidth / 2;
            this.y = y + link.linkHeight / 2;

            offset_x = (int)(radius * Math.Sin(angle));
            offset_y = -(int)(radius * Math.Cos(angle));

            slash = PlayerAbilityFactory.Instance.GetSlash();
            
        }
        public string GetItemName()
        {
            return "Slash";
        }
        public int GetDamage()
        {
            return link.basicAttackDamage * currentDamage;
        }
        public void CollisionResponse(int enemyIndex)
        {
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
            currentFrame++;
            if (currentFrame >= totalFrame)
            {
                done = true;
            }

            int speed_x = (int)(speed * Math.Sin(angle));
            int speed_y = -(int)(speed * Math.Cos(angle));

            x += speed_x;
            y += speed_y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(0, 0, slash.Width, slash.Height);
            destinationRectangle = new Rectangle(x + offset_x, y + offset_y, width, height);
            Vector2 origin = new Vector2(slash.Width / 2, slash.Height / 2);
            hitbox_x = x + offset_x;
            hitbox_y = y + offset_y;

            spriteBatch.Draw(slash, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);

        }
        
        public Rectangle GetRectangle()
        {
            rect = new Rectangle(x + offset_x - width / 2, y + offset_y - height / 2, width, height);
            return rect;
        }
        public bool IsDone()
        {
            return done;
        }
    }
}

