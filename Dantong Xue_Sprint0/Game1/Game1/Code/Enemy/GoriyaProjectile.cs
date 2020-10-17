using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Enemy
{
    class GoriyaProjectile : IProjectile
    {
        private Texture2D Texture;
        private int Direction;
        private Vector2 Location;
        private Vector2 OriginLocation;
        private int Rows = 1;
        private int Columns;
        private int TotalFrames;
        private int CurrentFrame;
        private double Velocity;
        private double NegativeVelocity;
        private bool IsOnScreen;
        private int ChangeDirectionTimer = 0;
        private int FrameRateModifier = 0;

        // Test code for sprint 3 rectangle
        private Rectangle CollisionRectangle;

        private int scale = 3;

        public GoriyaProjectile()
        {
            Random Rnd = new Random();
            Texture = EnemyTextureStorage.GetGoriyaProjectileSpriteSheet();
            TotalFrames = 8;
            Columns = TotalFrames;
            CurrentFrame = Rnd.Next(8);
            Velocity = 5.0;
            NegativeVelocity = -5.0;

            // Test code for sprint 3 rectangle
            CollisionRectangle = new Rectangle((int)Location.X, (int)Location.Y - 4 * scale, 8 * scale, 8 * scale);
        }

        public void DrawProjectile(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X + 20, (int)Location.Y, width * 5, height * 5);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void UpdateProjectile()
        {
            if (FrameRateModifier < 3)
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

            UpdateLocation();

            if (ChangeDirectionTimer >= 70)
            {
                if (Velocity > NegativeVelocity)
                {
                    Velocity -= 0.25;
                }
            }
            else
            {
                if (HitEdge())
                {
                    Velocity = 0.0 - Velocity;
                    ChangeDirectionTimer = 0;
                }
                ChangeDirectionTimer++;
            }

            if (Location == OriginLocation)
            {
                IsOnScreen = false;
                Velocity = 5.0;
            }

        }

        private void UpdateLocation()
        {

            float x = Location.X;
            float y = Location.Y;

            if (Direction == 0)
            {
                y -= (float)Velocity;
            }
            else if (Direction == 1)
            {
                x += (float)Velocity;
            }
            else if (Direction == 2)
            {
                y += (float)Velocity;
            }
            else if (Direction == 3)
            {
                x -= (float)Velocity;
            }

            Location = new Vector2(x, y);

            // Test code for sprint 3 rectangle
            CollisionRectangle = new Rectangle((int)Location.X, (int)Location.Y - 4 * 5, 8 * 5, 8 * 5);
        }

        private bool HitEdge()
        {
            Boolean outside = false;
            if (Location.X <= 32 * scale || Location.Y <= 32 * scale || Location.Y >= 144 * scale || Location.X <= 192 * scale)
            {
                outside = true;
            }
            return outside;
        }

        public bool GetIsOnScreen()
        {
            return IsOnScreen;
        }

        public void SetIsOnScreen()
        {
            IsOnScreen = true;
            ChangeDirectionTimer = 0;
        }

        public void SetLocation(Vector2 location)
        {
            Location = location;
            OriginLocation = location;
        }
        public void SetDirection(int direction)
        {
            Direction = direction;
        }

        Rectangle IProjectile.GetRectangle()
        {
            return CollisionRectangle;
        }
    }
}
