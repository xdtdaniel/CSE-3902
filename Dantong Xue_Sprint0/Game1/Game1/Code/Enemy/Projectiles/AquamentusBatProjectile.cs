﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Enemy
{
    class AquamentusBatProjectile : IProjectile
    {
        private Texture2D Texture;
        private int Direction;
        private Vector2 Location;
        private int Rows = 1;
        private int Columns;
        private int TotalFrames;
        private int CurrentFrame;
        private double Velocity;
        private bool IsOnScreen;
        private readonly double Sin15 = 0.2588190451;
        private readonly double Cos15 = 0.96592582628;
        private int scale = 3;

        private Rectangle CollisionRectangle;

        public AquamentusBatProjectile()
        {
            Texture = EnemyTextureStorage.GetAquamentusProjectileSpriteSheet();
            TotalFrames = 3;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Velocity = 3.0;
            CollisionRectangle = new Rectangle((int)(Location.X + 4 * scale), (int)(Location.Y + 3 * scale), 8 * scale, 10 * scale);
        }

        public void DrawProjectile(SpriteBatch spriteBatch, Vector2 offset)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)(offset.X + Location.X - 4 * scale), (int)(offset.Y + Location.Y - 56 * scale), width * scale, height * scale);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }


        public void UpdateProjectile()
        {
            CurrentFrame++;
            if (CurrentFrame > TotalFrames)
            {
                CurrentFrame = 0;
            }

            UpdateLocation();

            if (HitEdge())
            {
                IsOnScreen = false;
            }
        }

        public bool GetIsOnScreen()
        {
            return IsOnScreen;
        }

        public void SetIsOnScreen(bool boolean)
        {
            IsOnScreen = boolean;
        }

        public void SetDirection(int direction)
        {
            Direction = direction;
        }

        public void SetLocation(Vector2 location)
        {
            Location = location;
        }

        private void UpdateLocation()
        {
            float x = Location.X;
            float y = Location.Y;

            if (Direction == 0)
            {
                x -= (float)(Velocity * Cos15);
                y -= (float)(Velocity * Sin15);
            }
            else if (Direction == 1)
            {
                x -= (float)Velocity;
            }
            else if (Direction == 2)
            {
                x -= (float)(Velocity * Cos15);
                y += (float)(Velocity * Sin15);
            }

            Location = new Vector2(x, y);

            CollisionRectangle = new Rectangle((int)(Location.X + 4 * scale), (int)(Location.Y + 3 * scale), 8 * scale, 10 * scale);
        }

        private bool HitEdge()
        {
            Boolean outside = false;
            if (Location.X <= 48 || Location.Y <= 48 + 56 * scale || Location.Y >= 144 * scale * 1.5 + 56 * scale)
            {
                outside = true;
            }
            return outside;
        }

        Rectangle IProjectile.GetRectangle()
        {
            return CollisionRectangle;
        }

        void IProjectile.BounceBack()
        {
            // Do nothing for now.
        }
    }
}

