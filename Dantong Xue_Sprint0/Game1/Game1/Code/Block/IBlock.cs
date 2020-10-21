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
        public void DrawBlock(SpriteBatch spriteBatch, Vector2 location);
        public void SetDestination(string side);
        public Rectangle GetRectangle(Vector2 location);
    }
}
