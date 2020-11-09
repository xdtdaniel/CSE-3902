using Game1.Code.Item.ItemInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.LoadFile;

namespace Game1.Code.Item.ItemSprite
{
    class Boomerang:IItemSprite
    {
        Texture2D Texture;
        int height;
        int width;
        private Rectangle CollisionRectangle;
        private int x;
        private int y;
        public Boomerang(int position_x, int position_y)
        {
            Texture = ItemFactory.ItemSpriteFactory.CreateBoomerang();
            x = position_x;
            y = position_y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            height = 16 * (int)LoadAll.Instance.scale;
            width = 8 * (int)LoadAll.Instance.scale;

            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);
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
