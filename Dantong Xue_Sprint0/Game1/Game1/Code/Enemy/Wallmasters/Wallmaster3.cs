using Game1.Code.Audio.Sounds;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Enemy
{
    class Wallmaster3 : IEnemy
    {
        private Texture2D Texture;
        private int Columns;
        private int Rows;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location { get; set; }
        private Vector2 OriginalLocation { get; set; }
        private int FrameRateModifier = 0;

        private int hp = 4;     
        private int DamageTimer = 0;
        private int FlashRateModifier = 0;
        private Rectangle CollisionRectangle;
        private int scale = 3;
        private List<IProjectile> ProjectileList = new List<IProjectile>();

        private int MovingStateTimer = 0;
        private int MovingState;
        private int Velocity;
        private int Direction;
        private int Heading;

        public Wallmaster3(Vector2 location)
        {
            Texture = EnemyTextureStorage.GetWallmaster3SpriteSheet();
            TotalFrames = 2;
            Columns = 2;
            Rows = 1;
            CurrentFrame = 0;
            Location = location;
            OriginalLocation = location;
            CollisionRectangle = new Rectangle((int)(Location.X), (int)(Location.Y), 16 * scale, 16 * scale);
            MovingState = 0;
            Velocity = 0;
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
            if (FrameRateModifier < 11)
            {
                FrameRateModifier++;
            }
            else
            {
                CurrentFrame++;
                FrameRateModifier = 0;
            }

            if (MovingState == 0 && PlayerInAttackingRange(game)) {
                Direction = 1;
                Velocity = 1;
                MovingState = 1;
            }

            if (MovingState == 1 && Location.X >= 32 * scale) 
            {
                Direction = Heading;
                MovingState = 2;
            }

            if (MovingState == 2)
            {
                if (MovingStateTimer < 16 * 6 * scale)
                {
                    MovingStateTimer++;
                }
                else 
                {
                    MovingStateTimer = 0;
                    MovingState = 3;
                }
            }

            if (MovingState == 3)
            {
                if (Location.X >= 8 * scale)
                {
                    Direction = 3;
                }
                else 
                {
                    MovingState = 0;
                    Velocity = 0;
                    Location = new Vector2(OriginalLocation.X, OriginalLocation.Y);
                    CollisionRectangle = new Rectangle((int)(Location.X), (int)(Location.Y), 16 * scale, 16 * scale);
                }
            }

            UpdateLocation();

            if (DamageTimer > 0)
            {
                Velocity = 0;
                DamageTimer--;
            }
            else if(DamageTimer == 0 && MovingState != 0)
            {
                Velocity = 1;
            }

            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
            }
        }

        private bool PlayerInAttackingRange(Game1 game)
        {
            Rectangle playerRectangle = new Rectangle((int)(game.link.GetRectangle().X - LoadAll.Instance.startPos.X), (int)(game.link.GetRectangle().Y - LoadAll.Instance.startPos.Y + 56 * scale), game.link.GetRectangle().Width, game.link.GetRectangle().Height);

            if (playerRectangle.X <= 48 * scale)
            {               
                if (Location.Y < playerRectangle.Y ) 
                {
                    Heading = 2;
                } 
                else if (Location.Y > playerRectangle.Y) 
                {
                    Heading = 0;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateLocation()
        {
            float x = Location.X;
            float y = Location.Y;

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

            Location = new Vector2(x, y);

            CollisionRectangle = new Rectangle((int)(Location.X), (int)(Location.Y), 16 * scale, 16 * scale);
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

        Rectangle IEnemy.GetRectangle()
        {
            return CollisionRectangle;
        }

        int IEnemy.GetHP()
        {
            return hp;
        }
    }
}
