using Game1.Player.Interface;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player
{
    class PlayerAquamentusCollisionHandler 
    {
        string direction;
        public PlayerAquamentusCollisionHandler()
        {
            direction = "down";
        }
        public void HandleCollision(Link link, IEnemy enemy, string direction, string side)
        {
            //direction = side.isCollided(link.GetRectangle(), new Rectangle()/*enemy rectangle*/);
            // for collision test
            if (side != "")
            {
                link.TakeDamage();
                link.KnockedBack(direction, side);
            }
            

        }


    }
}
