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
    class Bomb : IPlayerItemSprite
    {
        Texture2D Texture;
        public Bomb(Texture2D texture)
        {
            Texture = texture;
        }
        public Rectangle Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction)
        {
            int width = Texture.Width;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(currentFrame * width, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, 25, 45);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            return destinationRectangle;
        }
    }
}
