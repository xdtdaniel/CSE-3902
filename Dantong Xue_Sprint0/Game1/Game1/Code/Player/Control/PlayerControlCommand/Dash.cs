using Game1.Code.Audio;
using Game1.Code.Player.Interface;

namespace Game1.Code.Player.Control.PlayerControlCommand
{
    class Dash : IPlayerCommand
    {
        private Game1 game;
        public Dash(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.link.GetStateName() != "DashLink")
            {
                game.link.Dash();
            }
        }
    }
}
