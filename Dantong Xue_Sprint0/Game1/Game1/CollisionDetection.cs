using Microsoft.Xna.Framework;
using System;
namespace Game1
{
    class CollisionDetection
    {
        private static CollisionDetection instance = new CollisionDetection();

        public static CollisionDetection Instance
        {
            get
            {
                return instance;
            }
        }
        public string isCollided(Rectangle rectangle1, Rectangle rectangle2)
        {
            String direction="";
            Rectangle rec1 = rectangle1;
            Rectangle rec2 = rectangle2;
            Rectangle intersectionRectangle;

            intersectionRectangle = Rectangle.Intersect(rec1,rec2);


            // those minor changes to the position and size is to avoid circumstances that the collision detection might be too strict that the player
            // cannot go through an empty place, 12 is chosen by testing
            if (!intersectionRectangle.IsEmpty && intersectionRectangle.Width * intersectionRectangle.Height > 12)
             {
                // check the collison direction
                if ((intersectionRectangle.Width >= intersectionRectangle.Height)) // above and below
                 {
                    if (rec1.Y < rec2.Y) // from below
                    {
                            direction = "down";
                    }
                    else //from above
                    {
                            direction = "up";
                    }
                    }
                    else // left and right
                    {
                        if (rec1.X < rec2.X)//from right
                        {
                        direction = "right";
                        }
                        else //from left
                        {
                        direction = "left";
                        }
                    }
                }           

            return direction;
        }

    }
}
