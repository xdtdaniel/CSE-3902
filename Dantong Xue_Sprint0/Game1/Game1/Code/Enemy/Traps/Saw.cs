using Game1.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Enemy
{
    class Saw : IEnemy
    {
        private Texture2D Texture;
        private int Columns;
        private int Rows = 1;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location { get; set; }
        private int MovingState = 0;
        private int Direction;
        private bool Clockwise;
        private int FrameRateModifier = 0;
        private double Velocity = 0;
        private double MaxVelocity = 25;
        private Random Rnd;
        private int hp = 8;

        private int vibrateCounter = 0;
        private readonly int vibrateAmount = 2;

        //private int DamageTimer = 0;

        private Rectangle CollisionRectangle;
        private int scale = 3;
        private List<IProjectile> ProjectileList = new List<IProjectile>();

        private bool IsFreezed = false;

        public Saw(Vector2 location)
        {
            Texture = EnemyTextureStorage.GetSawSpriteSheet();
            TotalFrames = 2;
            Columns = TotalFrames;
            CurrentFrame = 1;
            Location = location;
            Rnd = new Random();
            Direction = 0;
            Clockwise = false;
            CollisionRectangle = new Rectangle((int)(Location.X + 2 * scale), (int)(Location.Y + 2 * scale), 28 * scale, 28 * scale);
        }

        public void DrawEnemy(SpriteBatch spriteBatch, Vector2 offset)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)(offset.X + Location.X - 6), (int)(offset.Y + Location.Y - 56 * scale), (width + 4) * scale, height * scale);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void UpdateEnemy(Game1 game)
        {
            if (!IsFreezed)
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

                if (MovingState == 0) 
                {
                    Velocity = 0;
                    if (Rnd.Next(50) == 1)
                    {
                        MovingState = 1;

                        if (Clockwise)
                        {
                            Clockwise = false;
                        }
                        else 
                        {
                            Clockwise = true;
                        }

                        switch (Direction)
                        {
                            case 0:
                                Direction = 2;
                                break;
                            case 1:
                                Direction = 3;
                                break;
                            case 2:
                                Direction = 0;
                                break;
                            case 3:
                                Direction = 1;
                                break;
                        }
                    }
                }

                if (MovingState == 1) 
                {
                    Velocity = MaxVelocity;
                    MovingState = 2;
                }

                if (MovingState == 2) 
                {
                    if (Velocity > 0)
                    {
                        Velocity -= 0.1;
                        
                    }
                    else 
                    {                     
                        Velocity = 0;
                        MovingState = 0;
                    }
                }

                if (HitEdge()) 
                {
                    UpdateDirection();
                }

                UpdateLocation();
            }

            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
            }
        }

        private void UpdateDirection()
        {
            if (Clockwise)
            {
                if (Direction == 0)
                {
                    Direction = 1;
                }
                else if (Direction == 1)
                {
                    Direction = 2;
                }
                else if (Direction == 2)
                {
                    Direction = 3;
                }
                else if (Direction == 3)
                {
                    Direction = 0;
                }
            }
            else 
            {
                if (Direction == 0)
                {
                    Direction = 3;
                }
                else if (Direction == 1)
                {
                    Direction = 0;
                }
                else if (Direction == 2)
                {
                    Direction = 1;
                }
                else if (Direction == 3)
                {
                    Direction = 2;
                }
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
            Vibrate();

            CollisionRectangle = new Rectangle((int)(Location.X + 2 * scale), (int)(Location.Y + 2 * scale), 28 * scale, 28 * scale);
        }

        private void Vibrate() 
        {
            float x = Location.X;
            float y = Location.Y;

            if (vibrateCounter < 4)
            {
                if (vibrateCounter == 0)
                {
                    y -= vibrateAmount;
                }
                else if (vibrateCounter == 1)
                {
                    x += vibrateAmount;
                }
                else if (vibrateCounter == 2)
                {
                    y += vibrateAmount;
                }
                else if (vibrateCounter == 3)
                {
                    x -= vibrateAmount;
                }
                vibrateCounter++;
            }
            else
            {
                vibrateCounter = 0;
            }

            Location = new Vector2(x, y);
        }

        private bool HitEdge()
        {
            Boolean outside = false;

            if ((Direction == 0 && Location.Y < 32 * scale + 56 * scale))
            {
                Location = new Vector2(Location.X, (32 + 56) * scale);
                outside = true;
            } 
            else if ((Direction == 2 && Location.Y > 112 * scale + 56 * scale)) 
            {
                Location = new Vector2(Location.X, (112 + 56) * scale);
                outside = true;
            }
            else if ((Direction == 1 && Location.X > 192 * scale))
            {
                Location = new Vector2(192 * scale, Location.Y);
                outside = true;
            }
            else if ((Direction == 3 && Location.X < 32 * scale))
            {
                Location = new Vector2(32 * scale, Location.Y);
                outside = true;
            }

            return outside;
        }

        public void FireProjectile()
        {
            // Do nothing.
        }

        public void Freeze()
        {
            IsFreezed = true;
        }

        public int GetHP()
        {
            return hp;
        }

        public List<IProjectile> GetProjectile()
        {
            return ProjectileList;
        }

        public Rectangle GetRectangle()
        {
            return CollisionRectangle;
        }

        public void TakeDamage(int damageAmount)
        {
            // Do nothing.
        }
    }
}
