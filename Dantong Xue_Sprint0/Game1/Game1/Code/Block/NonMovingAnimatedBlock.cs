using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Game1.Code.Block
{
    public class NonMovingAnimatedBlock : IBlock
    {

        private ISprite Block;

        public NonMovingAnimatedBlock(Texture2D texture, int rows, int columns)
        {
            Block = new NonMovingAnimatedSprite(texture, rows, columns);
        }

        public void UpdateBlock()
        {
            Block.Update();
        }

        public void DrawBlock(SpriteBatch spriteBatch, Vector2 location)
        {
            Block.Draw(spriteBatch, location);
        }

        public void SetPath(Vector2 from, Vector2 to)
        {
            //nonmoving
        }

    }
}
