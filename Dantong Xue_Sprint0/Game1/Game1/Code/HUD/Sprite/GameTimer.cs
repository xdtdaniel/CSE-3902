using System;
using System.Collections.Generic;
using System.Text;
using Game1.Code.LoadFile;
using Game1;
using Microsoft.Xna.Framework;
using Game1.Code.HUD.Sprite;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.HUD
{
    public class GameTimer: IHUDSprite
    {
        private Game1 game;

        private static int scale = (int)LoadAll.Instance.scale;

        private int x;
        private int y;
        private int preY;

        private int currentFrame = 0;
        private int framePerSecond = 60;
        private int currentSecond = 0;
        private int secondPerMinute = 60;
        private int currentMinute = 0;
        private int minutePerHour = 60;
        private int currentHour = 0;
        private int gameTime = 0;

        public GameTimer(Game1 game)
        {
            this.game = game;
        }

        public void Update(float newStartX, float newStartY)
        {
            if (game.gameStarted && !game.paused)
            {
                currentFrame++;
                if (currentFrame >= framePerSecond)
                {
                    currentFrame = 0;
                    currentSecond++;
                }
                if (currentSecond >= secondPerMinute)
                {
                    currentSecond = 0;
                    currentMinute++;
                }
                if (currentMinute >= minutePerHour)
                {
                    currentMinute = 0;
                    currentHour++;
                }

                x = (int)newStartX;
                y = (int)newStartY + preY;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            string time = "Game Time: " + currentHour.ToString() + ":" + currentMinute.ToString() + ":" + currentSecond.ToString();
            spriteBatch.DrawString(game._spriteFont, time, new Vector2(x, y), Color.White);

        }

    }
}
