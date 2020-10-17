using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    public class NonMovingNonAnimatedBlock : IBlock
    {

        private ISprite Block;
        private Texture2D currTexture;

        public NonMovingNonAnimatedBlock(Texture2D texture)
        {
            currTexture = texture;
            Block = new NonMovingNonAnimatedSprite(texture);
            
        }

        public Rectangle DrawBlock(SpriteBatch spriteBatch, Vector2 location)
        {
            Block.Draw(spriteBatch, location);
            return new Rectangle((int)location.X, (int)location.Y, currTexture.Width * LoadAll.Instance.scale, currTexture.Height * LoadAll.Instance.scale);
        }

        public void UpdateBlock()
        {
            // nothing to do for static sprites
        }

        public void SetPath(Vector2 from, Vector2 to)
        {
            //nonmoving
        }
    }
}
