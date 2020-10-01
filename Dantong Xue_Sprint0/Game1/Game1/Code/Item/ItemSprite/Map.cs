using Game1.Code.Item.ItemInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Item.ItemSprite
{
    class Map:IItemSprite
    {
        Texture2D Texture;
        int height;
        int width;
        public Map(Texture2D texture)
        {
            Texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            height = Texture.Height;
            width = Texture.Width;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width * 3, height * 3);


            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
        public void Update(Game game)
        {

        }
    }
}
