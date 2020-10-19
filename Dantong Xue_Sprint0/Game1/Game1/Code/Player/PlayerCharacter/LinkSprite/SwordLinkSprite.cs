using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Code.LoadFile;

namespace Game1.Player
{
    class SwordLinkSprite : IPlayerLinkSprite
    {
        int Columns;
        Texture2D Texture;
        int scaler;
        public SwordLinkSprite(Texture2D texture)
        {
            Texture = texture;
            Columns = 4;
            scaler = 2;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction) 
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height;
            int currentColumn = 3 - currentFrame;
            int sourceX = currentColumn * width;
            int drawX = x;
            int drawY = y;

            if (direction == 1) // facing right
            {
                switch (currentFrame)
                {
                    case 0:
                        sourceX = 408;
                        width = 120;
                        break;
                    case 1:
                        sourceX = 264;
                        width = 144;
                        break;
                    case 2:
                        sourceX = 98;
                        width = 166;
                        break;
                    case 3:
                        sourceX = 0;
                        width = 98;
                        break;
                    default:
                        break;
                }
            }
            else if (direction == 2) // facing back
            {
                drawY -= 36;
            }
            else if (direction == 3) // facing left
            {
                switch (currentFrame)
                {
                    case 0:
                        sourceX = 0;
                        width = 120;
                        drawX -= 12;
                        break;
                    case 1:
                        sourceX = 120;
                        width = 144;
                        drawX -= 27;
                        break;
                    case 2:
                        sourceX = 264;
                        width = 166;
                        drawX -= 34;
                        break;
                    case 3:
                        sourceX = 430;
                        width = 98;
                        break;
                    default:
                        break;
                }
            }

            Rectangle sourceRectangle = new Rectangle(sourceX, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(drawX, drawY, (int)(LoadAll.Instance.scale * width / 8), (int)(LoadAll.Instance.scale * height / 8));

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
