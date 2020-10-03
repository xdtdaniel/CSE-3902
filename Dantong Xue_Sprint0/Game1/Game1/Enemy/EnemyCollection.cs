using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Enemy
{
    class EnemyCollection
    {
        private List<IEnemy> EnemyList;
        private static int index;

        public EnemyCollection()
        {
            EnemyList = new List<IEnemy>();

            EnemyList.Add(new Aquamentus());
            EnemyList.Add(new Goriya());
            EnemyList.Add(new Keese());
            EnemyList.Add(new Stalfos());
            EnemyList.Add(new Gel());
            EnemyList.Add(new OldMan());
            EnemyList.Add(new Merchant());
            EnemyList.Add(new Fire());
            EnemyList.Add(new Wallmaster());

            index = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            EnemyList[index].DrawEnemy(spriteBatch);
            spriteBatch.End();
        }

        public void Update(Game game)
        {
            EnemyList[index].UpdateEnemy(game);
        }

        public void Next()
        {
            index++;

            if (index == EnemyList.Count)
            {
                index = 0;
            }
        }

        public void Previous()
        {
            index--;

            if (index < 0)
            {
                index = EnemyList.Count - 1;
            }
        }
    }
}
