﻿using Game1.Enemy;
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
        private Vector2 Location { get; set; }
        private int MovingState = 0;
        private int Direction;
        private int StateTimer = 0;
        private int FrameRateModifier = 0;
        private double Velocity = 0;
        private double MaxVelocity = 3;
        private Random Rnd;
        private int hp = 4;

        private int DamageTimer = 0;
        private int FlashRateModifier = 0;

        private Rectangle CollisionRectangle;
        private int scale = 3;
        private List<IProjectile> ProjectileList = new List<IProjectile>();

        private bool IsFreezed = false;
        private int freezeTimer = 0;
        public Keese(Vector2 location)
        {
            Texture = EnemyTextureStorage.GetKeeseSpriteSheet();
            TotalFrames = 2;
            Columns = TotalFrames;
            CurrentFrame = 1;
            Location = location;
            Rnd = new Random();
            Direction = Rnd.Next(7);
            CollisionRectangle = new Rectangle((int)(Location.X), (int)(Location.Y + 4 * scale), 16 * scale, 10 * scale);
        }

        public void DrawEnemy(SpriteBatch spriteBatch, Vector2 offset)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)(offset.X + Location.X - scale), (int)(offset.Y + Location.Y - scale - 56 * scale), width * scale, height * scale);

            if (DamageTimer > 0)
            {
                if (FlashRateModifier >= 3)
                {
                    spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                    FlashRateModifier = 0;
                }
                else
                {
                    FlashRateModifier++;
                }
            }
            else
            {
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public void FireProjectile()
        {
            // Do nothing. 
        }

        public void UpdateEnemy(Game1 game)
        {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            Random rnd = new Random();
#pragma warning restore IDE0059 // Unnecessary assignment of a value

            if (!IsFreezed)
            {
                UpdateDirection();
                UpdateMovingState();
                UpdateLocation();
            }
            else if (freezeTimer == 0)
            {
                IsFreezed = false;
            }

            if (freezeTimer > 0)
            {
                freezeTimer--;
            }

            if (DamageTimer > 0) 
            {
                DamageTimer--;
            }

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
                        if (Rnd.Next(25) == 3)
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

            if (Location.X <= (32 * scale) || Location.Y <= ((32 - 4) * scale + 56 * scale) || Location.Y >= (128 * scale + 56 * scale) || Location.X >= (208 * scale))
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
                x += sin45;
                y -= sin45;
            }
            else if (Direction == 2)
            {
                x += (float)Velocity;
            }
            else if (Direction == 3)
            {
                x += sin45;
                y += sin45;
            }
            else if (Direction == 4)
            {
                y += (float)Velocity;
            }
            else if (Direction == 5)
            {
                x -= sin45;
                y += sin45;
            }
            else if (Direction == 6)
            {
                x -= (float)Velocity;
            }
            else if (Direction == 7)
            {
                x -= sin45;
                y -= sin45;
            }

            Location = new Vector2(x, y);

            CollisionRectangle = new Rectangle((int)(Location.X), (int)(Location.Y + 4 * scale), 16 * scale, 10 * scale);
        }

        public Rectangle GetRectangle() 
        {
            return CollisionRectangle;
        }

        public void TakeDamage(int damageAmount)
        {
            hp -= damageAmount;
            if (DamageTimer == 0)
            {
                DamageTimer = 50;
            }
        }


        List<IProjectile> IEnemy.GetProjectile()
        {
            return ProjectileList;
        }

        int IEnemy.GetHP()
        {
            return hp;
        }

        void IEnemy.Freeze(int timer)
        {
            freezeTimer = timer;
            IsFreezed = true;
        }
    }
}
