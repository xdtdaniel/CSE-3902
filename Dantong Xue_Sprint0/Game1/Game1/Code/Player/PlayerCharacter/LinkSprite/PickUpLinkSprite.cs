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
    class PickUpLinkSprite : IPlayerLinkSprite
    {
        int Columns;
        Texture2D Texture;
        public PickUpLinkSprite(Texture2D texture)
        {
            Texture = texture;
            Columns = 2;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction) 
        {
            int width = Texture.Width / Columns;
            int height = 96;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, 48, 48);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
