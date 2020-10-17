using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.DirectoryServices.ActiveDirectory;
using Game1.Code.Block.BlockFactory;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Item.ItemInterface;
using Game1.Code.Item.ItemFactory;
using Game1.Enemy;

namespace Game1.Code.LoadFile
{
    /*
     * this is load item class which load item to the room
     */
    class LoadEnemy
    {
        private int MAX_COLUMNS = 32;
        private int multiplier = 8;
        public int scale = 2;
        private SpriteBatch spriteBatch;

        private class Cell
        {
            private int column { get; set; }
            private int row { get; set; }
            private string element { get; set; }

        }

        List<Tuple<int, int, string>> EnemyList;

        private static LoadEnemy instance = new LoadEnemy();

        public static LoadEnemy Instance
        {
            get
            {
                return instance;
            }
        }

        private LoadEnemy()
        {
            // ???
        }

        private List<IEnemy> Enemies = new List<IEnemy>();

        public void LoadAllEnemy(SpriteBatch currSpriteBatch)
        {
            spriteBatch = currSpriteBatch;
            EnemyList = new List<Tuple<int, int, string>>();
            string filePath = System.IO.Path.GetFullPath("test_loadenemy.csv");
            StreamReader streamReader = new StreamReader(filePath);
            string line;
            string[] strList = new string[MAX_COLUMNS];
            int cell_x;
            int cell_y = 0;
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();
                strList = line.Split(',');
                cell_x = 0;
                //cell_x, and cell_y represent the postion in csv
                for (int i = 0; i < MAX_COLUMNS; i++)
                {
                    if (strList[i] != "_")
                    {
                        EnemyList.Add(new Tuple<int, int, string>(cell_x, cell_y, strList[i]));
                    }

                    cell_x++;
                }
                cell_y++;
            }

            Vector2 location;

            for (int index = 0; index < EnemyList.Count; index++)
            {

                int X = EnemyList[index].Item1 * multiplier * scale;
                int Y = EnemyList[index].Item2 * multiplier * scale;
                location = new Vector2(X, Y);

                IEnemy Enemy;

                switch (EnemyList[index].Item3)
                {
                    case "aquamentus":
                        Enemy = new Aquamentus(location);
                        Enemies.Add(Enemy);
                        break;
                    
                }

            }

        }

        public void DrawAllEnemy() {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].DrawEnemy(spriteBatch);
            }
        }

        public void UpdateAllEnemy() {
            for (int i = 0; i < Enemies.Count; i++) 
            {
                Enemies[i].UpdateEnemy();
            }
        }  
    }
}