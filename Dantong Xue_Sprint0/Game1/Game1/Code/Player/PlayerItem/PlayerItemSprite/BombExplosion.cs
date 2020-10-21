using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Player
{
    class BombExplosion : IPlayerItemSprite
    {
        Texture2D Texture;
        int sourceWidth;
        int sourceHeight;
        int destinationWidth;
        int destinationHeight;
        int collisionWidth;
        int collisionHeight;
        public BombExplosion(Texture2D texture)
        {
            Texture = texture;
            sourceWidth = texture.Width / 3;
            sourceHeight = texture.Height;
            destinationWidth = (int)(LoadAll.Instance.scale * 16);
            destinationHeight = (int)(LoadAll.Instance.scale * 16);
            collisionWidth = (int)(LoadAll.Instance.scale * 100);
            collisionHeight = (int)(LoadAll.Instance.scale * 100);
        }
        public Rectangle Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction)
        {

            Rectangle sourceRectangle = new Rectangle(currentFrame * sourceWidth, 0, sourceWidth, sourceHeight);
            Rectangle[] destinationRectangles = new Rectangle[9];
            destinationRectangles[0] = new Rectangle(x - 7, y, destinationWidth, destinationHeight);              
            destinationRectangles[1] = new Rectangle(x - 7 - destinationWidth, y, destinationWidth, destinationHeight);
            destinationRectangles[2] = new Rectangle(x - 7 + destinationWidth, y, destinationWidth, destinationHeight);
            destinationRectangles[3] = new Rectangle(x - 7, y - destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[4] = new Rectangle(x - 7 - destinationWidth, y - destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[5] = new Rectangle(x - 7 + destinationWidth, y - destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[6] = new Rectangle(x - 7, y + destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[7] = new Rectangle(x - 7 - destinationWidth, y + destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[8] = new Rectangle(x - 7 + destinationWidth, y + destinationHeight, destinationWidth, destinationHeight);

            for (int i = 0; i < 9; i++)
            {
                spriteBatch.Draw(Texture, destinationRectangles[i], sourceRectangle, Color.White);
            }

            return new Rectangle(x - 20 - collisionWidth / 3, y - collisionHeight / 3, collisionWidth, collisionHeight);
        }
    }
}
