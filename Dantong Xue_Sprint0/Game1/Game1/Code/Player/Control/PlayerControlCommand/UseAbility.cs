using Game1.Code.Audio;
using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerItem;

namespace Game1.Code.Player.Control.PlayerControlCommand
{
    class UseAbility : IPlayerCommand
    {
        private Game1 game;

        private int type;
        private int index;

        public UseAbility(Game1 game, int type, int index)
        {
            this.game = game;
            this.type = type;
            this.index = index;
        }

        public void Execute()
        {
                game.playerAbilityPanel.UseAbility(type, index);
            
        }
    }
}
