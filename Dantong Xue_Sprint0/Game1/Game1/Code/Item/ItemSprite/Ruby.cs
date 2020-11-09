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
    class Ruby:IItemSprite
    {
        Texture2D Texture;
        int height;
        int width;
        private int Columns;
        private int Rows;
        private int TotalFrames;
        private int CurrentFrame;
        private int count = 0;
        private int maxcount = 6;
        private Rectangle CollisionRectangle;
        private int x;
        private int y;
        public Ruby(int position_x, int position_y)
        {
            Texture = ItemFactory.ItemSpriteFactory.CreateRuby();
            TotalFrames =2;
            Rows = 1;
            Columns = 2;
            CurrentFrame = 0;
            x = position_x;
            y = position_y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            width = 8 * (int)LoadAll.Instance.scale;
            height = 16 * (int)LoadAll.Instance.scale;
            int sourceWidth = Texture.Width / Columns;
            int sourceHeight = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(sourceWidth * column, sourceHeight * row, sourceWidth, sourceHeight);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);
            CollisionRectangle = destinationRectangle;

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
        public void Update()
        {
            count++;
            if (count==maxcount) {
                CurrentFrame++;
                if (CurrentFrame == TotalFrames) {
                    CurrentFrame = 0;
                }
                count = 0;
            }
        }
        public Rectangle GetRectangle()
        {
            return CollisionRectangle;
        }
    }
}
