using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.LoadFile;
using Game1.Code.Player.Interface;

namespace Game1.Code.Player.PlayerCharacter.LinkSprite
{
    class DashLinkSprite : IPlayerLinkSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int linkWidth = 13 * scale;
        private int linkHeight = 13 * scale;
        private int dashWidth = 9 * scale;
        private int dashHeight = 9 * scale;
        private int xOffset = 2 * scale;
        private int yOffset = 4 * scale;
        private int sourceHeight = 96;
        private int Columns = 2;
        private Texture2D Texture;
        public DashLinkSprite(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, string direction) 
        {
            int width = Texture.Width / Columns;
            int height = sourceHeight;

            switch (direction)
            {
                case "up":
                    linkWidth = dashWidth;
                    x += xOffset;
                    break;
                case "down":
                    linkWidth = dashWidth;
                    x += xOffset;
                    break;
                case "left":
                    linkHeight = dashHeight;
                    y += yOffset;
                    break;
                case "right":
                    linkHeight = dashHeight;
                    y += yOffset;
                    break;
                default:
                    break;
            }

            Rectangle sourceRectangle = new Rectangle(currentFrame * width, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, linkWidth, linkHeight);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
