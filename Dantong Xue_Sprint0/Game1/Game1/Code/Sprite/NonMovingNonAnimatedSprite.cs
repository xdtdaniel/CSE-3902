using Game1.Code.LoadFile;
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
        // private Vector2 location;

        public NonMovingNonAnimatedSprite(Texture2D texture)
        {
            Texture = texture;
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //multiply by picture's width and height, but the number might not big enough, can change to constant later

            spriteBatch.Draw(Texture, new Rectangle((int)location.X, (int)location.Y, (int)(Texture.Width * LoadAll.Instance.scale), (int)(Texture.Height * LoadAll.Instance.scale)), LoadAll.Instance.GetMapColor());
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
