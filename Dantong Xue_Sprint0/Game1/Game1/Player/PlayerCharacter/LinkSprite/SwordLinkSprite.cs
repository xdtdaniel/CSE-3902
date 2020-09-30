using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Player
{
    class SwordLinkSprite : IPlayerSprite
    {
        int Columns;
        Texture2D Texture;
        public SwordLinkSprite(Texture2D texture)
        {
            Texture = texture;
            Columns = 4;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction) 
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height;
            int currentColumn = 3 - currentFrame;
            int sourceX = currentColumn * width;
            if (direction == 1)
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
            else if (direction == 3)
            {
                switch (currentFrame)
                {
                    case 0:
                        sourceX = 0;
                        width = 120;
                        x -= 24;
                        break;
                    case 1:
                        sourceX = 120;
                        width = 144;
                        x -= 54;
                        break;
                    case 2:
                        sourceX = 264;
                        width = 166;
                        x -= 68;
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
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
