using Game1.Code.Player.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player.PlayerControlCommand
{
    class UseItem : IPlayerCommand
    {
        Game1 game;
        int inputItemIndex;
        public UseItem(Game1 game, int inputItemIndex)
        {
            this.game = game;
            this.inputItemIndex = inputItemIndex;
        }

        public void Execute()
        {
            if (game.link.timeSinceItem >= game.link.timeBetweenItem)
            {
                game.link.state.UseItem();
                game.link.item[game.link.itemIndex].UseItem(inputItemIndex);
                game.link.timeSinceItem = 0;
            }
            game.link.useItemDone = game.link.item[inputItemIndex].IsDone();
        }
    }
}
