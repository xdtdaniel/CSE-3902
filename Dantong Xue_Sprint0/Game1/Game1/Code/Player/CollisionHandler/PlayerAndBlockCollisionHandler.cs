using Game1.Code.LoadFile;
using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerControlCommand;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game1.Code.Player
{
    public static class PlayerAndBlockCollisionHandler
    {
        static string collidedSide = "";
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
                                LoadAll.Instance.ChangeRoom(collidedSide);
                                doorSide = collidedSide;
                                roomSwitched = true;
                                link.movable = false;
                                break;
                            case "openDoors":
                                LoadAll.Instance.ChangeRoom(collidedSide);
                                doorSide = collidedSide;
                                roomSwitched = true;
                                link.movable = false;
                                break;
                            case "shutDoors":
                                // to do
                                // temp code
                                link.StopMoving(collidedSide, interRect);
                                break;
                            case "lockedDoors":
                                // to do
                                LoadAll.Instance.UnlockDoor(collidedSide);
                                link.StopMoving(collidedSide, interRect);
                                break;
                            case "stairs":
                                // to do
                                // temp code
                                link.StopMoving(collidedSide, interRect);
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
