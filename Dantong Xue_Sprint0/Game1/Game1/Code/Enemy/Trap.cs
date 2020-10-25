using Game1.Enemy;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Trap : IEnemy
    {
        private Texture2D Texture;
        private int Columns;
        private int Rows = 1;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location { get; set; }

        private int MovingState;

        // Test code for sprint 3 rectangle
        private Rectangle CollisionRectangle;
        private int scale = 3;
        private List<IProjectile> ProjectileList = new List<IProjectile>();
        private int hp = 100;

        public Trap(Vector2 location)
        {
            Texture = EnemyTextureStorage.GetTrapSpriteSheet();
            TotalFrames = 1;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Location = location;
            MovingState = 0;

            // Test code for sprint 3 rectangle
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
        public void UpdateEnemy(Game1 game)
        {
            // To do.
        }

        public void FireProjectile()
        {
            // Do nothing.
        }

        public void TakeDamage(int damageAmount)
        {
            //Do nothing.
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
    }
}
