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
        private int Velocity = 1;
        private bool CanTurn = true;
        private int FrameBound;

        public int hp = 3;
        private int DamageTimer = 0;
        private int FlashRateModifier = 0;

        private int FireTimer;
        private bool CanFire;
        private IProjectile Projectile;

        private Rectangle CollisionRectangle;
        private int scale = 3;
        private List<IProjectile> ProjectileList;
        private List<Rectangle> BlockList;
        private bool UpCollide = false;
        private bool DownCollide = false;
        private bool LeftCollide = false;
        private bool RightCollide = false;
        public Goriya(Vector2 location, List<Rectangle> blockList)
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

            CollisionRectangle = new Rectangle((int)Location.X + 1 * scale, (int)Location.Y, 14 * scale, 16 * scale);
            ProjectileList = new List<IProjectile>();
            BlockList = blockList;
        }

        public void DrawEnemy(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, width * scale, height * scale);

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

            if (Projectile.GetIsOnScreen())
            {
                Projectile.DrawProjectile(spriteBatch);
            }
        }

        public void FireProjectile()
        {
            Velocity = 0;
            Projectile.SetIsOnScreen(true);
            Projectile.SetLocation(Location);
            Projectile.SetDirection(Direction);
            FireTimer = 0;
            CanFire = false;

            ProjectileList.Clear();
            ProjectileList.Add(Projectile);
        }

        public void UpdateEnemy(Game1 game)
        {
            if (FireTimer > Rnd.Next(180, 200) || Projectile.GetIsOnScreen())
            {
                if (CanFire)
                {
                    FireProjectile();
                }
                Projectile.UpdateProjectile();

                ProjectileList.Clear();
                ProjectileList.Add(Projectile);
            }
            else
            {
                Velocity = 1;

                HandleBlockCollision();
                UpdateCanTurn();

                if (CanTurn)
                {
                    UpdateDirection();
                    FrameBound = UpdateFacing();
                }

                FireTimer++;

                CanFire = true;
            }

            if (DamageTimer > 0)
            {
                DamageTimer--;
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

            UpCollide = false;
            DownCollide = false;
            LeftCollide = false;
            RightCollide = false;

            CanTurnTimer = 0;
        }

        private int UpBlocked()
        {
            if (Location.Y <= 32 * scale + 56 * scale || UpCollide)
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
            if (Location.X >= 208 * scale || RightCollide)
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
            if (Location.Y >= 128 * scale + 56 * scale || DownCollide)
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
            if (Location.X <= 32 * scale || LeftCollide)
            {
                return 0;
            }
            else
            {
                return 1;
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

            CollisionRectangle = new Rectangle((int)Location.X + 1 * 5, (int)Location.Y, 14 * scale, 16 * scale);
        }

        public void TakeDamage(int damageAmount)
        {
            if (DamageTimer == 0)
            {
                hp -= damageAmount;
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
    }
}
