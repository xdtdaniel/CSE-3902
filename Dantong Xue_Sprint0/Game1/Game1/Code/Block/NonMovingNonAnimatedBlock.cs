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
        Vector2 Location;

        public NonMovingNonAnimatedBlock(Texture2D texture, Vector2 location)
        {
            Block = new NonMovingNonAnimatedSprite(texture);
            Location = location;
        }

        public void DrawBlock(SpriteBatch spriteBatch)
        {
            Block.Draw(spriteBatch, Location);
        }

        public void UpdateBlock()
        {
            // nothing to do for static sprites
        }
    }
}
