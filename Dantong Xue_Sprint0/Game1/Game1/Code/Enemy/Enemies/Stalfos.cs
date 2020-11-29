using Game1.Code.Audio.Sounds;
using Game1.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
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

        private int hp = 8;
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

        public Stalfos(Vector2 location, List<Rectangle> blockList)
        {
            Texture = EnemyTextureStorage.GetStalfosSpriteSheet();
            Rnd = new Random();
            TotalFrames = 2;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Location = location;
            Direction = Rnd.Next(3);
            CollisionRectangle = new Rectangle((int)(Location.X), (int)(Location.Y), 16 * scale, 16 * scale);
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
            // Do Nothing.
        }

        public void UpdateEnemy(Game1 game)
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

            HandleBlockCollision();

            UpdateCanTurn();

            if (CanTurn)
            {
                UpdateDirection();
            }

            if (!IsFreezed)
            {
                UpdateLocation();
            }
            else 
            {
                IsFreezed = false;
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

            CollisionRectangle = new Rectangle((int)(Location.X), (int)(Location.Y), 16 * scale, 16 * scale);
        }

        private void HandleBlockCollision() {
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

        void IEnemy.Freeze()
        {
            IsFreezed = true;
        }
    }
}
