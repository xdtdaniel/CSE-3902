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

        public void SetPath(Vector2 from, Vector2 to)
        {
            //nonmoving
        }

        public Rectangle GetRectangle(Vector2 location)
        {
#           // those minor changes to the position and size is to avoid circumstances that the collision detection might be too strict that the player
            // cannot go through an empty place
            return new Rectangle((int)(location.X + 1), (int)(location.Y + 1), (int)(currTexture.Width * LoadAll.Instance.scale * 0.9), (int)(currTexture.Height * LoadAll.Instance.scale*0.9));
        }
    }
}
