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
                    // tuple.Item1.TakeDamage();
                }
            }
        }
    }
}
