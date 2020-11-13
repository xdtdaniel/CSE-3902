using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Player
{
    class WoodenSword: IPlayerItemSprite
    {
        Texture2D Texture;
        int sourceWidth;
        int sourceHeight;
        int destinationWidth;
        int destinationHeight;
        public WoodenSword(Texture2D texture)
        {
            Texture = texture;
            sourceWidth = texture.Width;
            sourceHeight = texture.Height;
            destinationWidth = (int)(LoadAll.Instance.scale * Texture.Width / 50);
            destinationHeight = (int)(LoadAll.Instance.scale * Texture.Height / 50);
        }
        public Rectangle Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction)
        {

            Rectangle sourceRectangle = new Rectangle(0, 0, sourceWidth, sourceHeight);
            Rectangle destinationRectangle = new Rectangle(x, y, destinationWidth, destinationHeight);
            Color spriteColor = Color.White;
            //if (currentFrame % 10 == 0)
            //{
            //    spriteColor = Color.Blue;
            //}
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, spriteColor);

            return destinationRectangle;
        }
    }
}
