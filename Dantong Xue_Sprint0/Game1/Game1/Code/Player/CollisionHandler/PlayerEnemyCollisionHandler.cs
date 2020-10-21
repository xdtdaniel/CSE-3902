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
    class PlayerEnemyCollisionHandler 
    {
        string collidedSide;
        Rectangle swordHitBox;
        int swordHitBoxWidth;   // represent width when facing left and right, represent height when facing up and down
        int swordHitBoxHeight;  // represent height when facing left and right, represent width when facing up and down
        public PlayerEnemyCollisionHandler()
        {
            collidedSide = "";
            swordHitBox = new Rectangle();
            swordHitBoxWidth = (int)(13 * LoadAll.Instance.scale);
            swordHitBoxHeight = (int)(5 * LoadAll.Instance.scale);
        }
        public void HandleCollision(Link link, List<Tuple<IEnemy, string>> enemyList)
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

            foreach (Tuple<IEnemy, string> tuple in enemyList)
            {
                collidedSide = BlockCollision.Instance.isCollided(swordHitBox, tuple.Item1.GetRectangle());
                if (collidedSide != "")
                {
                    // tuple.Item1.TakeDamage();
                }

                collidedSide = BlockCollision.Instance.isCollided(link.GetRectangle(), tuple.Item1.GetRectangle());
                if (collidedSide != "" && link.damageTimeCounter == 0)
                {
                    link.TakeDamage();
                    link.KnockedBack(collidedSide);
                }


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
