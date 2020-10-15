using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Player
{
    class BombExplosion : IPlayerSprite
    {
        Texture2D Texture;
        public BombExplosion(Texture2D texture)
        {
            Texture = texture;
        }
        public Rectangle Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction)
        {
            int width = Texture.Width / 3;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(currentFrame * width, 0, width, height);
            Rectangle[] destinationRectangles = new Rectangle[9];
            destinationRectangles[0] = new Rectangle(x - 20, y, 100, 100);              
            destinationRectangles[1] = new Rectangle(x - 20 - 100, y, 100, 100);
            destinationRectangles[2] = new Rectangle(x - 20 + 100, y, 100, 100);
            destinationRectangles[3] = new Rectangle(x - 20, y - 100, 100, 100);
            destinationRectangles[4] = new Rectangle(x - 20 - 100, y - 100, 100, 100);
            destinationRectangles[5] = new Rectangle(x - 20 + 100, y - 100, 100, 100);
            destinationRectangles[6] = new Rectangle(x - 20, y + 100, 100, 100);
            destinationRectangles[7] = new Rectangle(x - 20 - 100, y + 100, 100, 100);
            destinationRectangles[8] = new Rectangle(x - 20 + 100, y + 100, 100, 100);

            for (int i = 0; i < 9; i++)
            {
                spriteBatch.Draw(Texture, destinationRectangles[i], sourceRectangle, Color.White);
            }

            return new Rectangle(x - 20 - 100, y - 100, 300, 300);
        }
    }
}
