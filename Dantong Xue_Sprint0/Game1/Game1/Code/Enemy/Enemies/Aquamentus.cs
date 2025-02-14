﻿using Game1.Code.Audio.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
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
        private Vector2 Location { get; set; }
        private int Direction = 0;
        private int FrameRateModifier = 0;
        private Random Rnd;
        private double Velocity = 0.5;       
        private int FiringStateTimer = 0;
        private int FireTimer;
        private bool Firing;
        private bool CanFire = true;
        private IProjectile Projectile0;
        private IProjectile Projectile1;
        private IProjectile Projectile2;
        private IProjectile Projectile3;
        private IProjectile Projectile4;

        private int hp = 40;
        private int DamageTimer = 0;
        private int FlashRateModifier = 0;

        private Rectangle CollisionRectangle;
        private double scale = 3;
        private List<IProjectile> ProjectileList;

        private ISounds BossScream = new BossScream();
        private bool BossScreamPlayed;

        private bool IsFreezed = false;
        private int freezeTimer = 0;
        public Aquamentus(Vector2 location) 
        {
            Texture = EnemyTextureStorage.GetAquamentusSpriteSheet();
            Rnd = new Random();
            TotalFrames = 4;
            CurrentFrame = 2;
            Columns = TotalFrames;
            Location = location;
            Direction = 0;
            Firing = false;
            FireTimer = 0;
            Projectile0 = new AquamentusProjectile();
            Projectile1 = new AquamentusProjectile();
            Projectile2 = new AquamentusProjectile();
            Projectile3 = new AquamentusProjectile();
            Projectile4 = new AquamentusProjectile();
            Projectile0.SetDirection(0);
            Projectile1.SetDirection(1);
            Projectile2.SetDirection(2);
            Projectile3.SetDirection(3);
            Projectile4.SetDirection(4);
            CollisionRectangle = new Rectangle((int)(Location.X * scale), (int)(Location.Y * scale), 24, 32 );
            ProjectileList = new List<IProjectile>();
            BossScreamPlayed = false;
        }

        public void DrawEnemy(SpriteBatch spriteBatch, Vector2 offset)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height); 
            Rectangle destinationRectangle = new Rectangle((int)(offset.X + Location.X), (int)(offset.Y + Location.Y - 56 * scale), (int)(width * scale), (int)(height * scale));
            
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

            if (Projectile0.GetIsOnScreen()) 
            {
                Projectile0.DrawProjectile(spriteBatch, offset);
            }

            if (Projectile1.GetIsOnScreen())
            {
                Projectile1.DrawProjectile(spriteBatch, offset);
            }

            if (Projectile2.GetIsOnScreen())
            {
                Projectile2.DrawProjectile(spriteBatch, offset);
            }

            if (Projectile3.GetIsOnScreen())
            {
                Projectile3.DrawProjectile(spriteBatch, offset);
            }

            if (Projectile4.GetIsOnScreen())
            {
                Projectile4.DrawProjectile(spriteBatch, offset);
            }
        }

        public void FireProjectile()
        {
            if (CanFire) 
            {
                Projectile3.SetLocation(new Vector2(Location.X, (float)(Location.Y - 12 * scale)));
                Projectile0.SetLocation(new Vector2(Location.X, (float)(Location.Y - 6 * scale)));
                Projectile1.SetLocation(Location);
                Projectile2.SetLocation(new Vector2(Location.X, (float)(Location.Y + 6 * scale)));
                Projectile4.SetLocation(new Vector2(Location.X, (float)(Location.Y + 12 * scale)));

                ProjectileList.Clear();
                ProjectileList.Add(Projectile0);
                ProjectileList.Add(Projectile1);
                ProjectileList.Add(Projectile2);
                ProjectileList.Add(Projectile3);
                ProjectileList.Add(Projectile4);

                CanFire = false;
            }
        }

        public void UpdateEnemy(Game1 game)
        {
            if (BossScreamPlayed == false) {
                BossScream.Play();
                BossScreamPlayed = true;
            }

            if (!IsFreezed)
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

                if (OutsideMovingRange() == true)
                {
                    if (Direction == 0)
                    {
                        Direction = 1;
                    }
                    else
                    {
                        Direction = 0;
                    }
                }

                if (DamageTimer > 0)
                {
                    DamageTimer--;
                }

                UpdateLocation();

                FireProjectile();
            }
            else if (freezeTimer == 0)
            {
                IsFreezed = false;
            }

            if (freezeTimer > 0)
            {
                freezeTimer--;
                freezeTimer--;
            }

            if (Projectile0.GetIsOnScreen())
            {
                Projectile0.UpdateProjectile();
            }
            if (Projectile1.GetIsOnScreen())
            {
                Projectile1.UpdateProjectile();
            }
            if (Projectile2.GetIsOnScreen())
            {
                Projectile2.UpdateProjectile();
            }
            if (Projectile3.GetIsOnScreen())
            {
                Projectile3.UpdateProjectile();
            }
            if (Projectile4.GetIsOnScreen())
            {
                Projectile4.UpdateProjectile();
            }

            ProjectileList.Clear();
            ProjectileList.Add(Projectile0);
            ProjectileList.Add(Projectile1);
            ProjectileList.Add(Projectile2);
            ProjectileList.Add(Projectile3);
            ProjectileList.Add(Projectile4);


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
                    Projectile0.SetIsOnScreen(true);
                    Projectile1.SetIsOnScreen(true);
                    Projectile2.SetIsOnScreen(true);
                    Projectile3.SetIsOnScreen(true);
                    Projectile4.SetIsOnScreen(true);
                }

                FireTimer = 0;
            }
        }

        private bool OutsideMovingRange()
        {
            Boolean outside = false;
            if (Location.X <= 96 * scale * 1.5 || Location.X >= 176 * scale)
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
                x -= (float)Velocity;
            }
            else if (Direction == 1)
            {
                x += (float)Velocity;
            }

            Location = new Vector2(x, y);

            CollisionRectangle = new Rectangle((int)(Location.X), (int)(Location.Y), (int)(24 * scale), (int)(32 * scale));
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

        public List<IProjectile> GetProjectile() 
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
