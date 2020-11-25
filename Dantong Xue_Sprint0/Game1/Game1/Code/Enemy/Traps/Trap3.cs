using Game1.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Game1.Code.LoadFile;

namespace Game1
{
    class Trap3 : IEnemy
    {
        // This class needs further modifications.

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

        public Trap3(Vector2 location)
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
            if (!IsFreezed)
            {
                if (PlayerInAttackingRange(game) && MovingState == 0)
                {
                    MovingState = 1;
                    Velocity = 5.0;
                    CanChangeDirection = false;
                }

                else if (HitEdge() && MovingState == 1)
                {
                    MovingState = 2;
                    Velocity = -1.0;

                }

                else if (Location == OriginalLocation && MovingState == 2)
                {
                    MovingState = 0;
                    Velocity = 0;
                    CanChangeDirection = true;
                }

                UpdateLocation();
            }
            else
            {
                IsFreezed = false;
            }
        }

        private bool PlayerInAttackingRange(Game1 game)
        {
            Rectangle playerRectangle = new Rectangle((int)(game.link.GetRectangle().X - LoadAll.Instance.startPos.X), (int)(game.link.GetRectangle().Y - LoadAll.Instance.startPos.Y + 56 * scale), game.link.GetRectangle().Width, game.link.GetRectangle().Height);

            if (playerRectangle.X >= 200 * scale && game.link.GetRectangle().X <= 202 * scale) 
            {
                if (CanChangeDirection) 
                {
                    Direction = 0;
                }               
                return true;
            } 
            else if (playerRectangle.Y >= 116 * scale + 56 * scale) 
            {
                if (CanChangeDirection)
                {
                    Direction = 3;
                }
                return true;
            }
            else 
            {
                return false;
            }
        }

        private bool HitEdge()
        {
            Boolean outside = false;
            if (Location.Y < 88 * scale + 56 * scale || Location.X < 128 * scale)
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
            else if (Direction == 3)
            {
                x -= (float)Velocity;
            }

            Location = new Vector2(x, y);

            CollisionRectangle = new Rectangle((int)(Location.X), (int)(Location.Y), 16 * scale, 16 * scale);
        }

        public void FireProjectile()
        {
            // Do nothing.
        }

        public void TakeDamage(int damageAmount)
        {
            // Do nothing.
        }
        public List<IProjectile> GetProjectile()
        {
            return ProjectileList;
        }

        public Rectangle GetRectangle()
        {
            return CollisionRectangle;
        }

        int IEnemy.GetHP()
        {
            return hp;
        }

        void IEnemy.Freeze()
        {
            IsFreezed = true;
        }
    }
}
