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
    class Arrow : IPlayerItemSprite
    {
        Texture2D Texture;
        public Arrow(Texture2D texture)
        {
            Texture = texture;
        }
        public Rectangle Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction)
        {
            int width = Texture.Width;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width / 10, height / 10);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            return destinationRectangle;
        }
    }
}
