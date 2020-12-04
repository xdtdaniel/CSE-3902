using Game1.Code.Audio;
using Game1.Code.LoadFile;
using Game1.Code.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Game1.Code.Player.CollisionHandler
{
    public static class PlayerAndArrowsCollisionHandler
    {
        /*
         * This collision handler is specific for level 20.
         */
        private static string collidedSide = "";
        private static int doorTimeCounter = 0;
        private const int blockWidth = 16;
        public static string doorSide = "";
        public static bool roomSwitched = false;
        public static void HandleCollision(Link link, Dictionary<string, List<Rectangle>> blockList)
        {
            foreach (KeyValuePair<string, List<Rectangle>> kvp in blockList)
            {
                foreach (Rectangle rect in kvp.Value)
                {
                    collidedSide = CollisionDetection.Instance.isCollided(link.GetRectangle(), rect);
                    if (collidedSide != "")
                    {
                        switch (kvp.Key) {
                            case "leftArrows":
                                link.x -= (int)(blockWidth * LoadAll.Instance.scale);
                                break;
                            case "rightArrows":
                                link.x += (int)(blockWidth * LoadAll.Instance.scale);
                                break;
                            case "upArrows":
                                link.y -= (int)(blockWidth * LoadAll.Instance.scale);
                                break;
                            case "downArrows":
                                link.y += (int)(blockWidth * LoadAll.Instance.scale);
                                break;
                            case "unlock1":
                                LoadAll.Instance.UnlockDoor("right");
                                link.y -= (int)(blockWidth * LoadAll.Instance.scale);
                                break;
                            case "unlock2":
                                link.y += (int)(blockWidth * LoadAll.Instance.scale);
                                LoadAll.Instance.UnlockDoor("down");
                                break;
                            case "unlock3":
                                LoadAll.Instance.UnlockDoor("left");
                                link.y -= (int)(blockWidth * LoadAll.Instance.scale);
                                break;
                            case "unlock4":
                                link.x += (int)(blockWidth * LoadAll.Instance.scale);
                                LoadAll.Instance.UnlockDoor("up");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            if (doorSide != "" && !roomSwitched)
            {
                link.ResetPos();
                doorSide = "";
                link.movable = true;
            }

            if (doorTimeCounter > 0)
            {
                doorTimeCounter--;
            }

        }
    }
}
