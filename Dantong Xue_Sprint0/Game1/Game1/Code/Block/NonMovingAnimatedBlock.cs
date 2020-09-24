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

        ISprite Block;
        Vector2 Location;

        public NonMovingAnimatedBlock(Texture2D texture, Vector2 location, int rows, int columns)
        {
            Block = new NonMovingAnimatedSprite(texture, rows, columns);
            Location = location;
        }

        public void UpdateBlock()
        {
            Block.Update();
        }

        public void DrawBlock(SpriteBatch spriteBatch)
        {
            Block.Draw(spriteBatch, Location);
        }

    }
}
