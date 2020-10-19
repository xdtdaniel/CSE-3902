using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player
{
    class ItemBlockCollisionHandler
    {
        string collidedSide;
        public ItemBlockCollisionHandler()
        {
            collidedSide = "";
        }
        public void HandleCollision(PlayerItem item, Dictionary<string, List<Rectangle>> blockList)
        {
            foreach (KeyValuePair<string, List<Rectangle>> kvp in blockList)
            {
                foreach (Rectangle rect in kvp.Value)
                {
                    collidedSide = BlockCollision.Instance.isCollided(item.GetRectangle(), rect);
                    if (collidedSide != "")
                    {
                        switch (item.GetItemName()) {
                            case "Arrow":
                                break;

                            case "BlueCandle":
                                break;

                            case "BluePotion":
                                break;

                            case "BlueRing":
                                break;

                            case "Bomb":
                                break;

                            case "BombExplosion":
                                break;

                            case "Boomerang":
                                item.CollisionResponse();
                                break;

                            case "SwordBeam":
                                break;

                            case "WoodenSword":
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
