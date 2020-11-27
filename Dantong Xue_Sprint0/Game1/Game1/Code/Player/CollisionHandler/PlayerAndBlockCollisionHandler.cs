using Game1.Code.Audio;
using Game1.Code.LoadFile;
using Game1.Code.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Game1.Code.Player.CollisionHandler
{
    public static class PlayerAndBlockCollisionHandler
    {
        private static string collidedSide = "";
        private static int doorTimeCounter = 0;
        private static int timeBetweenDoor = 60;
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
                        Rectangle interRect = Rectangle.Intersect(link.GetRectangle(), rect);
                        switch (kvp.Key) {
                            case "blocks":
                                link.StopMoving(collidedSide, interRect);
                                break;
                            case "holes":
                                link.StopMoving(collidedSide, interRect);
                                if (doorTimeCounter == 0)
                                {
                                    LoadAll.Instance.ChangeRoom(collidedSide);
                                    doorSide = collidedSide;
                                    roomSwitched = true;
                                    link.movable = false;
                                    doorTimeCounter = timeBetweenDoor;
                                }
                                break;
                            case "openDoors":
                                link.StopMoving(collidedSide, interRect);
                                if (doorTimeCounter == 0)
                                {
                                    LoadAll.Instance.ChangeRoom(collidedSide);
                                    doorSide = collidedSide;
                                    roomSwitched = true;
                                    link.movable = false;
                                    doorTimeCounter = timeBetweenDoor;
                                }
                                break;
                            case "shutDoors":
                                link.StopMoving(collidedSide, interRect);
                                break;
                            case "lockedDoors":
                                link.StopMoving(collidedSide, interRect);
                                if (link.itemList["Key"] > 0)
                                {
                                    LoadAll.Instance.UnlockDoor(collidedSide);
                                    link.itemList["Key"]--;
                                    AudioPlayer.doorUnlock.Play();
                                }
                                break;
                            case "stairs":
                                link.StopMoving(collidedSide, interRect);
                                if (doorTimeCounter == 0)
                                {
                                    link.StopMoving(collidedSide, interRect);
                                    LoadAll.Instance.UnderWorldTransition();
                                    doorTimeCounter = timeBetweenDoor;
                                    doorSide = "stairs";
                                    link.ResetPos();
                                }
                                break;
                            case "bombWalls":
                                link.StopMoving(collidedSide, interRect);
                                break;
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

        public static void HandleMovableCollision(Link link, List<IBlock> movables)
        {
            foreach (IBlock movable in movables)
            {
                collidedSide = CollisionDetection.Instance.isCollided(link.GetRectangle(), movable.GetRectangle(new Vector2(0, 0)));
                Rectangle interRect = Rectangle.Intersect(link.GetRectangle(), movable.GetRectangle(new Vector2(0, 0)));

                if (collidedSide != "")
                {
                    link.StopMoving(collidedSide, interRect);
                    movable.SetDestination(collidedSide);
                    
                }
            }
        }

    }
}
