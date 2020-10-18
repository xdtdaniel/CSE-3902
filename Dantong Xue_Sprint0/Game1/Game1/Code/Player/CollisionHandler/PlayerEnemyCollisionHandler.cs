using Game1.Enemy;
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
        IProjectile aquamentusProjectile;
        IProjectile goriyaProjectile;
        public PlayerEnemyCollisionHandler()
        {
            collidedSide = "";
            aquamentusProjectile = new AquamentusProjectile();
            goriyaProjectile = new GoriyaProjectile();
        }
        public void HandleCollision(Link link, List<Tuple<IEnemy, string>> enemyList, BlockCollision blockCollision)
        {
            foreach (Tuple<IEnemy, string> tuple in enemyList)
            {
                collidedSide = blockCollision.isCollided(link.GetRectangle(), tuple.Item1.GetRectangle());
                if (collidedSide != "" && link.damageTimeCounter == 0)
                {
                    link.TakeDamage();
                    link.KnockedBack(collidedSide);
                }
            }
            if (aquamentusProjectile.GetIsOnScreen())
            {
                collidedSide = blockCollision.isCollided(link.GetRectangle(), aquamentusProjectile.GetRectangle()); 
                if (collidedSide != "" && link.damageTimeCounter == 0)
                {
                    link.TakeDamage();
                    link.KnockedBack(collidedSide);
                }
            }
            if (goriyaProjectile.GetIsOnScreen())
            {
                collidedSide = blockCollision.isCollided(link.GetRectangle(), goriyaProjectile.GetRectangle()); 
                if (collidedSide != "" && link.damageTimeCounter == 0)
                {
                    link.TakeDamage();
                    link.KnockedBack(collidedSide);
                }
            }
        }
    }
}
