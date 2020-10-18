using Game1.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Stalfos : IEnemy
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
        private int Velocity = 1;
        private bool CanTurn = false;

        // Test code for sprint 3 rectangle
        private Rectangle CollisionRectangle;
        private int scale = 3;
        private List<IProjectile> ProjectileList = new List<IProjectile>();

        public Stalfos(Vector2 location)
        {
            Texture = EnemyTextureStorage.GetStalfosSpriteSheet();
            Rnd = new Random();
            TotalFrames = 2;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Location = location;
            Direction = Rnd.Next(3);

            // Test code for sprint 3 rectangle
            CollisionRectangle = new Rectangle((int)Location.X, (int)Location.Y, 16 * scale, 16 * scale);
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
            // Do Nothing.
        }

        public void UpdateEnemy()
        {
            if (FrameRateModifier < 20)
            {
                FrameRateModifier++;
            }
            else
            {
                CurrentFrame++;
                FrameRateModifier = 0;
            }

            UpdateCanTurn();

            if (CanTurn)
            {
                UpdateDirection();
            }

            UpdateLocation();

            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
            }
        }

        private void UpdateCanTurn()
        {
            if ((UpBlocked() == 0 && Direction == 0) || (RightBlocked() == 0 && Direction == 1) || (DownBlocked() == 0 && Direction == 2) || (LeftBlocked() == 0 && Direction == 3))
            {
                CanTurn = true;
                CanTurnTimer = 0;
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
            if (Location.X >= 208 * scale)
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

            if (CanTurnTimer < 48)
            {
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
          
            Location = new Vector2(x, y);

            // Test code for sprint 3 rectangle
            CollisionRectangle = new Rectangle((int)Location.X, (int)Location.Y, 16 * scale, 16 * scale);
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
