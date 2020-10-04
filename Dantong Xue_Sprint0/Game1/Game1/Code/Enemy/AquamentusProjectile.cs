using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Enemy
{
    class AquamentusProjectile : IProjectile
    {
        private Texture2D Texture;
        private int Direction;
        private Vector2 Location;
        private int Rows = 1;
        private int Columns;
        private int TotalFrames;
        private int CurrentFrame;
        private double Velocity;
        private bool IsOnScreen;
        private readonly double Sin15 = 0.2588190451 ;
        private readonly double Cos15 = 0.96592582628;

        public AquamentusProjectile() 
        {
            Texture = EnemyTextureStorage.GetAquamentusProjectileSpriteSheet();
            TotalFrames = 3;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Velocity = 3.0;
        }

        public void DrawProjectile(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X - 20, (int)Location.Y, width * 4, height * 4);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }


        public void UpdateProjectile(Game game)
        {
            CurrentFrame++;
            if (CurrentFrame > TotalFrames) {
                CurrentFrame = 0;
            }

            UpdateLocation();

            if (HitEdge(game)) 
            {
                IsOnScreen = false;
            }
        }

        public bool GetIsOnScreen()
        {
            return IsOnScreen;
        }

        public void SetIsOnScreen()
        {
            IsOnScreen = true;
        }

        public void SetDirection(int direction)
        {
            Direction = direction;
        }

        public void SetLocation(Vector2 location)
        {
            Location = location;
        }

        private void UpdateLocation() 
        {
            float x = Location.X;
            float y = Location.Y;

            if (Direction == 0) 
            {
                x -= (float)(Velocity * Cos15);
                y -= (float)(Velocity * Sin15);
            } 
            else if (Direction == 1) 
            {
                x -= (float)Velocity;
            } 
            else if (Direction == 2) 
            {
                x -= (float)(Velocity * Cos15);
                y += (float)(Velocity * Sin15);
            }

            Location = new Vector2(x, y);
        }

        private bool HitEdge(Game game)
        {
            Boolean outside = false;
            if (Location.X <= 0 || Location.X >= game.Window.ClientBounds.Width - 68 || Location.Y <= 0 - 16 || Location.Y >= game.Window.ClientBounds.Height - 60)
            {
                outside = true;
            }
            return outside;
        }
    }
}
