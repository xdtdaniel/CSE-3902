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
        List<IProjectile> projectileList;
        public PlayerEnemyCollisionHandler()
        {
            collidedSide = "";
            projectileList = new List<IProjectile>();
        }
        public void HandleCollision(Link link, List<Tuple<IEnemy, string>> enemyList)
        {
            foreach (Tuple<IEnemy, string> tuple in enemyList)
            {
                collidedSide = BlockCollision.Instance.isCollided(link.GetRectangle(), tuple.Item1.GetRectangle());
                if (collidedSide != "" && link.damageTimeCounter == 0)
                {
                    link.TakeDamage();
                    link.KnockedBack(collidedSide);
                }

                projectileList = tuple.Item1.GetProjectile();

                if (tuple.Item2 == "aquamentus")
                {
                    foreach (IProjectile projectile in tuple.Item1.GetProjectile())
                    {
                        if (projectile.GetIsOnScreen())
                        {
                            collidedSide = BlockCollision.Instance.isCollided(link.GetRectangle(), tuple.Item1.GetRectangle());
                            if (collidedSide != "" && link.damageTimeCounter == 0)
                            {
                                link.TakeDamage();
                                link.KnockedBack(collidedSide);
                                projectile.SetIsOnScreen(false);
                            }
                        }
                    }
                }

                if (tuple.Item2 == "goriya")
                {
                    foreach (IProjectile projectile in tuple.Item1.GetProjectile())
                    {
                        if (projectile.GetIsOnScreen())
                        {
                            collidedSide = BlockCollision.Instance.isCollided(link.GetRectangle(), tuple.Item1.GetRectangle());
                            if (collidedSide != "" && link.damageTimeCounter == 0)
                            {
                                link.TakeDamage();
                                link.KnockedBack(collidedSide);
                                projectile.BounceBack();
                            }
                        }
                    }
                }
            }
        }
    }
}
