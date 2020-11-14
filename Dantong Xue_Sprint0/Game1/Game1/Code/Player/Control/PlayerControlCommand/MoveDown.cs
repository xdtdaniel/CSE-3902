using Game1.Code.Player.Interface;

namespace Game1.Code.Player.PlayerControlCommand
{
    class MoveDown : IPlayerCommand
    {
        private Game1 game;
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
