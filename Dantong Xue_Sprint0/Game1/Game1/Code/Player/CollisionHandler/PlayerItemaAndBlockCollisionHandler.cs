using Game1.Code.LoadFile;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player
{
    class PlayerItemaAndBlockCollisionHandler
    {
        string collidedSide;
        public PlayerItemaAndBlockCollisionHandler()
        {
            collidedSide = "";
        }
        public void HandleCollision(LinkItem item, Dictionary<string, List<Rectangle>> blockList)
        {
            foreach (KeyValuePair<string, List<Rectangle>> kvp in blockList)
            {
                foreach (Rectangle rect in kvp.Value)
                {
                    collidedSide = CollisionDetection.Instance.isCollided(item.GetRectangle(), rect);
                    if (collidedSide != "")
                    {
                        switch (item.GetItemName()) {
                            case "Arrow":
                                item.CollisionResponse();
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
                                if (kvp.Key == "bombWalls")
                                {
                                    LoadAll.Instance.SwitchToAlternative();
                                    LoadAll.Instance.LoadRoom();
                                }
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
