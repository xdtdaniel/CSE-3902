using Game1.Code.Audio;
using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerItem;

namespace Game1.Code.Player.Control.PlayerControlCommand
{
    class UseAbility : IPlayerCommand
    {
        private Game1 game;
        public UseAbility(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.link.itemPool.UseAbility("");
        }
    }
}
