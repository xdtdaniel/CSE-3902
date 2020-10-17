using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Enemy
{
    class DrawAndUpdateEnemy
    {
        private static DrawAndUpdateEnemy instance = new DrawAndUpdateEnemy();

        public static DrawAndUpdateEnemy Instance
        {
            get
            {
                return instance;
            }
        }

        public void DrawAllEnemy(List<IEnemy> Enemies, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].DrawEnemy(spriteBatch);
            }
        }

        public void UpdateAllEnemy(List<IEnemy> Enemies, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].UpdateEnemy();
            }
        }
    }
}
