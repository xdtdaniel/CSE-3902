using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Text;

namespace Game1.Enemy
{
    class Aquamentus : IEnemy
    {
        private Texture2D Texture;
        private int Columns;
        private int Rows = 1;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location;
        private int Direction = 0;
        private int FrameRateModifier = 0;
        private Random Rnd;
        private int Velocity = 1;       
        private int FiringStateTimer = 0;
        private int FireTimer;
        private bool Firing;
        private bool CanFire = true;
        private IProjectile Projectile0;
        private IProjectile Projectile1;
        private IProjectile Projectile2;

        // Test code for sprint 3 rectangle
        private Rectangle CollisionRectangle;

        public Aquamentus() 
        {
            Texture = EnemyTextureStorage.GetAquamentusSpriteSheet();
            Rnd = new Random();
            TotalFrames = 4;
            CurrentFrame = 2;
            Columns = TotalFrames;
            Location = new Vector2(550, 150);
            Direction = 0;
            Firing = false;
            FireTimer = 0;
            Projectile0 = new AquamentusProjectile();
            Projectile1 = new AquamentusProjectile();
            Projectile2 = new AquamentusProjectile();
            Projectile0.SetDirection(0);
            Projectile1.SetDirection(1);
            Projectile2.SetDirection(2);

            // Test code for sprint 3 rectangle
            CollisionRectangle = new Rectangle((int)Location.X, (int)Location.Y, 24 * 5, 32 * 5);
        }

        public void DrawEnemy(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height); 
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, width * 5, height * 5);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            if (Projectile0.GetIsOnScreen()) 
            {
                Projectile0.DrawProjectile(spriteBatch);
            }

            if (Projectile1.GetIsOnScreen())
            {
                Projectile1.DrawProjectile(spriteBatch);
            }

            if (Projectile2.GetIsOnScreen())
            {
                Projectile2.DrawProjectile(spriteBatch);
            }
        }

        public void FireProjectile()
        {
            if (CanFire) 
            {
                Projectile0.SetLocation(new Vector2(Location.X, Location.Y - 60));
                Projectile1.SetLocation(Location);
                Projectile2.SetLocation(new Vector2(Location.X, Location.Y + 60));
                CanFire = false;
            }
        }

        public void UpdateEnemy(Game game)
        {
            if (FireTimer < (Rnd.Next(7, 10) * 24))
            {
                FireTimer++;
            }
            else 
            {
                Firing = true;
                FireTimer = 0;
                CurrentFrame = 0;
            }

            UpdateFireState();

            if (FrameRateModifier < 11)
            {
                FrameRateModifier++;
            }
            else 
            {
                CurrentFrame++;
                FrameRateModifier = 0;
            }

            if (OutsideMovingRange(game) == true) {
                if (Direction == 0) 
                {
                    Direction = 1;
                }
                else 
                {
                    Direction = 0;
                }
            }

            UpdateLocation();

            FireProjectile();

            if (Projectile0.GetIsOnScreen())
            {
                Projectile0.UpdateProjectile(game);
            }
            if (Projectile1.GetIsOnScreen())
            {
                Projectile1.UpdateProjectile(game);
            }
            if (Projectile2.GetIsOnScreen())
            {
                Projectile2.UpdateProjectile(game);
            }
                                
            if (Firing)
            {
                if (CurrentFrame > 1)
                {
                    CurrentFrame = 0;
                } 
            }
            else 
            {
                if (CurrentFrame > 3)
                {
                    CurrentFrame = 2;
                }
            }   
        }

        private void UpdateFireState() 
        {
            if (Firing) 
            {
                if (FiringStateTimer < 72)
                {
                    FiringStateTimer++;
                }
                else
                {
                    Firing = false;
                    CanFire = true;
                    FiringStateTimer = 0;
                    Projectile0.SetIsOnScreen();
                    Projectile1.SetIsOnScreen();
                    Projectile2.SetIsOnScreen();
                }

                FireTimer = 0;
            }
        }

        private bool OutsideMovingRange(Game game)
        {
            Boolean outside = false;
            if (Location.X <= 450 || Location.X >= game.Window.ClientBounds.Width - 160)
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
                x -= Velocity;
            }
            else if (Direction == 1)
            {
                x += Velocity;
            }

            Location = new Vector2(x, y);

            // Test code for sprint 3 rectangle
            CollisionRectangle = new Rectangle((int)Location.X, (int)Location.Y, 24 * 5, 32 * 5);
        }

        Rectangle IEnemy.GetRectangle()
        {
            return CollisionRectangle;
        }
    }
}
