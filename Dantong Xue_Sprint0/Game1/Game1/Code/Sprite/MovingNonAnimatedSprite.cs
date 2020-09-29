using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Game1
{
    class MovingNonAnimatedSprite:ISprite
    {
        private Texture2D Texture;
        private static int frame;
        private Vector2 From;
        private Vector2 To;
        private int FrameThreshold;

        public MovingNonAnimatedSprite(Texture2D texture, int frameThreshold)
        {
            Texture = texture;
            FrameThreshold = frameThreshold;
        }

        public void SetPath(Vector2 from, Vector2 to)
        {
            From = from;
            To = to;
        }

        private Vector2 NewLocation()
        {
            float newX = From.X + (To.X - From.X) * frame / FrameThreshold;
            float newY = From.Y + (To.Y - From.Y) * frame / FrameThreshold;

            return new Vector2(newX, newY);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = NewLocation();
            spriteBatch.Draw(Texture, new Rectangle((int)location.X, (int)location.Y, Texture.Width, Texture.Height), Color.White);
        }

        public void Update()
        {
            frame++;
            frame %= FrameThreshold;

        }
    }
}
