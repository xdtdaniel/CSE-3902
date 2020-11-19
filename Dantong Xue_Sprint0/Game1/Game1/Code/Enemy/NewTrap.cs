using Game1.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Enemy
{
    class NewTrap : IEnemy
    {
        private Texture2D Texture;
        private int Columns;
        private int Rows = 1;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location { get; set; }
        private int MovingState;
        private int Direction;
        private double Velocity;
        private Vector2 OriginalLocation;

        private Rectangle CollisionRectangle;
        private int scale = 3;
        private List<IProjectile> ProjectileList = new List<IProjectile>();
        private int hp = 100;
        private bool CanChangeDirection;

        private bool IsFreezed = false;

        public NewTrap(Vector2 location)
        {
            Texture = EnemyTextureStorage.GetTrapSpriteSheet();
            TotalFrames = 1;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Location = location;
            OriginalLocation = location;
            MovingState = 0;
            CanChangeDirection = true;
            CollisionRectangle = new Rectangle((int)(Location.X), (int)(Location.Y), 16 * scale, 16 * scale);
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
            // To do.
        }

        private bool HitEdge()
        {
            Boolean outside = false;
            if (Location.Y > 72 * scale + 56 * scale || Location.X > 112 * scale)
            {
                outside = true;
            }
            return outside;
        }

        private void UpdateLocation()
        {
            float x = Location.X;
            float y = Location.Y;

            if (Direction == 0)
            {
                y -= (float)Velocity;
            }
            else if (Direction == 2)
            {
                y += (float)Velocity;
            }

            Location = new Vector2(x, y);

            CollisionRectangle = new Rectangle((int)(Location.X), (int)(Location.Y), 16 * scale, 16 * scale);
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

        public void Freeze()
        {
            IsFreezed = true;
        }
    }
}
