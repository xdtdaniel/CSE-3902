using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    public interface IBlock
    {
        public void UpdateBlock();
        public Rectangle DrawBlock(SpriteBatch spriteBatch, Vector2 location);
        public void SetPath(Vector2 from, Vector2 to);
    }
}
