using Game1.Code.Item.ItemInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing.Text;

namespace Game1.Code.Item.ItemSprite
{
    class Fairy : IItemSprite
    {
        Texture2D Texture;
        int height;
        int width;

        private int Columns;
        private int Rows;
        private int TotalFrames;
        private int CurrentFrame;
        public int x = 400 ;
        public int y = 260;
        private int count = 0;
        private int maxcount = 10;
        private int displacement = 15;
        private int max_displacement = 100;
        private Rectangle CollisionRectangle;
        private Game game;

        public Fairy(Texture2D texture, Game g)
        {
            game = g;
            Texture = texture;
            TotalFrames = 2;
            Rows = 1;
            Columns = 2;
            CurrentFrame = 0;


        }
        /// <summary>
        /// Fairy move randomly inside the edges
        /// </summary>
        public void Update()
        {
            count++;
            if (count==maxcount) {
                height = game.GraphicsDevice.Viewport.Height;
                width = game.GraphicsDevice.Viewport.Width;
                CurrentFrame++;

                if (CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
                Random rdm = new Random();
                //move inside edges,if touch the edges, go back and change direction(x,y)
                if (x >= width)
                {
                    x -= rdm.Next(displacement, max_displacement);
                }
                else if (x <= 0)
                {
                    x += rdm.Next(displacement, max_displacement);
                }
                else if (y >= height)
                {
                    y -= rdm.Next(displacement, max_displacement);
                }
                else if (y <= 0)
                {
                    y += rdm.Next(displacement, max_displacement);
                }
                else
                {
                    x += rdm.Next(-displacement, displacement);
                    y += rdm.Next(-displacement, displacement);
                }
                count = 0;
            }

        }
        public void Draw(SpriteBatch spriteBatch, int positionx, int positiony)
        {
            width = Texture.Width / Columns;
            height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width * 3, height * 3);
            CollisionRectangle = destinationRectangle;
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
        public Rectangle GetRectangle()
        {
            return CollisionRectangle;
        }

    }
}
