using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.LoadFile;

namespace Game1.Player
{
    class SwordLinkSprite : IPlayerLinkSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int sizeDivider = 8;

        private int rightSourceX_0 = 408;
        private int rightSourceX_1 = 264;
        private int rightSourceX_2 = 98;
        private int rightSourceX_3 = 0;
        private int rightSourceWidth_0 = 128;
        private int rightSourceWidth_1 = 144;
        private int rightSourceWidth_2 = 166;
        private int rightSourceWidth_3 = 98;

        private int upDrawingPositionOffsetY = 10 * scale;

        private int leftSourceX_0 = 0;
        private int leftSourceX_1 = 120;
        private int leftSourceX_2 = 264;
        private int leftSourceX_3 = 430;
        private int leftSourceWidth_0 = 120;
        private int leftSourceWidth_1 = 144;
        private int leftSourceWidth_2 = 166;
        private int leftSourceWidth_3 = 98;
        private int leftDrawingPostionOffsetX_0 = 2 * scale;
        private int leftDrawingPostionOffsetX_1 = 5 * scale;
        private int leftDrawingPostionOffsetX_2 = 6 * scale;

        private int Columns = 4;
        private Texture2D Texture;
        public SwordLinkSprite(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, string direction) 
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height;
            int currentColumn = 3 - currentFrame; // 4 columns in total, in this case, the first column starts from the right, so the initial column index is 3
            int sourceX = currentColumn * width;
            int drawX = x;
            int drawY = y;
            int scale = SwordLinkSprite.scale;

            if (direction == "right") // facing right
            {
                switch (currentFrame)
                {
                    case 0:
                        sourceX = rightSourceX_0;
                        width = rightSourceWidth_0;
                        break;
                    case 1:
                        sourceX = rightSourceX_1;
                        width = rightSourceWidth_1;
                        break;
                    case 2:
                        sourceX = rightSourceX_2;
                        width = rightSourceWidth_2;
                        break;
                    case 3:
                        sourceX = rightSourceX_3;
                        width = rightSourceWidth_3;
                        break;
                    default:
                        break;
                }
            }
            else if (direction == "up") // facing back
            {
                drawY -= upDrawingPositionOffsetY;
            }
            else if (direction == "left") // facing left
            {
                switch (currentFrame)
                {
                    case 0:
                        sourceX = leftSourceX_0;
                        width = leftSourceWidth_0;
                        drawX -= leftDrawingPostionOffsetX_0;
                        break;
                    case 1:
                        sourceX = leftSourceX_1;
                        width = leftSourceWidth_1;
                        drawX -= leftDrawingPostionOffsetX_1;
                        break;
                    case 2:
                        sourceX = leftSourceX_2;
                        width = leftSourceWidth_2;
                        drawX -= leftDrawingPostionOffsetX_2;
                        break;
                    case 3:
                        sourceX = leftSourceX_3;
                        width = leftSourceWidth_3;
                        break;
                    default:
                        break;
                }
            }

            Rectangle sourceRectangle = new Rectangle(sourceX, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(drawX, drawY, scale * width / sizeDivider, scale * height / sizeDivider);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
