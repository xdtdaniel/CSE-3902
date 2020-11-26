using Game1.Code.LoadFile;
using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerCharacter;
using Game1.Code.Player.PlayerItem;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Game1.Code.Player.CollisionHandler
{
    public static class PlayerItemAndBlockCollisionHandler
    {
        private static string collidedSide = "";
        public static void HandleCollision(Link link, Dictionary<string, List<Rectangle>> blockList)
        {
            for (int i = 0; i < link.itemPool.GetItemPool().Count; i++)
            {
                IPlayerItemState item = link.itemPool.GetItemPool()[i];
                foreach (KeyValuePair<string, List<Rectangle>> kvp in blockList)
                {
                    foreach (Rectangle rect in kvp.Value)
                    {
                        collidedSide = CollisionDetection.Instance.isCollided(item.GetRectangle(), rect);
                        if (collidedSide != "")
                        {
                            switch (item.GetItemName())
                            {
                                case "Arrow":
                                    item.CollisionResponse();
                                    break;

                                case "BombExplosion":
                                    if (kvp.Key == "bombWalls")
                                    {
                                        LoadAll.Instance.SwitchToAlternative(collidedSide);
                                        LoadAll.Instance.LoadRoom();
                                    }
                                    break;

                                case "Boomerang":
                                    item.CollisionResponse();
                                    break;

                                case "RangedSword":
                                    item.CollisionResponse();
                                    break;

                                default:
                                    break;
                            }

                        }
                    }
                }


            }
        }


    }
}
