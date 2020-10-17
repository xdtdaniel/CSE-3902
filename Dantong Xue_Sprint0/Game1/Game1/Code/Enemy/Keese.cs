using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Game1
{
    class Keese : IEnemy
    {
        private Texture2D Texture;
        private int Columns;
        private int Rows = 1;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location;
        private int MovingState = 0;
        private int Direction;
        private int StateTimer = 0;
        private int FrameRateModifier = 0;
        private double Velocity = 0;
        private double MaxVelocity = 5;
        private Random Rnd;

        // Test code for sprint 3 rectangle
        private Rectangle CollisionRectangle;
        private Pen blackPen = new Pen(System.Drawing.Color.Black, 5); 

        private int scale = 3;

        public Keese()
        {
            Texture = EnemyTextureStorage.GetKeeseSpriteSheet();
            TotalFrames = 2;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Location = new Vector2(400, 200);
            Rnd = new Random();
            Direction = Rnd.Next(7);

            // Test code for sprint 3 rectangle
            CollisionRectangle = new Rectangle((int)Location.X, (int)(Location.Y + 4 * scale), 16 * scale, 10 * scale);
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

            UpdateDirection();

            UpdateMovingState();

            UpdateLocation();

            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
            }
        }

        private void UpdateMovingState()
        {
            switch (MovingState)
            {
                case 0:
                    Velocity = 0;
                    if (Rnd.Next(50) == 1)
                    {
                        MovingState = 1;
                    }
                    break;
                case 1:
                    if (StateTimer < 200)
                    {
                        Velocity += (MaxVelocity / 200.0);
                        StateTimer++;
                    }
                    else
                    {
                        MovingState = 2;
                        StateTimer = 0;
                    }
                    if (FrameRateModifier < 10 - Velocity * 1.5)
                    {
                        FrameRateModifier++;
                    }
                    else
                    {
                        CurrentFrame++;
                        FrameRateModifier = 0;
                    }
                    break;
                case 2:
                    Velocity = MaxVelocity;
                    if (StateTimer < 40)
                    {
                        StateTimer++;
                    }
                    else
                    {
                        if (Rnd.Next(20) == 3)
                        {
                            MovingState = 3;
                        }
                        StateTimer = 0;
                    }
                    if (FrameRateModifier < 2)
                    {
                        FrameRateModifier++;
                    }
                    else
                    {
                        CurrentFrame++;
                        FrameRateModifier = 0;
                    }
                    break;
                case 3:
                    if (StateTimer < 200)
                    {
                        Velocity -= (MaxVelocity / 200.0);
                        StateTimer++;
                    }
                    else
                    {
                        MovingState = 0;
                        StateTimer = 0;
                    }
                    if (FrameRateModifier < 10 - Velocity * 1.5)
                    {
                        FrameRateModifier++;
                    }
                    else
                    {
                        CurrentFrame++;
                        FrameRateModifier = 0;
                    }
                    break;
            }
        }

        private void UpdateDirection()
        {
            if (IsOutsideBound())
            {
                switch (Direction)
                {
                    case 0:
                        Direction = 4;
                        break;
                    case 1:
                        Direction = 5;
                        break;
                    case 2:
                        Direction = 6;
                        break;
                    case 3:
                        Direction = 7;
                        break;
                    case 4:
                        Direction = 0;
                        break;
                    case 5:
                        Direction = 1;
                        break;
                    case 6:
                        Direction = 2;
                        break;
                    case 7:
                        Direction = 3;
                        break;
                }
            }
            else
            {
                int i = Rnd.Next(150);
                if (i == 1)
                {
                    Direction--;
                    if (Direction < 0)
                    {
                        Direction = 7;
                    }
                }
                else if (i == 2)
                {
                    Direction++;
                    if (Direction > 7)
                    {
                        Direction = 0;
                    }
                }
            }
        }

        private Boolean IsOutsideBound()
        {
            Boolean outside = false;
            if (Location.X <= 32 * scale || Location.Y <= 32 * scale || Location.Y >= 144 * scale || Location.X <= 192 * scale)
            {
                outside = true;
            }
            return outside;
        }

        private void UpdateLocation()
        {
            float x = Location.X;
            float y = Location.Y;
            float sin45 = (float)(Velocity * 0.7071067812);

            if (Direction == 0)
            {
                y -= (float)Velocity;
            }
            else if (Direction == 1)
            {
                x = x + sin45;
                y = y - sin45;
            }
            else if (Direction == 2)
            {
                x += (float)Velocity;
            }
            else if (Direction == 3)
            {
                x = x + sin45;
                y = y + sin45;
            }
            else if (Direction == 4)
            {
                y += (float)Velocity;
            }
            else if (Direction == 5)
            {
                x = x - sin45;
                y = y + sin45;
            }
            else if (Direction == 6)
            {
                x -= (float)Velocity;
            }
            else if (Direction == 7)
            {
                x = x - sin45;
                y = y - sin45;
            }

            Location = new Vector2(x, y);

            // Test code for sprint 3 rectangle
            CollisionRectangle = new Rectangle((int)Location.X, (int)(Location.Y + 4 * scale), 16 * scale, 10 * scale);
        }

        // Test code for sprint 3 rectangle
        public Rectangle GetRectangle() 
        {
            return CollisionRectangle;
        }
    }
}
