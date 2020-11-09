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
using System.Windows.Forms;
using Game1.Code.LoadFile;

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
        public int x;
        public int y;
        private int count = 0;
        private int maxcount = 10;
        private int displacement = 15;
        private int max_displacement = 100;
        private Rectangle CollisionRectangle;

        public Fairy(int position_x, int position_y)
        {
            Texture = ItemFactory.ItemSpriteFactory.CreateFairy();
            TotalFrames = 2;
            Rows = 1;
            Columns = 2;
            CurrentFrame = 0;
            x = position_x;
            y = position_y;

        }
        /// <summary>
        /// Fairy move randomly inside the edges
        /// </summary>
        public void Update()
        {
            count++;
            if (count==maxcount) {
                //height = game.GraphicsDevice.Viewport.Height;
                height = Screen.PrimaryScreen.Bounds.Height;
                //width = game.GraphicsDevice.Viewport.Width;
                width = Screen.PrimaryScreen.Bounds.Width;
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
        public Rectangle GetRectangle()
        {
            return CollisionRectangle;
        }

    }
}
