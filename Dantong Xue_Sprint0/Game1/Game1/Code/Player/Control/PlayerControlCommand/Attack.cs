using Game1.Code.Audio;
using Game1.Code.Player.Interface;

namespace Game1.Code.Player.Control.PlayerControlCommand
{
    class Attack : IPlayerCommand
    {
        private Game1 game;
        public Attack(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.link.timeSinceAttack >= game.link.timeBetweenAttack && game.link.canAttack)
            {
                game.link.Attack();
                AudioPlayer.swordSlash.Play();
                if (game.link.itemList["WoodenSword"] > 0)
                {
                    if (game.link.itemList["Heart"] == game.link.itemList["HeartContainer"])
                    {
                        AudioPlayer.swordShoot.Play();
                        game.link.itemPool.UseItem("RangedWoodenSword");
                    }
                    game.link.timeSinceAttack = 0;
                }
                else if (game.link.itemList["SwordBeam"] > 0)
                {
                    if (game.link.itemList["Heart"] == game.link.itemList["HeartContainer"])
                    {
                        AudioPlayer.swordShoot.Play();
                        game.link.itemPool.UseItem("RangedSwordBeam");
                    }
                    game.link.timeSinceAttack = 0;
                }
            }
        }
    }
}
