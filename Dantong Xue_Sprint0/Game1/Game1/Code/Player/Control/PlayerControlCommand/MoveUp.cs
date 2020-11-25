using Game1.Code.Player.Interface;

namespace Game1.Code.Player.Control.PlayerControlCommand
{
    class MoveUp : IPlayerCommand
    {
        private Game1 game;
        public MoveUp(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (!game.link.isMoving && game.link.movable)
            {
                game.link.isMoving = true;
                game.link.direction = "up";
                game.link.y -= game.link.ySpeed;
            }
        }
    }
}
