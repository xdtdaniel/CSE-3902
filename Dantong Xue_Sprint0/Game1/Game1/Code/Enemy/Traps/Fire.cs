using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Enemy
{
    class Fire : IEnemy
    {
        private Texture2D Texture;
        private int Columns;
        private int Rows = 1;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location { get; set; }
        private int FrameRateModifier = 0;

        private Rectangle CollisionRectangle;
        private int scale = 3;
        private List<IProjectile> ProjectileList = new List<IProjectile>();
        private int hp = 100;

        public Fire(Vector2 location)
        {
            Texture = EnemyTextureStorage.GetFireSpriteSheet();
            TotalFrames = 2;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Location = location;
            CollisionRectangle = new Rectangle((int) (Location.X), (int) (Location.Y), 16 * scale, 16 * scale);

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
            //Do nothing.
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

        void IEnemy.Freeze(int timer)
        {
            // Do Nothing
        }
    }
}
