using Game1.Code.Player.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player.PlayerControlCommand
{
    class Attack : IPlayerCommand
    {
        Game1 game;
        int attackIndex;
        public Attack(Game1 game, int attackIndex)
        {
            this.game = game;
            this.attackIndex = attackIndex;
        }

        public void Execute()
        {
            if (game.link.timeSinceAttack >= game.link.timeBetweenAttack)
            {
                if (attackIndex == 0 && game.link.itemList["WoodenSword"] > 0)
                {
                    game.link.state.AttackN();
                    if (game.link.itemList["Heart"] == game.link.itemList["HeartContainer"])
                    {
                        game.link.item[game.link.itemIndex].UseItem("RangedWoodenSword");
                    }
                    game.link.timeSinceAttack = 0;
                }
                else if (attackIndex == 1 && game.link.itemList["SwordBeam"] > 0)
                {
                    game.link.state.AttackZ();
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
