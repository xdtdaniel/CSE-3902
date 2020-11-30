using Game1.Code.LoadFile;
using Game1.Enemy;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Game1.Code.Audio;
using Game1.Code.Player.PlayerCharacter;

namespace Game1.Code.Player.CollisionHandler
{
    public static class PlayerAndEnemyCollisionHandler 
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private static string collidedSide = "";
        private static Rectangle swordHitBox = new Rectangle();
        private static int swordHitBoxWidth = 14 * scale;   // represent width when facing left and right, represent height when facing up and down
        private static int swordHitBoxHeight = 7 * scale;  // represent height when facing left and right, represent width when facing up and down
        private static bool ifHit = false;
        private static bool hitAtLeastOne = false;
        private static int dmgAmount = 1;
        private static int offsetY = 56 * scale;
        public static void HandleCollision(Link link, List<Tuple<IEnemy, string, int>> enemyList)
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
                hitAtLeastOne = false;
            }

            foreach (Tuple<IEnemy, string, int> tuple in enemyList)
            {
                Rectangle enemyRectangle = tuple.Item1.GetRectangle();
                int enemyRectX = (int)(enemyRectangle.X + LoadAll.Instance.startPos.X);
                int enemyRectY = (int)(enemyRectangle.Y + LoadAll.Instance.startPos.Y - offsetY);
                // sword hit enemy
                collidedSide = CollisionDetection.Instance.isCollided(swordHitBox, new Rectangle(enemyRectX, enemyRectY, enemyRectangle.Width, enemyRectangle.Height));
                if (!hitAtLeastOne && collidedSide != "")
                {
                    tuple.Item1.TakeDamage(link.basicAttackDamage);
                    if (tuple.Item2 != "aquamentus")
                    {
                        AudioPlayer.enemyHit.Play();                    }
                    else
                    {
                        AudioPlayer.bossHit.Play();
                    }
                    ifHit = true;
                }

                // link touch enemy

                collidedSide = CollisionDetection.Instance.isCollided(link.GetRectangle(), new Rectangle(enemyRectX, enemyRectY, enemyRectangle.Width, enemyRectangle.Height));
                if (collidedSide != "" && link.damageTimeCounter == 0 && tuple.Item2 != "oldman")
                {
                    link.TakeDamage(dmgAmount);
                    link.KnockedBack(collidedSide);
                }

                // projectiles
                // of aquamentus
                if (link.damageTimeCounter == 0 && tuple.Item2 == "aquamentus")
                {
                    foreach (IProjectile projectile in tuple.Item1.GetProjectile())
                    {
                        Rectangle projectileRectangle = projectile.GetRectangle();

                        if (projectile.GetIsOnScreen())
                        {
                            int width = (int)(projectileRectangle.X + LoadAll.Instance.startPos.X);
                            int height = (int)(projectileRectangle.Y + LoadAll.Instance.startPos.Y - offsetY);
                            collidedSide = CollisionDetection.Instance.isCollided(link.GetRectangle(), new Rectangle(width, height, projectileRectangle.Width, projectileRectangle.Height));
                            if (collidedSide != "" && link.damageTimeCounter == 0)
                            {
                                link.TakeDamage(dmgAmount);
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
                        Rectangle projectileRectangle = projectile.GetRectangle();

                        if (projectile.GetIsOnScreen())
                        {
                            int width = (int)(projectileRectangle.X + LoadAll.Instance.startPos.X);
                            int height = (int)(projectileRectangle.Y + LoadAll.Instance.startPos.Y - offsetY);
                            collidedSide = CollisionDetection.Instance.isCollided(swordHitBox, new Rectangle(width, height, projectileRectangle.Width, projectileRectangle.Height));
                            if (collidedSide != "" && link.damageTimeCounter == 0)
                            {
                                projectile.BounceBack();
                            }

                            collidedSide = CollisionDetection.Instance.isCollided(link.GetRectangle(), new Rectangle(width, height, projectileRectangle.Width, projectileRectangle.Height));
                            if (collidedSide != "" && link.damageTimeCounter == 0)
                            {
                                link.TakeDamage(dmgAmount);
                                link.KnockedBack(collidedSide);
                                projectile.BounceBack();
                            }
                        }
                    }
                }
            }
            if (ifHit)
            {
                hitAtLeastOne = true;
            }
        }
    }
}
