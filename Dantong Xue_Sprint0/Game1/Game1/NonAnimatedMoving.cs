using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class NonAnimatedMoving:ISprite
    {
        public Texture2D Texture { get; set; }
        private static int frame;

        public NonAnimatedMoving(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            spriteBatch.Draw(Texture, new Rectangle((int)location.X, frame, Texture.Width * 4, Texture.Height * 4), Color.White);
        }

        public void Update()
        {
            frame++;
            if (frame >= 480)
            {
                frame = 0;
            }

        }
    }
}
