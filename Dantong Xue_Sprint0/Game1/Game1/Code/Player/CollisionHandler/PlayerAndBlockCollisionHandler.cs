using Game1.Code.Audio;
using Game1.Code.LoadFile;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace Game1.Code.Player
{
    public static class PlayerAndBlockCollisionHandler
    {
        private static string collidedSide = "";
        private static int doorTimeCounter = 0;
        private static int timeBetweenDoor = 60;
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
                    Debug.WriteLine(collidedSide);
                    
                }
            }
        }

    }
}
