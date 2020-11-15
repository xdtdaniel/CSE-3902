using Game1.Code.Audio;
using Game1.Code.LoadFile;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Game1.Code.Player
{
    public static class PlayerItemAndEnemyCollisionHandler
    {
        private static string collidedSide = "";
        private static int boomerangHit = -1;
        private static int rangedSwordHit = -1;
        private static bool[] enemyHitByRangedSword;
        public static void HandleCollision(LinkItem[] itemPool, List<Tuple<IEnemy, string>> enemyList)
        {
            for (int i = 0; i < itemPool.Length; i++)
            {
                LinkItem item = itemPool[i];

                if (i == boomerangHit && item.IsDone())
                {
                    boomerangHit = -1;
                }
                if (i == rangedSwordHit && item.IsDone())
                {
                    rangedSwordHit = -1;
                }
                // 
                if (rangedSwordHit == -1)
                {
                    enemyHitByRangedSword = new bool[enemyList.Count];
                    for (int j = 0; j < enemyHitByRangedSword.Length; j++)
                    {
                        enemyHitByRangedSword[j] = false;
                    }
                }

                int currEnemyIndex = 0;
                foreach (Tuple<IEnemy, string> tuple in enemyList)
                {
                    Rectangle enemyRectangle = tuple.Item1.GetRectangle();

                    collidedSide = CollisionDetection.Instance.isCollided(item.GetRectangle(), new Rectangle((int)(enemyRectangle.X + LoadAll.Instance.startPos.X), (int)(enemyRectangle.Y + LoadAll.Instance.startPos.Y - 56 * LoadAll.Instance.scale), enemyRectangle.Width, enemyRectangle.Height));
                    if (collidedSide != "")
                    {
                        switch (item.GetItemName())
                        {
                            case "Arrow":
                                tuple.Item1.TakeDamage(item.link.basicAttackDamage);
                                item.CollisionResponse();
                                break;

                            case "BombExplosion":
                                tuple.Item1.TakeDamage(item.link.bombExplosionDamage);
                                break;

                            case "Boomerang":
                                if (boomerangHit == -1)
                                {
                                    tuple.Item1.TakeDamage(item.link.basicAttackDamage);
                                    boomerangHit = i;
                                }
                                item.CollisionResponse();
                                break;

                            case "RangedSwordBeam":
                                if (!enemyHitByRangedSword[currEnemyIndex])
                                {
                                    tuple.Item1.TakeDamage(item.link.basicAttackDamage);
                                    rangedSwordHit = i;
                                }
                                item.CollisionResponse();
                                break;

                            case "RangedWoodenSword":
                                if (!enemyHitByRangedSword[currEnemyIndex])
                                {
                                    tuple.Item1.TakeDamage(item.link.basicAttackDamage);
                                    rangedSwordHit = i;
                                    enemyHitByRangedSword[currEnemyIndex] = true;
                                }
                                item.CollisionResponse();
                                break;

                            case "RangedWoodenEdge":
                                if (!enemyHitByRangedSword[currEnemyIndex])
                                {
                                    tuple.Item1.TakeDamage(item.link.basicAttackDamage);
                                    rangedSwordHit = i;
                                    enemyHitByRangedSword[currEnemyIndex] = true;
                                }
                                item.CollisionResponse();
                                break;
                            case "RangedBeamEdge":
                                if (!enemyHitByRangedSword[currEnemyIndex])
                                {
                                    tuple.Item1.TakeDamage(item.link.basicAttackDamage);
                                    rangedSwordHit = i;
                                }
                                item.CollisionResponse();
                                break;
                            default:
                                break;
                        }

                        if (tuple.Item2 != "aquamentus")
                        {
                            AudioPlayer.enemyHit.Play();
                        }
                        else
                        {
                            AudioPlayer.bossHit.Play();
                        }
                    }
                    currEnemyIndex++;

                }
            }
        }
    }
}
