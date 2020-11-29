using Game1.Code.Audio;
using Game1.Code.LoadFile;
using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerCharacter;
using Game1.Code.Player.PlayerItem;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Game1.Code.Player.CollisionHandler
{
    public static class PlayerItemAndEnemyCollisionHandler
    {
        private static string collidedSide = "";
        private static int rangedSwordHit = -1;
        private static int bombExplosionHit = -1;
        private static int slashHit = -1;
        private static bool[] enemyHitByRangedSword;
        private static bool[] enemyHitByBombExplosion;
        private static bool[] enemyHitByVacuum;
        private static bool[] enemyHitBySlash;
        public static void HandleCollision(Link link, List<Tuple<IEnemy, string>> enemyList)
        {
            for (int i = 0; i < link.itemPool.GetItemPool().Count; i++)
            {
                IPlayerItemState item = link.itemPool.GetItemPool()[i];

                if (i == rangedSwordHit && item.GetItemName() != "SwordEdge")
                {
                    rangedSwordHit = -1;
                }
                if (i == bombExplosionHit && item.GetItemName() != "BombExplosion")
                {
                    bombExplosionHit = -1;
                }
                if (i == slashHit && item.GetItemName() != "Slash")
                {
                    slashHit = -1;
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
                if (bombExplosionHit == -1)
                {
                    enemyHitByBombExplosion = new bool[enemyList.Count];
                    for (int j = 0; j < enemyHitByBombExplosion.Length; j++)
                    {
                        enemyHitByBombExplosion[j] = false;
                    }
                }
                if (slashHit == -1)
                {
                    enemyHitBySlash = new bool[enemyList.Count];
                    for (int j = 0; j < enemyHitBySlash.Length; j++)
                    {
                        enemyHitBySlash[j] = false;
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
                                tuple.Item1.TakeDamage(item.GetDamage());
                                item.CollisionResponse();
                                break;

                            case "BombExplosion":
                                if (!enemyHitByBombExplosion[currEnemyIndex])
                                {
                                    tuple.Item1.TakeDamage(item.GetDamage());
                                    bombExplosionHit = i;
                                    enemyHitByBombExplosion[currEnemyIndex] = true;
                                }
                                break;

                            case "Boomerang":
                                tuple.Item1.TakeDamage(item.GetDamage());
                                item.CollisionResponse();
                                break;

                            case "RangedSword":
                                if (!enemyHitByRangedSword[currEnemyIndex])
                                {
                                    tuple.Item1.TakeDamage(item.GetDamage());
                                    rangedSwordHit = i;
                                    enemyHitByRangedSword[currEnemyIndex] = true;
                                }
                                item.CollisionResponse();
                                break;

                            case "SwordEdge":
                                if (!enemyHitByRangedSword[currEnemyIndex])
                                {
                                    tuple.Item1.TakeDamage(item.GetDamage());
                                    rangedSwordHit = i;
                                    enemyHitByRangedSword[currEnemyIndex] = true;
                                }
                                item.CollisionResponse();
                                break;
                            case "Vacuum":
                                tuple.Item1.Freeze();
                                break;
                            case "Slash":
                                if (!enemyHitBySlash[currEnemyIndex])
                                {
                                    tuple.Item1.TakeDamage(item.GetDamage());
                                    slashHit = i;
                                    enemyHitBySlash[currEnemyIndex] = true;
                                }
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
