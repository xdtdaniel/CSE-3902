using Game1.Code.Player.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player.PlayerControlCommand
{
    class UseItem : IPlayerCommand
    {
        Game1 game;
        int itemIndex;
        public UseItem(Game1 game, int itemIndex)
        {
            this.game = game;
            this.itemIndex = itemIndex;
        }

        public void Execute()
        {
            if (game.link.useItemDone && game.link.timeSinceItem >= game.link.timeBetweenItem)
            {
                game.link.state.UseItem();
                game.link.item.UseItem(itemIndex);
                game.link.timeSinceItem = 0;
            }
            game.link.useItemDone = game.link.item.IsDone();
        }
    }
}
