using Game1.Code.LoadFile;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player
{
    class PlayerItemaAndEnemyCollisionHandler
    {
        string collidedSide;
        bool ifHit;
        public PlayerItemaAndEnemyCollisionHandler()
        {
            collidedSide = "";
            ifHit = false;
        }
        public void HandleCollision(LinkItem item, List<Tuple<IEnemy, string>> enemyList)
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
                                tuple.Item1.TakeDamage(5);
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
                                tuple.Item1.TakeDamage(50);
                                ifHit = true;
                            }
                            break;

                        case "Boomerang":
                            if (!ifHit)
                            {
                                tuple.Item1.TakeDamage(10);
                                ifHit = true;
                            }
                            item.CollisionResponse();
                            break;

                        case "RangedSwordBeam": 
                            break;

                        case "RangedWoodenSword":
                            if (!ifHit)
                            {
                                tuple.Item1.TakeDamage(10);
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
