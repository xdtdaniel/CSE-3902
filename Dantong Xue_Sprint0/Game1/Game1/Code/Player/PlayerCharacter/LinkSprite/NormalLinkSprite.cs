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
    class NormalLinkSprite : IPlayerSprite
    {
        int Columns;
        Texture2D Texture;
        public NormalLinkSprite(Texture2D texture)
        {
            Texture = texture;
            Columns = 2;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction) 
        {
            int width = Texture.Width / Columns;
            int height = 96;


            Rectangle sourceRectangle = new Rectangle(currentFrame * width, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
