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
    class Vacuum : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;

        private int damageMultiplier = 0;
        private bool done = false;

        private Link link;

        private Texture2D blackSpot;
        private int width = 5 * scale;
        private int height = 70 * scale;
        private int decrementSpeed = 1 * scale;
        private int blackSpeed = 2 * scale;
        private int black_x;
        private int black_y;
        private int blackOffset_x;
        private int blackOffset_y;

        private int distance = 80 * scale;

        private string direction;
        private int blackCurrentFrame = 0;
        private int blackTotalFrame = 35;

        private Rectangle rect = new Rectangle();


        public Vacuum(Link link, string direction, int x, int y)
        {
            this.link = link;
            this.direction = direction;
            black_x = x + link.linkWidth / 2;
            black_y = y + link.linkHeight / 2;

            switch (direction)
            {
                case "up":
                    blackOffset_x = -height / 2;
                    blackOffset_y = -distance + blackCurrentFrame * 2;
                    break;
                case "down":
                    blackOffset_x = -height / 2;
                    blackOffset_y = distance - blackCurrentFrame * 2;
                    break;
                case "left":
                    blackOffset_x = -distance + blackCurrentFrame * 2;
                    blackOffset_y = -height / 2;
                    break;
                case "right":
                    blackOffset_x = distance - blackCurrentFrame * 2;
                    blackOffset_y = -height / 2;
                    break;
            }

            blackSpot = HUDFactory.LoadSkySpot();
            
        }
        public string GetItemName()
        {
            return "Vacuum";
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
            blackCurrentFrame++;
            if (blackCurrentFrame == blackTotalFrame)
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
                    blackOffset_x = -height / 2;
                    blackOffset_y = -distance + blackCurrentFrame * blackSpeed;
                    break;
                case "down":
                    blackOffset_x = -height / 2;
                    blackOffset_y = distance - blackCurrentFrame * blackSpeed;
                    break;
                case "left":
                    blackOffset_x = -distance + blackCurrentFrame * blackSpeed;
                    blackOffset_y = -height / 2;
                    break;
                case "right":
                    blackOffset_x = distance - blackCurrentFrame * blackSpeed;
                    blackOffset_y = -height / 2;
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
            sourceRectangle = new Rectangle(0, 0, blackSpot.Width, blackSpot.Height);
            destinationRectangle = new Rectangle(black_x + blackOffset_x, black_y + blackOffset_y, drawWidth, drawHeight);
            spriteBatch.Draw(blackSpot, destinationRectangle, sourceRectangle, Color.White * 0.3f);


        }

        public Rectangle GetRectangle()
        {
            rect = new Rectangle(black_x + blackOffset_x, black_y + blackOffset_y, width, height);

            return rect;
        }
        public bool IsDone()
        {
            return done;
        }
    }
}

