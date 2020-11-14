using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.LoadFile;

namespace Game1.Player
{
    class PickUpLinkSprite : IPlayerLinkSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int linkWidth = 13 * scale;
        private int linkHeight = 13 * scale;
        private int sourceHeight = 96;
        private int Columns = 2;
        private Texture2D Texture;
        public PickUpLinkSprite(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, string direction) 
        {
            int width = Texture.Width / Columns;
            int height = sourceHeight;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, linkWidth, linkHeight);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
