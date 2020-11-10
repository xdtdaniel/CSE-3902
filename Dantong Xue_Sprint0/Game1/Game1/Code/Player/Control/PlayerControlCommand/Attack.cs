using Game1.Code.Player.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player.PlayerControlCommand
{
    class Attack : IPlayerCommand
    {
        Game1 game;
        public Attack(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.link.timeSinceAttack >= game.link.timeBetweenAttack)
            {
                if (game.link.itemList["WoodenSword"] > 0)
                {
                    game.link.state.WoodenSwordAttack();
                    if (game.link.itemList["Heart"] == game.link.itemList["HeartContainer"])
                    {
                        game.link.item[game.link.itemIndex].UseItem("RangedWoodenSword");
                    }
                    game.link.timeSinceAttack = 0;
                }
                else if (game.link.itemList["SwordBeam"] > 0)
                {
                    game.link.state.SwordBeamAttack();
                    if (game.link.itemList["Heart"] == game.link.itemList["HeartContainer"])
                    {
                        game.link.item[game.link.itemIndex].UseItem("RangedSwordBeam");
                    }
                    game.link.timeSinceAttack = 0;
                }
            }
        }
    }
}
