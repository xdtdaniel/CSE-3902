using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Enemy
{
    class OldMan : IEnemy
    {
        private Texture2D Texture;
        private int Columns;
        private int Rows = 1;
        private int TotalFrames;
        private int CurrentFrame;
        private Vector2 Location;

        public OldMan() {
            Texture = EnemyTextureStorage.GetOldManSpriteSheet();
            TotalFrames = 1;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Location = new Vector2(600, 200);
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
        }

        public void FireProjectile()
        {
            // Do nothing.
        }

        public void UpdateEnemy(Game game)
        {
            // Do nothing.
        }
    }
}
