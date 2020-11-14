using Game1.Code.LoadFile;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Game1.Code.Player
{
    public static class PlayerItemAndBlockCollisionHandler
    {
        private static string collidedSide = "";
        public static void HandleCollision(LinkItem[] itemPool, Dictionary<string, List<Rectangle>> blockList)
        {
            for (int i = 0; i < itemPool.Length; i++)
            {
                LinkItem item = itemPool[i];
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

                                case "RangedSwordBeam":
                                    item.CollisionResponse();
                                    break;

                                case "RangedWoodenSword":
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
