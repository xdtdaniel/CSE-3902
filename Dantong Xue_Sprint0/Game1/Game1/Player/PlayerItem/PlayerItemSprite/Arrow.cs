using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_2.Player
{
    class Arrow : IPlayerSprite
    {
        Texture2D Texture;
        public Arrow(Texture2D texture)
        {
            Texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction)
        {
            int width = Texture.Width;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width / 5, height / 5);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
