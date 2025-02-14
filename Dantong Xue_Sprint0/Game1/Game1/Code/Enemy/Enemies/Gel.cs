﻿using Game1.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

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
        public int hp = 4;

        private int DamageTimer = 0;
        private int FlashRateModifier = 0;

        private Rectangle CollisionRectangle;
        private int scale = 3;
        private List<IProjectile> ProjectileList = new List<IProjectile>();
        private List<Rectangle> BlockList;
        private bool UpCollide = false;
        private bool DownCollide = false;
        private bool LeftCollide = false;
        private bool RightCollide = false;

        private bool IsFreezed = false;
        private int freezeTimer = 0;
        public Gel(Vector2 location, List<Rectangle> blockList)
        {
            Texture = EnemyTextureStorage.GetGelSpriteSheet();
            TotalFrames = 2;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Location = location;

            CollisionRectangle = new Rectangle((int)(Location.X + 1 * scale), (int)(Location.Y + 1 * scale), 8 * scale, 8 * scale);
            BlockList = blockList;
        }

        public void DrawEnemy(SpriteBatch spriteBatch, Vector2 offset)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)(offset.X + Location.X), (int)(offset.Y + Location.Y - 56 * scale), width * scale, height * scale);

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
            Random rnd = new Random();

            if (FrameRateModifier == 5)
            {
                CurrentFrame++;
                FrameRateModifier = 0;
            }

            FrameRateModifier++;

            UpdateMovingState(rnd);

            HandleBlockCollision();

            if (!IsFreezed) 
            {
                if (MovingState == 1)
                {
                    if (MoveTimer == 0)
                    {
                        Direction = rnd.Next(4);
                    }
                    Move(Direction);

                    UpCollide = false;
                    DownCollide = false;
                    LeftCollide = false;
                    RightCollide = false;
                }
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

        private void UpdateMovingState(Random random)
        {
            if (StateTimer < 24 )
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

            if (MoveTimer < 16)
            {
                if (direction == 0)
                {
                    y -= 1 * scale;
                    if (Location.Y < 28 * scale + 56 * scale || UpCollide)
                    {
                        y += (6) * scale;
                        MovingState = 0;
                        MoveTimer = 16;
                    }
                }
                else if (direction == 1)
                {
                    x += 1 * scale;
                    if (Location.X > 212 * scale || RightCollide)
                    {
                        x -= (6) * scale;
                        MovingState = 0;
                        MoveTimer = 16;
                    }
                }
                else if (direction == 2)
                {
                    y += 1 * scale;
                    if (Location.Y > 132 * scale + 56 * scale || DownCollide)
                    {
                        y -= (6) * scale;
                        MovingState = 0;
                        MoveTimer = 16;
                    }
                }
                else if (direction == 3)
                {
                    x -= 1 * scale;
                    if (Location.X < 28 * scale || LeftCollide)
                    {
                        x += (6) * scale;
                        MovingState = 0;
                        MoveTimer = 16;
                    }
                }

                Location = new Vector2(x, y);

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

        private void HandleBlockCollision()
        {
            foreach (Rectangle rect in BlockList)
            {
                string collidedSide = CollisionDetection.Instance.isCollided(CollisionRectangle, rect);
                if (collidedSide == "up")
                {
                    UpCollide = true;
                }
                else if (collidedSide == "right")
                {
                    RightCollide = true;
                }
                else if (collidedSide == "down")
                {
                    DownCollide = true;
                }
                else if (collidedSide == "left")
                {
                    LeftCollide = true;
                }
            }
        }

        public void TakeDamage(int damageAmount)
        {
            hp -= damageAmount;
            if (DamageTimer == 0)
            {
                DamageTimer = 50;
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