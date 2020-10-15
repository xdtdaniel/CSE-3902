using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Enemy
{
    class Wallmaster : IEnemy
    {
        // This class needs further modifications.

        private Texture2D Texture;
        private int Columns;
        private int Rows;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location;
        private int FrameRateModifier = 0;

        // Test code for sprint 3 rectangle
        private Rectangle CollisionRectangle;

        public Wallmaster()
        {
            Texture = EnemyTextureStorage.GetWallmasterSpriteSheet();
            TotalFrames = 8;
            Columns = 2;
            Rows = 4;
            CurrentFrame = 0;
            Location = new Vector2(600, 200);
        }

        public void DrawEnemy(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, width * 5, height * 5);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void FireProjectile()
        {
            // Do nothing.
        }

        public void UpdateEnemy(Game game)
        {
            if (FrameRateModifier < 11)
            {
                FrameRateModifier++;
            }
            else
            {
                CurrentFrame++;
                FrameRateModifier = 0;
            }

            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
            }
        }

        Rectangle IEnemy.GetRectangle()
        {
            // To Do
            return CollisionRectangle;
        }
    }
}
