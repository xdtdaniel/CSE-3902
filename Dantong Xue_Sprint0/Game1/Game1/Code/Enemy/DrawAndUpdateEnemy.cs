using Microsoft.Xna.Framework;
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

        public void DrawAllEnemy(List<Tuple<IEnemy, string>> Enemies, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Item1.DrawEnemy(spriteBatch);
            }
        }

        public void UpdateAllEnemy(List<Tuple<IEnemy, string>> Enemies, SpriteBatch spriteBatch, Game1 game)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Item1.UpdateEnemy(game);
                if (Enemies[i].Item1.GetHP() <= 0) {
                    Enemies.RemoveAt(i);
                }
            }
        }
    }
}
