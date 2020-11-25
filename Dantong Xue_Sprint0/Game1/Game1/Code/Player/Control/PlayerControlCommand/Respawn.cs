using Game1.Code.Player.Interface;

namespace Game1.Code.Player.Control.PlayerControlCommand
{
    class Respawn : IPlayerCommand
    {
        private Game1 game;
        public Respawn(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.goodToRespawn = true;

        }
    }
}
