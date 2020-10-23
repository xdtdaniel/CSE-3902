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
        public PlayerItemaAndEnemyCollisionHandler()
        {
            collidedSide = "";
        }
        public void HandleCollision(LinkItem item, List<Tuple<IEnemy, string>> enemyList)
        {

            foreach (Tuple<IEnemy, string> tuple in enemyList)
            {
                collidedSide = BlockCollision.Instance.isCollided(item.GetRectangle(), tuple.Item1.GetRectangle());
                if (collidedSide != "")
                {
                    switch (item.GetItemName())
                    {
                        case "Arrow":
                            tuple.Item1.TakeDamage(5);
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
                            tuple.Item1.TakeDamage(50);
                            break;

                        case "Boomerang":
                            tuple.Item1.TakeDamage(10);
                            break;

                        case "SwordBeam":
                            tuple.Item1.TakeDamage(10);
                            break;

                        case "WoodenSword":
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}
