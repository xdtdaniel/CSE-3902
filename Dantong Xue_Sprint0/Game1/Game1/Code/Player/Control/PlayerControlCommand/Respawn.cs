using Game1.Code.Audio;
using Game1.Code.HUD;
using Game1.Code.LoadFile;
using Game1.Code.Player.Interface;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;

namespace Game1.Code.Player.PlayerControlCommand
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
