using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Player
{
    class Bomb : IPlayerItemSprite
    {
        Texture2D Texture;
        int sourceWidth;
        int sourceHeight;
        int destinationWidth;
        int destinationHeight;
        public Bomb(Texture2D texture)
        {
            Texture = texture; 
            sourceWidth = texture.Width;
            sourceHeight = texture.Height;
            destinationWidth = (int)(LoadAll.Instance.scale * 8);
            destinationHeight = (int)(LoadAll.Instance.scale * 15);
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
