using Game1.Code.Player.Interface;

namespace Game1.Code.Player.PlayerControlCommand
{
    class MoveLeft : IPlayerCommand
    {
        Game1 game;
        public MoveLeft(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (!game.link.isMoving && game.link.movable)
            {
                game.link.isMoving = true;
                game.link.direction = "left";
                game.link.x -= game.link.xSpeed;
            }
        }
    }
}
