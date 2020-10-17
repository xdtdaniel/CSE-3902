using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player
{
    class PlayerBlockCollisionHandler
    {
        string collidedSide;
        public PlayerBlockCollisionHandler()
        {
            collidedSide = "";
        }
        public void HandleCollision(Link link, Dictionary<string, List<Rectangle>> blockDict, BlockCollision blockCollision)
        {
            foreach (KeyValuePair<string, List<Rectangle>> kvp in blockDict)
            {
                foreach (Rectangle rect in kvp.Value)
                {
                    collidedSide = blockCollision.isCollided(link.GetRectangle(), rect);
                    if (collidedSide != "")
                    {
                        switch (kvp.Key) {
                            case "blocks":
                                if (collidedSide == "down")
                                {
                                    link.y -= link.downSpeed;
                                }
                                if (collidedSide == "right")
                                {
                                    link.x -= link.rightSpeed;
                                }
                                if (collidedSide == "up")
                                {
                                    link.y += link.upSpeed;
                                }
                                if (collidedSide == "left")
                                {
                                    link.x += link.leftSpeed;
                                }
                                break;
                            case "holes":
                                // to do
                                break;
                            case "openDoors":
                                // to do
                                break;
                            case "shutDoors":
                                // to do
                                break;
                            case "lockedDoors":
                                // to do
                                break;
                            case "stairs":
                                // to do
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
