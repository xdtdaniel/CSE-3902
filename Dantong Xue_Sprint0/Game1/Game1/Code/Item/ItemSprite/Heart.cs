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
    class Heart:IItemSprite
    {
        Texture2D Texture;
        int height;
        int width;
        private int Columns;
        private int Rows;
        private int TotalFrames;
        private int CurrentFrame;
        public Heart(Texture2D texture)
        {
            Texture = texture;
            TotalFrames = 4;
            Rows = 1;
            Columns = 4;
            CurrentFrame = 0;
        }
        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            width = Texture.Width / Columns;
            height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width * 3, height * 3);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
        public void Update()
        {
            CurrentFrame++;
            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
            }
        }

    }
}
