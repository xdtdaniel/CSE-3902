using Game1.Code.Audio;
using Game1.Code.Player.Interface;

namespace Game1.Code.Player.PlayerControlCommand
{
    class Jump : IPlayerCommand
    {
        private Game1 game;
        public Jump(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.link.GetStateName() != "JumpLink")
            {
                game.link.Jump();
            }
        }
    }
}
