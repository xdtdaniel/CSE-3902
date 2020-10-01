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
    class Fairy:IItemSprite
    {
        Texture2D Texture;
        int height;
        int width;
       
        private int Columns;
        private int Rows;
        private int TotalFrames;
        private int CurrentFrame;
        private readonly double Sin15 = 0.2588190451;
        private readonly double Cos15 = 0.9659258262;
        public Fairy(Texture2D texture)
        {
            Texture = texture;
            TotalFrames = 2;
            Rows = 1;
            Columns = 2;
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
        /// <summary>
        /// Fairy should move randomly
        /// </summary>
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
