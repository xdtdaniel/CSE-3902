using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Player
{
    class Link: IPlayer
    {
        int currentFrame;
        int totalFrame;
        int secondFrame;
        int Columns;
        Texture2D Texture;
        public Link(ContentManager Content)
        {
            Texture = Content.Load<Texture2D>("Link");
            currentFrame = 0;
            totalFrame = 2;
            Columns = 8;
        }
        public void Update()
        {
            secondFrame++;
            if (secondFrame == 15)
            {
                currentFrame++;
                secondFrame = 0;
            }
        
            if (currentFrame == totalFrame)
            {
                currentFrame = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch, int x, int y, int direction) 
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height;
            int currentColumn = 0;

            switch (direction)
                {
                case 0: /* font */
                    currentColumn = 0 + currentFrame;
                    break;
                case 1: /* right */
                    currentColumn = 2 + currentFrame;
                    break;
                case 2: /* back */
                    currentColumn = 4 + currentFrame;
                    break;
                case 3: /* left */
                    currentColumn = 6 + currentFrame;
                    break;
                default: /* font */
                    currentColumn = 0 + currentFrame;
                    break;
            }

            Rectangle sourceRectangle = new Rectangle(width * currentColumn, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
