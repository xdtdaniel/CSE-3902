using Game1.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Gel : IEnemy
    {
        private Texture2D Texture;
        private int Columns;
        private int Rows = 1;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location { get; set; }
        private int MovingState = 0;
        private int Direction = 0;
        private int StateTimer = 0;
        private int MoveTimer = 0;
        private int FrameRateModifier = 0;

        // Test code for sprint 3 rectangle
        private Rectangle CollisionRectangle;
        private int scale = 3;
        private List<IProjectile> ProjectileList = new List<IProjectile>();

        public Gel(Vector2 location)
        {
            Texture = EnemyTextureStorage.GetGelSpriteSheet();
            TotalFrames = 2;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Location = location;

            // Test code for sprint 3 rectangle
            CollisionRectangle = new Rectangle((int)(Location.X + 1 * scale), (int)(Location.Y + 1 * scale), 8 * scale, 8 * scale);
        }

        public void DrawEnemy(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, width * scale, height * scale);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void FireProjectile()
        {
            // Do nothing.
        }

        public void UpdateEnemy()
        {
            Random rnd = new Random();

            if (FrameRateModifier == 5)
            {
                CurrentFrame++;
                FrameRateModifier = 0;
            }

            FrameRateModifier++;

            UpdateMovingState(rnd);

            if (MovingState == 1)
            {
                if (MoveTimer == 0)
                {
                    Direction = rnd.Next(4);
                }
                Move(Direction);
            }

            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
            }

        }

        private void UpdateMovingState(Random random)
        {
            if (StateTimer < 6 )
            {
                StateTimer++;
            }
            else
            {
                StateTimer = 0;
                MovingState = random.Next(2);
            }
        }

        private void Move(int direction)
        {
            float x = Location.X;
            float y = Location.Y;
            if (MoveTimer < 4)
            {
                if (direction == 0)
                {
                    y -= 4 * scale;
                    if (Location.Y <= 32 * scale)
                    {
                        y = 32 * scale;
                        MovingState = 0;
                    }
                }
                else if (direction == 1)
                {
                    x += 4 * scale;
                    if (Location.X >= 208 * scale)
                    {
                        x = 208 * scale;
                        MovingState = 0;
                    }
                }
                else if (direction == 2)
                {
                    y += 4 * scale;
                    if (Location.Y >= 128 * scale)
                    {
                        y = 128 * scale;
                        MovingState = 0;
                    }
                }
                else if (direction == 3)
                {
                    x -= 4 * scale;
                    if (Location.X <= 32 * scale)
                    {
                        x = 32 * scale;
                        MovingState = 0;
                    }
                }

                Location = new Vector2(x, y);

                // Test code for sprint 3 rectangle
                CollisionRectangle = new Rectangle((int)(Location.X + 4 * scale), (int)(Location.Y + 4 * scale), 8 * scale, 8 * scale);

                MoveTimer++;
            }
            else
            {
                MoveTimer = 0;
                StateTimer = 0;
                MovingState = 0;
            }
        }

        Rectangle IEnemy.GetRectangle()
        {
            return CollisionRectangle;
        }

        List<IProjectile> IEnemy.GetProjectile()
        {
            return ProjectileList;
        }
    }
}