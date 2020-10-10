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

        public NonMovingNonAnimatedBlock(Texture2D texture, Vector2 location)
        {
            Block = new NonMovingNonAnimatedSprite(texture,location);
            
        }

        public void DrawBlock(SpriteBatch spriteBatch, Vector2 location)
        {
            Block.Draw(spriteBatch, location);
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
