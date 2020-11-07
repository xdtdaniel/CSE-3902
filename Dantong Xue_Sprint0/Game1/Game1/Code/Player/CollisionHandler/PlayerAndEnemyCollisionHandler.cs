using Game1.Code.LoadFile;
using Game1.Enemy;
using Game1.Player.Interface;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player
{
    public static class PlayerAndEnemyCollisionHandler 
    {
        static string collidedSide = "";
        static Rectangle swordHitBox = new Rectangle();
        static int swordHitBoxWidth = (int)(14 * LoadAll.Instance.scale);   // represent width when facing left and right, represent height when facing up and down
        static int swordHitBoxHeight = (int)(7 * LoadAll.Instance.scale);  // represent height when facing left and right, represent width when facing up and down
        static bool ifHit = false;
        public static void HandleCollision(Link link, List<Tuple<IEnemy, string>> enemyList)
        {
            if (link.GetStateName() == "SwordBeamLink" || link.GetStateName() == "WoodenSwordLink")
            {
                switch (link.direction)
                {
                    case "down":
                        swordHitBox = new Rectangle(link.x, link.y + swordHitBoxWidth, swordHitBoxHeight, swordHitBoxWidth);
                        break;
                    case "right":
                        swordHitBox = new Rectangle(link.x + swordHitBoxWidth, link.y, swordHitBoxWidth, swordHitBoxHeight);
                        break;
                    case "up":
                        swordHitBox = new Rectangle(link.x, link.y - swordHitBoxWidth, swordHitBoxHeight, swordHitBoxWidth);
                        break;
                    case "left":
                        swordHitBox = new Rectangle(link.x - swordHitBoxWidth, link.y, swordHitBoxWidth, swordHitBoxHeight);
                        break;
                    default:
                        break;
                }
            }
            else if (link.GetStateName() == "NormalLink")
            {
                swordHitBox = new Rectangle();
                ifHit = false;
            }

            foreach (Tuple<IEnemy, string> tuple in enemyList)
            {

                // sword hit enemy
                collidedSide = CollisionDetection.Instance.isCollided(swordHitBox, tuple.Item1.GetRectangle());
                if (!ifHit && collidedSide != "")
                {
                    tuple.Item1.TakeDamage(link.attackDamage);
                    ifHit = true;
                }

                // link touch enemy

                collidedSide = CollisionDetection.Instance.isCollided(link.GetRectangle(), tuple.Item1.GetRectangle());
                if (collidedSide != "" && link.damageTimeCounter == 0 && tuple.Item2 != "oldman")
                {
                    link.TakeDamage();
                    link.KnockedBack(collidedSide);
                }

                // projectiles
                // of aquamentus
                if (link.damageTimeCounter == 0 && tuple.Item2 == "aquamentus")
                {
                    foreach (IProjectile projectile in tuple.Item1.GetProjectile())
                    {
                        if (projectile.GetIsOnScreen())
                        {
                            collidedSide = CollisionDetection.Instance.isCollided(link.GetRectangle(), projectile.GetRectangle());
                            if (collidedSide != "" && link.damageTimeCounter == 0)
                            {
                                link.TakeDamage();
                                link.KnockedBack(collidedSide);
                                projectile.SetIsOnScreen(false);
                            }
                        }
                    }
                }

                // of goriya
                if (link.damageTimeCounter == 0 && tuple.Item2 == "goriya")
                {
                    foreach (IProjectile projectile in tuple.Item1.GetProjectile())
                    {
                        if (projectile.GetIsOnScreen())
                        {
                            collidedSide = CollisionDetection.Instance.isCollided(link.GetRectangle(), projectile.GetRectangle());
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
