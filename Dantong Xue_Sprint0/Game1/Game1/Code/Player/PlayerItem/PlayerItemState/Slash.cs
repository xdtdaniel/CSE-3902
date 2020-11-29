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

namespace Game1.Code.Player.PlayerItem.PlayerItemState
{
    class Slash : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;

        private int damageMultiplier = 1; // test
        private bool done = false;


        private Link link;

        private Texture2D slash;
        private int width = 45 * scale;
        private int height = 50 * scale;
        private int speed = 7 * scale;
        private int x;
        private int y;
        private int offset_x;
        private int offset_y;

        private int distance = 20 * scale;

        private string direction;
        private int currentFrame = 0;
        private int totalFrame = 1000;
        private float angle;

        private Rectangle rect = new Rectangle();


        public Slash(Link link, string direction, int x, int y)
        {
            AudioPlayer.swordSlash.Play();

            this.link = link;
            this.direction = direction;
            this.x = x + link.linkWidth / 2;
            this.y = y + link.linkHeight / 2;

            switch (direction)
            {
                // since the original sprite is facing left, we need to rotate it to the according direction
                case "up":
                    offset_y = distance - currentFrame * speed;
                    angle = (float)((Math.PI / 180) * 90);
                    break;
                case "down":
                    offset_y = -distance + currentFrame * speed;
                    angle = (float)((Math.PI / 180) * 270);
                    break;
                case "left":
                    offset_x = distance - currentFrame * speed;
                    angle = (float)((Math.PI / 180) * 0);
                    break;
                case "right":
                    offset_x = -distance + currentFrame * speed;
                    angle = (float)((Math.PI / 180) * 180);
                    break;
            }

            slash = PlayerAbilityFactory.Instance.GetSlash();
            
        }
        public string GetItemName()
        {
            return "Slash";
        }
        public int GetDamage()
        {
            return link.basicAttackDamage * damageMultiplier;
        }
        public void CollisionResponse()
        {
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrame)
            {
                done = true;
            }

            switch (direction)
            {
                case "up":
                    offset_y = distance - currentFrame * speed;
                    break;
                case "down":
                    offset_y = - distance + currentFrame * speed;
                    break;
                case "left":
                    offset_x = distance - currentFrame * speed;
                    break;
                case "right":
                    offset_x = - distance + currentFrame * speed;
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;
            int drawWidth = 0;
            int drawHeight = 0;
            switch (direction)
            {
                case "up":
                    drawWidth = height;
                    drawHeight = width;
                    break;
                case "down":
                    drawWidth = height;
                    drawHeight = width;
                    break;
                case "left":
                    drawWidth = width;
                    drawHeight = height;
                    break;
                case "right":
                    drawWidth = width;
                    drawHeight = height;
                    break;
            }
            sourceRectangle = new Rectangle(0, 0, slash.Width, slash.Height);
            destinationRectangle = new Rectangle(x + offset_x, y + offset_y, drawWidth, drawHeight);
            Vector2 origin = new Vector2(slash.Width / 2, slash.Height / 2);

            spriteBatch.Draw(slash, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);

        }
        
        public Rectangle GetRectangle()
        {
            rect = new Rectangle(x + offset_x, y + offset_y, width, height);
            
            return rect;
        }
        public bool IsDone()
        {
            return done;
        }
    }
}

