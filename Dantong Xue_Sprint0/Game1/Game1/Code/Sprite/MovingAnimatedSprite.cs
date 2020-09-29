using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Game1
{
    class MovingAnimatedSprite:ISprite
    {

        private Texture2D Texture;
        private int Rows;
        private int Columns;
        private int FrameThreshold;
        private Vector2 From;
        private Vector2 To;

        private int currentFrame;
        private int totalFrames;
        private static int moveFrame;


        public MovingAnimatedSprite(Texture2D texture, int rows, int columns, int frameThreshold)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            FrameThreshold = frameThreshold;
        }

        public void SetPath(Vector2 from, Vector2 to)
        {
            From = from;
            To = to;
        }

        private Vector2 NewLocation()
        {
            float newX = From.X + (To.X - From.X) * moveFrame / FrameThreshold;
            float newY = From.Y + (To.Y - From.Y) * moveFrame / FrameThreshold;

            return new Vector2(newX, newY);
        }

        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
            moveFrame++;
            moveFrame %= FrameThreshold;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            location = NewLocation();

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
