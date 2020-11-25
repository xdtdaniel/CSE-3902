using Game1.Code.Player.Interface;

namespace Game1.Code.Player.Control.PlayerControlCommand
{
    class MoveRight : IPlayerCommand
    {
        private Game1 game;
        public MoveRight(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (!game.link.isMoving && game.link.movable)
            {
                game.link.isMoving = true;
                game.link.direction = "right";
                game.link.x += game.link.xSpeed;
            }
        }
    }
}
