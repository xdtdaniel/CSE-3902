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
        public static void HandleCollision(Link link, List<Tuple<IEnemy, string, int>> enemyList)
        {
            for (int i = 0; i < link.itemPool.GetItemPool().Count; i++)
            {
                IPlayerItemState item = link.itemPool.GetItemPool()[i];

                foreach (Tuple<IEnemy, string, int> tuple in enemyList)
                {
                    Rectangle enemyRectangle = tuple.Item1.GetRectangle();

                    collidedSide = CollisionDetection.Instance.isCollided(item.GetRectangle(), new Rectangle((int)(enemyRectangle.X + LoadAll.Instance.startPos.X), (int)(enemyRectangle.Y + LoadAll.Instance.startPos.Y - 56 * LoadAll.Instance.scale), enemyRectangle.Width, enemyRectangle.Height));
                    if (collidedSide != "")
                    {
                        item.CollisionResponse(tuple.Item3);
                        switch (item.GetItemName())
                        {
                            case "Arrow":
                                tuple.Item1.TakeDamage(item.GetDamage());
                                break;

                            case "BombExplosion":
                                tuple.Item1.TakeDamage(item.GetDamage());
                                break;

                            case "Boomerang":
                                tuple.Item1.TakeDamage(item.GetDamage());
                                break;

                            case "RangedSword":
                                tuple.Item1.TakeDamage(item.GetDamage());
                                break;

                            case "SwordEdge":
                                tuple.Item1.TakeDamage(item.GetDamage());
                                break;

                            case "Radiation":
                                tuple.Item1.Freeze();
                                break;

                            case "Slash":
                                tuple.Item1.TakeDamage(item.GetDamage());
                                break;

                            case "Impact":
                                tuple.Item1.TakeDamage(item.GetDamage());
                                break;

                            case "Explosion":
                                tuple.Item1.TakeDamage(item.GetDamage());
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

                }
            }
        }
    }
}
