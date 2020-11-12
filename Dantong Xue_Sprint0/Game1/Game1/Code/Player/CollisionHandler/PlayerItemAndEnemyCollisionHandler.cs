using Game1.Code.Audio.Sounds;
using Game1.Code.LoadFile;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player
{
    public static class PlayerItemAndEnemyCollisionHandler
    {
        static string collidedSide = "";
        static int boomerangHit = -1;
        static int rangedSwordHit = -1;
        private static ISounds bombBlow = new BombBlow();
        private static ISounds enemyHit = new EnemyHit();
        private static ISounds bossHit = new BossHit();
        public static void HandleCollision(LinkItem[] itemPool, List<Tuple<IEnemy, string>> enemyList)
        {
            for (int i = 0; i < itemPool.Length; i++)
            {
                LinkItem item = itemPool[i];

                // if an enemy hit by the same item before, deal no damage until the item is done
                if (i == boomerangHit && item.IsDone())
                {
                    boomerangHit = -1;
                }
                if (i == rangedSwordHit && item.IsDone())
                {
                    rangedSwordHit = -1;
                }

                foreach (Tuple<IEnemy, string> tuple in enemyList)
                {
                    Rectangle enemyRectangle = tuple.Item1.GetRectangle();

                    collidedSide = CollisionDetection.Instance.isCollided(item.GetRectangle(), new Rectangle((int)(enemyRectangle.X + LoadAll.Instance.startPos.X), (int)(enemyRectangle.Y + LoadAll.Instance.startPos.Y - 56 * LoadAll.Instance.scale), enemyRectangle.Width, enemyRectangle.Height));
                    if (collidedSide != "")
                    {
                        switch (item.GetItemName())
                        {
                            case "Arrow":
                                tuple.Item1.TakeDamage(item.link.attackDamage);
                                if(tuple.Item2 != "aquamentus")
                                {
                                    enemyHit.Play();
                                }
                                else
                                {
                                    bossHit.Play();
                                }
                                item.CollisionResponse();
                                break;

                            case "BlueCandle":
                                break;

                            case "BluePotion":
                                break;

                            case "BlueRing":
                                break;

                            case "Bomb":
                                break;

                            case "BombExplosion":
                                tuple.Item1.TakeDamage(item.link.attackDamage * 5);
                                bombBlow.Play();
                                if (tuple.Item2 != "aquamentus")
                                {
                                    enemyHit.Play();
                                }
                                else
                                {
                                    bossHit.Play();
                                }
                                break;

                            case "Boomerang":
                                if (boomerangHit == -1)
                                {
                                    tuple.Item1.TakeDamage(item.link.attackDamage);
                                    boomerangHit = i;
                                }
                                if (tuple.Item2 != "aquamentus")
                                {
                                    enemyHit.Play();
                                }
                                else
                                {
                                    bossHit.Play();
                                }
                                item.CollisionResponse();
                                break;

                            case "RangedSwordBeam":
                                if (rangedSwordHit == -1)
                                {
                                    tuple.Item1.TakeDamage(item.link.attackDamage);
                                    rangedSwordHit = i;
                                }
                                if (tuple.Item2 != "aquamentus")
                                {
                                    enemyHit.Play();
                                }
                                else
                                {
                                    bossHit.Play();
                                }
                                item.CollisionResponse();
                                break;

                            case "RangedWoodenSword":
                                if (rangedSwordHit == -1)
                                {
                                    tuple.Item1.TakeDamage(item.link.attackDamage);
                                    rangedSwordHit = i;
                                }
                                if (tuple.Item2 != "aquamentus")
                                {
                                    enemyHit.Play();
                                }
                                else
                                {
                                    bossHit.Play();
                                }
                                item.CollisionResponse();
                                break;

                            case "RangedWoodenEdge":
                                if (rangedSwordHit == -1)
                                {
                                    tuple.Item1.TakeDamage(item.link.attackDamage);
                                    rangedSwordHit = i;
                                }
                                if (tuple.Item2 != "aquamentus")
                                {
                                    enemyHit.Play();
                                }
                                else
                                {
                                    bossHit.Play();
                                }
                                item.CollisionResponse();
                                break;
                            case "RangedBeamEdge":
                                if (rangedSwordHit == -1)
                                {
                                    tuple.Item1.TakeDamage(item.link.attackDamage);
                                    rangedSwordHit = i;
                                }
                                if (tuple.Item2 != "aquamentus")
                                {
                                    enemyHit.Play();
                                }
                                else
                                {
                                    bossHit.Play();
                                }
                                item.CollisionResponse();
                                break;
                            default:
                                break;
                        }
                    }

                }
            }
        }
    }
}
