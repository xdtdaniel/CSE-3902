﻿using Game1.Code.LoadFile;
using Game1.Code.Player.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Player.PlayerItem.PlayerItemSprite
{
    class Arrow : IPlayerItemSprite
    {
        private Texture2D Texture;
        private int sourceWidth;
        private int sourceHeight;
        private int destinationWidth;
        private int destinationHeight;
        private int widthDivider = 30;
        private int heightDivider = 30;
        public Arrow(Texture2D texture)
        {
            Texture = texture;
            sourceWidth = texture.Width;
            sourceHeight = texture.Height;
            destinationWidth = (int)(LoadAll.Instance.scale * Texture.Width / widthDivider);
            destinationHeight = (int)(LoadAll.Instance.scale * Texture.Height / heightDivider);
        }
        public Rectangle Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction)
        {

            Rectangle sourceRectangle = new Rectangle(0, 0, sourceWidth, sourceHeight);
            Rectangle destinationRectangle = new Rectangle(x, y, destinationWidth, destinationHeight);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            return destinationRectangle;
        }
    }
}
