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
        static bool ifHit = false;
        public static void HandleCollision(LinkItem item, List<Tuple<IEnemy, string>> enemyList)
        {
            if (item.IsDone())
            {
                ifHit = false;
            }

            foreach (Tuple<IEnemy, string> tuple in enemyList)
            {
                collidedSide = CollisionDetection.Instance.isCollided(item.GetRectangle(), tuple.Item1.GetRectangle());
                if (collidedSide != "")
                {
                    switch (item.GetItemName())
                    {
                        case "Arrow":
                            if (!ifHit)
                            {
                                tuple.Item1.TakeDamage(item.link.attackDamage);
                                ifHit = true;
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
                            if (!ifHit)
                            {
                                tuple.Item1.TakeDamage(item.link.attackDamage * 5);
                                ifHit = true;
                            }
                            break;

                        case "Boomerang":
                            if (!ifHit)
                            {
                                tuple.Item1.TakeDamage(item.link.attackDamage);
                                ifHit = true;
                            }
                            item.CollisionResponse();
                            break;

                        case "RangedSwordBeam":
                            if (!ifHit)
                            {
                                tuple.Item1.TakeDamage(item.link.attackDamage);
                                ifHit = true;
                            }
                            item.CollisionResponse();
                            break;

                        case "RangedWoodenSword":
                            if (!ifHit)
                            {
                                tuple.Item1.TakeDamage(item.link.attackDamage);
                                ifHit = true;
                            }
                            item.CollisionResponse();
                            break;

                        case "RangedWoodenEdge":
                            if (!ifHit)
                            {
                                tuple.Item1.TakeDamage(item.link.attackDamage);
                                ifHit = true;
                            }
                            item.CollisionResponse();
                            break;
                        case "RangedBeamEdge":
                            if (!ifHit)
                            {
                                tuple.Item1.TakeDamage(item.link.attackDamage);
                                ifHit = true;
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
