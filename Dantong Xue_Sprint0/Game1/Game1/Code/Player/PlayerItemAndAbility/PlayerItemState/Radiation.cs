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
    class Radiation : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;

        private int damageMultiplier = 0;
        private bool done = false;

        private Link link;

        private Texture2D radiation;
        private int width = 5 * scale;
        private int height = 70 * scale;
        private int drawWidth;
        private int drawHeight;
        private int decrementSpeed = 1 * scale;
        private int speed = 2 * scale;
        private int x;
        private int y;
        private int offset_x;
        private int offset_y;

        private int distance = 80 * scale;

        private string direction;
        private int currentFrame = 0;
        private int totalFrame = 35;

        private Rectangle rect = new Rectangle();


        public Radiation(Link link, string direction, int x, int y)
        {
            this.link = link;
            this.direction = direction;
            this.x = x + link.linkWidth / 2;
            this.y = y + link.linkHeight / 2;

            switch (direction)
            {
                case "up":
                    offset_x = -height / 2;
                    offset_y = -distance + currentFrame * 2;
                    break;
                case "down":
                    offset_x = -height / 2;
                    offset_y = distance - currentFrame * 2;
                    break;
                case "left":
                    offset_x = -distance + currentFrame * 2;
                    offset_y = -height / 2;
                    break;
                case "right":
                    offset_x = distance - currentFrame * 2;
                    offset_y = -height / 2;
                    break;
            }

            radiation = HUDFactory.LoadSkySpot();
            
        }
        public string GetItemName()
        {
            return "Radiation";
        }
        public int GetDamage()
        {
            return link.basicAttackDamage * damageMultiplier;
        }
        public void CollisionResponse(int enemyIndex)
        {
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrame)
            {
                done = true;
            }

            //
            if (height > 0)
            {
                height -= decrementSpeed;
            }
            switch (direction)
            {
                case "up":
                    offset_x = -height / 2;
                    offset_y = -distance + currentFrame * speed;
                    break;
                case "down":
                    offset_x = -height / 2;
                    offset_y = distance - currentFrame * speed;
                    break;
                case "left":
                    offset_x = -distance + currentFrame * speed;
                    offset_y = -height / 2;
                    break;
                case "right":
                    offset_x = distance - currentFrame * speed;
                    offset_y = -height / 2;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;
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
            sourceRectangle = new Rectangle(0, 0, radiation.Width, radiation.Height);
            destinationRectangle = new Rectangle(x + offset_x, y + offset_y, drawWidth, drawHeight);
            spriteBatch.Draw(radiation, destinationRectangle, sourceRectangle, Color.White * 0.6f);


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

