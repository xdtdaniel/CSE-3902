using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private Vector2 Location;
        private int Direction = 0;
        private int CanTurnTimer = 0;
        private int FrameRateModifier = 0;
        private Random Rnd;
        private int Velocity = 5;
        private Boolean CanTurn = false;

        public Stalfos()
        {
            Texture = EnemyTextureStorage.GetStalfosSpriteSheet();
            Rnd = new Random();
            TotalFrames = 2;
            Columns = TotalFrames;
            CurrentFrame = 0;
            Location = new Vector2(400, 200);
            Direction = Rnd.Next(3);
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
            // Do Nothing.
        }

        public void UpdateEnemy(Game game)
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

            UpdateCanTurn(game);

            if (CanTurn)
            {
                UpdateDirection(game);
            }

            UpdateLocation();

            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
            }
        }

        private void UpdateCanTurn(Game game)
        {
            if ((UpBlocked() == 0 && Direction == 0) || (RightBlocked(game) == 0 && Direction == 1) || (DownBlocked(game) == 0 && Direction == 2) || (LeftBlocked() == 0 && Direction == 3))
            {
                CanTurn = true;
            }

            if (CanTurnTimer < 16)
            {
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
        }

        private void UpdateDirection(Game game)
        {
            int[] blockedStatus = { UpBlocked(), RightBlocked(game), DownBlocked(game), LeftBlocked() };
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
            CanTurnTimer = 0;
        }

        private int UpBlocked()
        {
            if (Location.Y <= 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private int RightBlocked(Game game)
        {
            if (Location.X >= game.Window.ClientBounds.Width - 80)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private int DownBlocked(Game game)
        {
            if (Location.Y >= game.Window.ClientBounds.Height - 80)
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
            if (Location.X <= 0)
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
        }
    }
}
