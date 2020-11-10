using Game1.Code.Player.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player.PlayerControlCommand
{
    class UseItem : IPlayerCommand
    {
        Game1 game;
        string itemName;
        public UseItem(Game1 game, string itemName)
        {
            this.game = game;
            this.itemName = itemName;
        }

        public void Execute()
        {
            if (game.link.timeSinceItem >= game.link.timeBetweenItem)
            {
                if (game.link.itemList[itemName] > 0)
                {
                    if (itemName != "Arrow" || game.link.itemList["Bow"] > 0)
                    {
                        game.link.state.UseItem();
                        game.link.item[game.link.itemIndex].UseItem(itemName);
                        game.link.timeSinceItem = 0;
                    }
                    if (itemName != "Boomerang")
                    {
                        game.link.itemList[itemName]--;
                    }
                }
            }
            game.link.useItemDone = game.link.item[game.link.itemIndex].IsDone();
        }
    }
}
