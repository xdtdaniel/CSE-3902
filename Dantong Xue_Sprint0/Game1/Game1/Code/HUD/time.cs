using System;
using System.Collections.Generic;
using System.Text;
using Game1.Code.LoadFile;
using Game1;
using Microsoft.Xna.Framework;

namespace Game1.Code.HUD
{
    public class time
    {
        private Game1 game;

        public float game_time = 0;

        public void TimeUpdate(GameTime gameTime)
        {
            if (!game.paused && game.gameStarted && !game.link.isDead && !game.link.state.GetStateName().Equals("WinLink"))
            {
                game_time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Timedraw()
        {
            if (game.gameStarted)
            {
                game._spriteBatch.DrawString(game._spriteFont, "Game Time:" + game_time.ToString("0.00"), new Vector2(550, 10), Color.White);
            }
        }

    }
}
