using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Code.Item.ItemInterface;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Item.ItemSprite
{
    class Arrow : IItemSprite
    {
        Texture2D Texture;
        int height;
        int width;
        private Rectangle CollisionRectangle;
        private int x;
        private int y;
        public  Arrow(int position_x, int position_y)
        {
            Texture = ItemFactory.ItemSpriteFactory.CreateArrow();
            x = position_x;
            y = position_y;
            height = 16 * (int)LoadAll.Instance.scale;
            width = 6 * (int)LoadAll.Instance.scale;
        }
        public void Draw(SpriteBatch spriteBatch)
        {          

            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Rectangle destinationRectangle = new Rectangle(x+(int)LoadAll.Instance.startPos.X, y+(int)LoadAll.Instance.startPos.Y, width, height);
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
