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
    class Compass:IItemSprite
    {
        Texture2D Texture;
        int height;
        int width;
        private Rectangle CollisionRectangle;
        private int x;
        private int y;
        public Compass( int position_x, int position_y)
        {
            Texture = Factory.CreateCompass();
            x = position_x;
            y = position_y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            height = Texture.Height;
            width = Texture.Width;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width * 3, height * 3);
            CollisionRectangle = destinationRectangle;

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
        public void Update()
        {

        }
        public Rectangle GetRectangle()
        {
            return CollisionRectangle;
        }
    }
}
