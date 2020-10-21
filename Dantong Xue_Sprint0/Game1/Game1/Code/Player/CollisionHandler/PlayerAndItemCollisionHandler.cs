using Game1.Code.Item.ItemInterface;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game1.Code.Player
{
    class PlayerAndItemCollisionHandler
    {
        string collidedSide;
        public PlayerAndItemCollisionHandler()
        {
            collidedSide = "";
        }
        public void HandleCollision(Link link, List<Tuple<IItemSprite, string>> roomItemList)
        {
            foreach (Tuple<IItemSprite, string> tuple in roomItemList)
            {
                collidedSide = BlockCollision.Instance.isCollided(link.GetRectangle(), tuple.Item1.GetRectangle());
                if (collidedSide != "")
                {
                    link.PickUp(1);
                    link.TakeDamage();
                }


            }


        }

    }
}
