using Game1.Code.Player.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player.PlayerControlCommand
{
    class UseItem : IPlayerCommand
    {
        Game1 game;
        public UseItem(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            string itemName = game.selectedItemName;
            int itemIndex = game.link.itemIndex;
            if (itemName == "Bow")
            {
                itemName = "Arrow";
            }
            if (game.link.timeSinceItem >= game.link.timeBetweenItem)
            {
                if (itemName != "" && game.link.itemList[itemName] > 0 && (itemName != "Arrow" || game.link.itemList["Bow"] > 0))
                {
                    game.link.state.UseItem();
                    game.link.itemPool[itemIndex].UseItem(itemName);
                        
                    game.link.timeSinceItem = 0;
                    

                    game.link.itemList[itemName]--;
                }
            }
            game.link.useItemDone = game.link.itemPool[game.link.itemIndex].IsDone();

        }
    }
}
