using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Game1.Code.Block
{
    class MovingNonAnimatedBlock : IBlock
    {
        private ISprite Block;

        public MovingNonAnimatedBlock(Texture2D texture, int frameThreshold, Vector2 from, Vector2 to)
        {
            Block = new MovingNonAnimatedSprite(texture, frameThreshold, from, to);
        }

        public void DrawBlock(SpriteBatch spriteBatch)
        {
            // the location (0, 0) here is not necessarily needed since the trace of movement is based on from and to above
            Block.Draw(spriteBatch, new Vector2(0, 0));
        }

        public void UpdateBlock()
        {
            Block.Update();
        }
    }
}
