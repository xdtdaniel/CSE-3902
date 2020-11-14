using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Player
{
    class Bomb : IPlayerItemSprite
    {
        private Texture2D Texture;
        private int sourceWidth;
        private int sourceHeight;
        private int destinationWidth;
        private int destinationHeight;
        private int widthDivider = 8;
        private int heightDivider = 15;
        public Bomb(Texture2D texture)
        {
            Texture = texture; 
            sourceWidth = texture.Width;
            sourceHeight = texture.Height;
            destinationWidth = (int)(LoadAll.Instance.scale * widthDivider);
            destinationHeight = (int)(LoadAll.Instance.scale * heightDivider);
        }
        public Rectangle Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction)
        {

            Rectangle sourceRectangle = new Rectangle(currentFrame * sourceWidth, 0, sourceWidth, sourceHeight);
            Rectangle destinationRectangle = new Rectangle(x, y, destinationWidth, destinationHeight);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            return destinationRectangle;
        }
    }
}
