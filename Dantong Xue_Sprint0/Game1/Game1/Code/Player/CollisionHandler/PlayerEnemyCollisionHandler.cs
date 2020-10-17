using Game1.Player.Interface;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player
{
    class PlayerEnemyCollisionHandler 
    {
        string collidedSide;
        public PlayerEnemyCollisionHandler()
        {
            collidedSide = "";
        }
        public void HandleCollision(Link link, List<IEnemy> enemyList, BlockCollision blockCollision)
        {
            foreach (IEnemy enemy in enemyList)
            {
                collidedSide = blockCollision.isCollided(link.GetRectangle(), enemy.GetRectangle());
                if (collidedSide != "" && link.damageTimeCounter == 0)
                {
                    link.TakeDamage();
                    link.KnockedBack(collidedSide);
                }
            }
        }
    }
}
