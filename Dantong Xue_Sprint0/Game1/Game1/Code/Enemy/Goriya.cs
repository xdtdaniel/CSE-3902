using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Enemy
{
    class Goriya : IEnemy
    {
        private Texture2D Texture;
        private int Columns;
        private int Rows = 1;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location { get; set; }
        private int Direction = 0;
        private int CanTurnTimer = 0;
        private int FrameRateModifier = 0;
        private Random Rnd;
        private int Velocity = 3;
        private bool CanTurn = true;
        private int FrameBound;

        private int FireTimer;
        private bool CanFire;
        private IProjectile Projectile;

        // Test code for sprint 3 rectangle
        private Rectangle CollisionRectangle;

        private int scale = 3;

        public Goriya(Vector2 location)
        {
            Texture = EnemyTextureStorage.GetGoriyaSpriteSheet();
            Rnd = new Random();
            TotalFrames = 8;
            CurrentFrame = 0;
            Columns = TotalFrames;
            Location = location;
            Direction = Rnd.Next(3);
            Projectile = new GoriyaProjectile();
            CanFire = true;
            FireTimer = 0;

            // Test code for sprint 3 rectangle
            CollisionRectangle = new Rectangle((int)Location.X + 1 * 5, (int)Location.Y, 14 * 5, 16 * 5);
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

            if (Projectile.GetIsOnScreen())
            {
                Projectile.DrawProjectile(spriteBatch);
            }
        }

        public void FireProjectile()
        {
            Velocity = 0;
            Projectile.SetIsOnScreen();
            Projectile.SetLocation(Location);
            Projectile.SetDirection(Direction);
            FireTimer = 0;
            CanFire = false;
        }

        public void UpdateEnemy()
        {
            if (FireTimer > Rnd.Next(150, 200) || Projectile.GetIsOnScreen())
            {
                if (CanFire)
                {
                    FireProjectile();
                }
                Projectile.UpdateProjectile();
            }
            else
            {
                Velocity = 3;

                UpdateCanTurn();

                if (CanTurn)
                {
                    UpdateDirection();
                    FrameBound = UpdateFacing();
                }

                FireTimer++;

                CanFire = true;
            }

            if (FrameRateModifier < 16)
            {
                FrameRateModifier++;
            }
            else
            {
                CurrentFrame++;
                FrameRateModifier = 0;
            }
            if (CurrentFrame > FrameBound)
            {
                CurrentFrame -= 2;
            }

            UpdateLocation();
        }

        public int GetDirection()
        {
            return Direction;
        }

        public Vector2 GetLocation()
        {
            return Location;
        }

        private int UpdateFacing()
        {
            switch (Direction)
            {
                case 0:
                    CurrentFrame = 2;
                    return 3;
                case 1:
                    CurrentFrame = 4;
                    return 5;
                case 2:
                    CurrentFrame = 0;
                    return 1;
                case 3:
                    CurrentFrame = 6;
                    return 7;
            }
            return -99;
        }

        private void UpdateCanTurn()
        {
            if ((UpBlocked() == 0 && Direction == 0) || (RightBlocked() == 0 && Direction == 1) || (DownBlocked() == 0 && Direction == 2) || (LeftBlocked() == 0 && Direction == 3))
            {
                CanTurn = true;
            }

            if (CanTurnTimer < 32)
            {
                CanTurnTimer++;
            }
            else
            {
                CanTurnTimer = 0;
                if (Rnd.Next(5) == 0)
                {
                    CanTurn = true;
                }
            }
        }

        private void UpdateDirection()
        {
            int[] blockedStatus = { UpBlocked(), RightBlocked(), DownBlocked(), LeftBlocked() };
            int[] turnableDirections = new int[4];
            int size = 0;

            for (int i = 0; i < 4; i++)
            {
                if (blockedStatus[i] == 1)
                {
                    turnableDirections[size] = i;
                    size++;
                }
            }

            Direction = turnableDirections[Rnd.Next(size)];

            CanTurn = false;
            CanTurnTimer = 0;
        }

        private int UpBlocked()
        {
            if (Location.Y <= 32 * scale)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private int RightBlocked()
        {
            if (Location.X >= 192 * scale)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private int DownBlocked()
        {
            if (Location.Y >= 144 * scale)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private int LeftBlocked()
        {
            if (Location.X <= 32 * scale)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void UpdateLocation()
        {
            float x = Location.X;
            float y = Location.Y;

            if (Direction == 0)
            {
                y -= Velocity;
            }
            else if (Direction == 1)
            {
                x += Velocity;
            }
            else if (Direction == 2)
            {
                y += Velocity;
            }
            else if (Direction == 3)
            {
                x -= Velocity;
            }

            Location = new Vector2(x, y);

            // Test code for sprint 3 rectangle
            CollisionRectangle = new Rectangle((int)Location.X + 1 * 5, (int)Location.Y, 14 * 5, 16 * 5);
        }

        Rectangle IEnemy.GetRectangle()
        {
            return CollisionRectangle;
        }
    }
}
