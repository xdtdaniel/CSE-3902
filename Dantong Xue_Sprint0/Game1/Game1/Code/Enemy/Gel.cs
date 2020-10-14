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
        private Vector2 Location;
        private int MovingState = 0;
        private int Direction = 0;
        private int StateTimer = 0;
        private int MoveTimer = 0;
        private int FrameRateModifier = 0;

        // Test code for sprint 3 rectangle
        private Rectangle CollisionRectangle;

        public Gel()
        {
            Texture = EnemyTextureStorage.GetGelSpriteSheet();
            TotalFrames = 2;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Location = new Vector2(400, 200);

            // Test code for sprint 3 rectangle
            CollisionRectangle = new Rectangle((int)(Location.X + 4 * 5), (int)(Location.Y + 4 * 5), 8 * 5, 8 * 5);
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
                Move(Direction, game);
            }

            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
            }

        }

        private void UpdateMovingState(Random random)
        {
            if (StateTimer < 8 )
            {
                StateTimer++;
            }
            else
            {
                StateTimer = 0;
                MovingState = random.Next(2);
            }
        }

        private void Move(int direction, Game game)
        {
            float x = Location.X;
            float y = Location.Y;
            if (MoveTimer < 4)
            {
                if (direction == 0)
                {
                    y -= 20;
                    if (Location.Y < 0)
                    {
                        y = 0;
                        MovingState = 0;
                    }
                }
                else if (direction == 1)
                {
                    x += 20;
                    if (Location.X > game.Window.ClientBounds.Width - 80)
                    {
                        x = game.Window.ClientBounds.Width - 80;
                        MovingState = 0;
                    }
                }
                else if (direction == 2)
                {
                    y += 20;
                    if (Location.Y > game.Window.ClientBounds.Height - 80)
                    {
                        y = game.Window.ClientBounds.Height - 80;
                        MovingState = 0;
                    }
                }
                else if (direction == 3)
                {
                    x -= 20;
                    if (Location.X < 0)
                    {
                        x = 0;
                        MovingState = 0;
                    }
                }

                Location = new Vector2(x, y);

                // Test code for sprint 3 rectangle
                CollisionRectangle = new Rectangle((int)(Location.X + 4 * 5), (int)(Location.Y + 4 * 5), 8 * 5, 8 * 5);

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
    }
}