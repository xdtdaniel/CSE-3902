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
using System.Reflection;

namespace Game1.Code.LoadFile
{
    /*
     * this is load item class which load item to the room
     */
    class LoadEnemy
    {
        private int MAX_COLUMNS = 32;
        private int multiplier = 8;
        public int scale = 3;

        List<Tuple<int, int, string>> EnemyList;

        private static LoadEnemy instance = new LoadEnemy();

        public static LoadEnemy Instance
        {
            get
            {
                return instance;
            }
        }

        private List<Tuple<IEnemy, string>> Enemies = new List<Tuple<IEnemy, string>>();

        public void LoadAllEnemy(string mapName)
        {
            EnemyList = new List<Tuple<int, int, string>>();

            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pathNew = filePath.Substring(0, filePath.IndexOf("bin"));
            pathNew = pathNew + "Maps\\Room\\" + mapName;

            StreamReader streamReader = new StreamReader(pathNew);
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

            Enemies.Clear();

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
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "aquamentus"));
                        break;
                    case "gel":
                        Enemy = new Gel(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "gel"));
                        break;
                    case "keese":
                        Enemy = new Keese(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "keese"));
                        break;
                    case "stalfos":
                        Enemy = new Stalfos(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "stalfos"));
                        break;
                    case "goriya":
                        Enemy = new Goriya(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "goriya"));
                        break;
                    case "trap":
                        Enemy = new Trap(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "trap"));
                        break;
                    case "wallmaster":
                        Enemy = new Wallmaster(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "wallmaster"));
                        break;
                    case "merchant":
                        Enemy = new Merchant(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "merchant"));
                        break;
                    case "oldman":
                        Enemy = new OldMan(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "oldman"));
                        break;
                    case "fire":
                        Enemy = new Fire(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "fire"));
                        break;
                }

            }

        }


        public List<Tuple<IEnemy, string>> GetEnemyList() 
        {
            return Enemies;
        }
    }
}