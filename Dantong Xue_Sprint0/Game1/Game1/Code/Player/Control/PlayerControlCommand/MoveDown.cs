using Game1.Code.Player.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player.PlayerControlCommand
{
    class MoveDown : IPlayerCommand
    {
        Game1 game;
        public MoveDown(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (!game.link.isMoving && game.link.movable)
            {
                game.link.isMoving = true;
                game.link.direction = "down";
                game.link.y += game.link.ySpeed;
            }
        }
    }
}
