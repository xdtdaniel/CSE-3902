using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    public class NonMovingNonAnimatedSprite : ISprite
    {

        private Texture2D Texture;

        public NonMovingNonAnimatedSprite(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            spriteBatch.Draw(Texture, new Rectangle((int)location.X, (int)location.Y, Texture.Width * 4, Texture.Height * 4), Color.White);
        }

        public void Update()
        {
            // nothing to do for static sprites
        }

        public void SetPath(Vector2 from, Vector2 to)
        {
            // nonmoving, nothing here
        }
    }
}
