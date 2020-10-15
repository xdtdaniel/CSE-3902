using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player
{
    class PlayerBlockCollisionHandler
    {
        string direction;
        public PlayerBlockCollisionHandler()
        {
            direction = "down";
        }
        public void HandleCollision(Link link, IBlock block, BlockCollision side)
        {
            direction = side.isCollided(link.GetRectangle(), new Rectangle()/*block rectangle*/);



        }


    }
}
