using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Enemy
{
    class Merchant : IEnemy
    {
        private Texture2D Texture;
        private int Columns;
        private int Rows = 1;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location { get; set; }
        private Vector2 LocationOffset { get; set; }
        private Rectangle CollisionRectangle;
        private int scale = 3;
        private List<IProjectile> ProjectileList = new List<IProjectile>();
        private int hp = 100;

        public Merchant(Vector2 location, Vector2 offset)
        {
            Texture = EnemyTextureStorage.GetMerchantSpriteSheet();
            TotalFrames = 1;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Location = location;
            LocationOffset = offset;
            CollisionRectangle = new Rectangle((int)(LocationOffset.X + Location.X), (int)(LocationOffset.Y + Location.Y), 16 * scale, 16 * scale);
        }

        public void DrawEnemy(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)(LocationOffset.X + Location.X), (int)(LocationOffset.Y + Location.Y), width * scale, height * scale);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void FireProjectile()
        {
            // Do nothing.
        }

        public void UpdateEnemy(Game1 game)
        {
            // Do nothing.
        }

        public void TakeDamage(int damageAmount)
        {
            // Do nothing.
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
