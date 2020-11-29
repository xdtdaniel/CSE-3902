using Game1.Code.Audio.Sounds;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Enemy
{
    class DrawAndUpdateEnemy
    {
        private ISounds enemyDie = new EnemyDie();
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
                Enemies[i].Item1.DrawEnemy(spriteBatch, LoadAll.Instance.startPos);
            }
        }

        public void UpdateAllEnemy(List<Tuple<IEnemy, string>> Enemies, Game1 game)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Item1.UpdateEnemy(game);

                if (Enemies[i].Item1.GetHP() <= 0) 
                {
                    enemyDie.Play();
                    Enemies.RemoveAt(i);

                    if (LoadAll.Instance.GetCurrentMapID() == 22) 
                    {
                        Enemies.Clear();
                    }
                }
            }
        }
    }
}
