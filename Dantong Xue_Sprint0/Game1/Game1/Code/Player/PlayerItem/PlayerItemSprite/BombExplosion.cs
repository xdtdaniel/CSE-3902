using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Player
{
    class BombExplosion : IPlayerItemSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private Texture2D Texture;
        private int sourceWidth;
        private int sourceHeight;
        private int destinationWidth;
        private int destinationHeight;
        private int column = 3;
        private int widthDivider = 16;
        private int heightDivider = 16;
        private int collisionWidth = scale * 100;
        private int collisionHeight = scale * 100;
        private int offsetX = 2 * scale;
        private int numberOfSprite = 9;
        public BombExplosion(Texture2D texture)
        {
            Texture = texture;
            sourceWidth = texture.Width / column;
            sourceHeight = texture.Height;
            destinationWidth = (int)(LoadAll.Instance.scale * widthDivider);
            destinationHeight = (int)(LoadAll.Instance.scale * heightDivider);
        }
        public Rectangle Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction)
        {

            Rectangle sourceRectangle = new Rectangle(currentFrame * sourceWidth, 0, sourceWidth, sourceHeight);
            Rectangle[] destinationRectangles = new Rectangle[numberOfSprite];
            destinationRectangles[0] = new Rectangle(x - offsetX, y, destinationWidth, destinationHeight);              
            destinationRectangles[1] = new Rectangle(x - offsetX - destinationWidth, y, destinationWidth, destinationHeight);
            destinationRectangles[2] = new Rectangle(x - offsetX + destinationWidth, y, destinationWidth, destinationHeight);
            destinationRectangles[3] = new Rectangle(x - offsetX, y - destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[4] = new Rectangle(x - offsetX - destinationWidth, y - destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[5] = new Rectangle(x - offsetX + destinationWidth, y - destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[6] = new Rectangle(x - offsetX, y + destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[7] = new Rectangle(x - offsetX - destinationWidth, y + destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[8] = new Rectangle(x - offsetX + destinationWidth, y + destinationHeight, destinationWidth, destinationHeight);

            for (int i = 0; i < numberOfSprite; i++)
            {
                spriteBatch.Draw(Texture, destinationRectangles[i], sourceRectangle, Color.White);
            }

            return new Rectangle(x - column * offsetX - collisionWidth / column, y - collisionHeight / column, collisionWidth, collisionHeight);
        }
    }
}
