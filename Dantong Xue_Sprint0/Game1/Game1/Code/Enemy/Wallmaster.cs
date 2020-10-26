using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Enemy
{
    class Wallmaster : IEnemy
    {
        // This class needs further modifications.

        private Texture2D Texture;
        private int Columns;
        private int Rows;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location { get; set; }
        private int FrameRateModifier = 0;
        private int hp = 20;
        
        // will be used later
        // private int DamageTimer = 0;

        private Rectangle CollisionRectangle;
        private int scale = 3;
        private List<IProjectile> ProjectileList = new List<IProjectile>();

        public Wallmaster(Vector2 location)
        {
            Texture = EnemyTextureStorage.GetWallmasterSpriteSheet();
            TotalFrames = 8;
            Columns = 2;
            Rows = 4;
            CurrentFrame = 0;
            Location = location;

            CollisionRectangle = new Rectangle((int)Location.X, (int)Location.Y, 16 * scale, 16 * scale);
        }

        public void DrawEnemy(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, width * scale, height * scale);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
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

            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
            }
        }

        public void TakeDamage(int damageAmount)
        {
            hp -= damageAmount;
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
