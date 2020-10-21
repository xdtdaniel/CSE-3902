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

        public void DrawBlock(SpriteBatch spriteBatch, Vector2 location)
        {
            Block.Draw(spriteBatch, location);
            
        }

        public void UpdateBlock()
        {
            // nothing to do for static sprites
        }

        public void SetDestination(string side)
        {
            //nonmoving
        }

        public Rectangle GetRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, (int)(currTexture.Width * LoadAll.Instance.scale), (int)(currTexture.Height * LoadAll.Instance.scale));
        }
    }
}
