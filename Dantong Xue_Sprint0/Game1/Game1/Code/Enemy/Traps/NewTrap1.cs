﻿using Game1.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Enemy
{
    class NewTrap1 : IEnemy
    {
        private Texture2D Texture;
        private int Columns;
        private int Rows = 1;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location { get; set; }
        private int Direction;
        private double Velocity = 1.5;

        private Rectangle CollisionRectangle;
        private int scale = 3;
        private List<IProjectile> ProjectileList = new List<IProjectile>();
        private int hp = 100;

        private bool IsFreezed = false;
        private int freezeTimer = 0;
        public NewTrap1(Vector2 location)
        {
            Texture = EnemyTextureStorage.GetNewTrap1SpriteSheet();
            TotalFrames = 1;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Location = location;
            Direction = 3;
            CollisionRectangle = new Rectangle((int)(Location.X + 2 * scale), (int)(Location.Y + 2 * scale), 12 * scale, 12 * scale);
        }

        public void DrawEnemy(SpriteBatch spriteBatch, Vector2 offset)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)(offset.X + Location.X), (int)(offset.Y + Location.Y - 56 * scale), width * scale, height * scale);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void UpdateEnemy(Game1 game)
        {
            if (!IsFreezed) 
            {
                if (HitEdge())
                {
                    ChangeDirection();
                }

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
        }

        private void ChangeDirection() 
        {
            if (Direction == 1) 
            {
                Direction = 3;
            } 
            else if (Direction == 3) 
            {
                Direction = 1;
            }
        }

        private bool HitEdge()
        {
            Boolean outside = false;
            if (Location.X > 176 * scale || Location.X < 64 * scale)
            {
                outside = true;
            }
            return outside;
        }

        private void UpdateLocation()
        {
            float x = Location.X;
            float y = Location.Y;

            if (Direction == 3)
            {
                x -= (float)Velocity;
            }
            else if (Direction == 1)
            {
                x += (float)Velocity;
            }

            Location = new Vector2(x, y);

            CollisionRectangle = new Rectangle((int)(Location.X + 2 * scale), (int)(Location.Y + 2 * scale), 12 * scale, 12 * scale);
        }

        public void FireProjectile()
        {
            // Do nothing. 
        }

        public Rectangle GetRectangle()
        {
            return CollisionRectangle;
        }

        public List<IProjectile> GetProjectile()
        {
            return ProjectileList;
        }

        public void TakeDamage(int damageAmount)
        {
            // Do nothing. 
        }

        public int GetHP()
        {
            return hp;
        }

        public void Freeze(int timer)
        {
            freezeTimer = timer;
            IsFreezed = true;
        }
    }
}
