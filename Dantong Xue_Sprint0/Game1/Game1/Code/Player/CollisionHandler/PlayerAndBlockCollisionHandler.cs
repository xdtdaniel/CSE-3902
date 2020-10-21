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
    class PlayerAndBlockCollisionHandler
    {
        string collidedSide;
        public PlayerAndBlockCollisionHandler()
        {
            collidedSide = "";
        }
        public void HandleCollision(Link link, Dictionary<string, List<Rectangle>> blockList)
        {
            foreach (KeyValuePair<string, List<Rectangle>> kvp in blockList)
            {
                foreach (Rectangle rect in kvp.Value)
                {
                    collidedSide = BlockCollision.Instance.isCollided(link.GetRectangle(), rect);
                    if (collidedSide != "")
                    {
                        Rectangle interRect = Rectangle.Intersect(link.GetRectangle(), rect);
                        switch (kvp.Key) {
                            case "blocks":
                                link.StopMoving(collidedSide, interRect);
                                break;
                            case "holes":
                                // to do
                                // temp code
                                link.StopMoving(collidedSide, interRect);
                                break;
                            case "openDoors":
                                // to do
                                // temp code
                                link.StopMoving(collidedSide, interRect);
                                break;
                            case "shutDoors":
                                // to do
                                // temp code
                                link.StopMoving(collidedSide, interRect);
                                break;
                            case "lockedDoors":
                                // to do
                                // temp code
                                link.StopMoving(collidedSide, interRect);
                                break;
                            case "stairs":
                                // to do
                                // temp code
                                link.StopMoving(collidedSide, interRect);
                                break;
                            default:
                                break;
                        }
                        
                    }
                }
            }



        }

        public void HandleMovableCollision(Link link, List<IBlock> movables)
        {
            foreach (IBlock movable in movables)
            {
                collidedSide = BlockCollision.Instance.isCollided(link.GetRectangle(), movable.GetRectangle(new Vector2(0, 0)));

                
                if (collidedSide != "")
                {
                    movable.SetDestination(collidedSide);
                    Debug.WriteLine(collidedSide);
                    //link.StopMoving(collidedSide, )
                }
                

            }
        }


    }
}
