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

using Game1.Enemy;
using System.Reflection;
using System.Diagnostics;

namespace Game1.Code.LoadFile
{
    public class LoadEnemy
    {
        private int MAX_COLUMNS = 32;
        private int multiplier = 8;
        public int scale = 3;

        private const int MAP_COUNT = 18;
        private int CurrentMapID;

        List<Tuple<int, int, string>> EnemyList;

        public LoadEnemy(int currentMapID) {
            CurrentMapID = currentMapID;
        }

        private List<Tuple<IEnemy, string>>[] AllEnemyList = new List<Tuple<IEnemy, string>>[MAP_COUNT];
        private List<Tuple<IEnemy, string>> Enemies = new List<Tuple<IEnemy, string>>();

        public void LoadAllEnemy() {

            int i;
            for (i = 0; i < MAP_COUNT; i++) 
            {
                if (i == 7)
                {
                    LoadMap.Instance.LoadOneMap((i + 1).ToString() + "_enemyblock.csv");
                }
                else 
                {
                    LoadMap.Instance.LoadOneMap((i + 1).ToString() + "_0000.csv");
                }
                LoadOneRoomEnemy((i + 1).ToString() + "_enemy.csv", LoadMap.Instance.GetBlocks());
                AllEnemyList[i] = Enemies;
                Enemies = new List<Tuple<IEnemy, string>>();
            }
        }

        private void LoadOneRoomEnemy(string mapName, List<Microsoft.Xna.Framework.Rectangle> blockList)
        {
            EnemyList = new List<Tuple<int, int, string>>();

            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pathNew = filePath.Substring(0, filePath.IndexOf("bin"));
            pathNew = pathNew + "Maps\\Room\\" + mapName;

            StreamReader streamReader = new StreamReader(pathNew);
            string line;
            string[] strList;
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
                int Y = EnemyList[index].Item2 * multiplier * scale + 56 * scale;
                location = new Vector2(X, Y);

                IEnemy Enemy;

                switch (EnemyList[index].Item3)
                {
                    case "aquamentus":
                        Enemy = new Aquamentus(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "aquamentus"));
                        break;
                    case "gel":
                        Enemy = new Gel(location, blockList);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "gel"));
                        break;
                    case "keese":
                        Enemy = new Keese(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "keese"));
                        break;
                    case "stalfos":
                        Enemy = new Stalfos(location, blockList);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "stalfos"));
                        break;
                    case "goriya":
                        Enemy = new Goriya(location, blockList);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "goriya"));
                        break;
                    case "trap0":
                        Enemy = new Trap0(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "trap"));
                        break;
                    case "trap1":
                        Enemy = new Trap1(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "trap"));
                        break;
                    case "trap2":
                        Enemy = new Trap2(location);
                        Enemies.Add(new Tuple<IEnemy, string>(Enemy, "trap"));
                        break;
                    case "trap3":
                        Enemy = new Trap3(location);
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
            return AllEnemyList[CurrentMapID - 1];
        }

        public void Previous()
        {
            CurrentMapID--;
            if (CurrentMapID <1) 
            {
                CurrentMapID = MAP_COUNT;
            }
        }

        public void Next()
        {
            CurrentMapID++;
            if (CurrentMapID > 18)
            {
                CurrentMapID = 1;
            }
        }

        public int GetCurrentMapID()
        {
            return CurrentMapID;
        }

        public bool NoEnemy() {
            // for the case level 1
            if (AllEnemyList[CurrentMapID - 1].Count == 0 || CurrentMapID == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Tuple<IBlock, Vector2>> LoadRoom11Walls()

        {
            List<Tuple<IBlock, Vector2>> blocksListToDraw = new List<Tuple<IBlock, Vector2>>();
            List<Tuple<int, int, string>> mapElementList = new List<Tuple<int, int, string>>();
            Vector2 startPos = LoadAll.Instance.startPos;

            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pathNew = filePath.Substring(0, filePath.IndexOf("bin"));
            pathNew = pathNew + "Maps\\Room\\" + "11_wallmaster.csv";

            StreamReader streamReader = new StreamReader(pathNew);
            string line;
            string[] strList = new string[MAX_COLUMNS];
            int cell_x = 0;
            int cell_y = 0;
            //each loop add 1 line to list
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();
                //seperate a line by comma. this string array should have all strings seperately.              
                strList = line.Split(',');

                cell_x = 0;

                //cell_x, and cell_y represent the postion in csv
                for (int i = 0; i < strList.Length; i++)
                {
                    if (strList[i] != "")
                    {
                        mapElementList.Add(new Tuple<int, int, string>(cell_x, cell_y, strList[i]));
                    }

                    cell_x++;
                }
                cell_y++;

            }

            /*
            IBlock room;
            room = BlockFactory.Instance.CreateRoom();
            blocksListToDraw.Add(new Tuple<IBlock, Vector2>(room, startPos));
            */

            Vector2 location;

            //switch case for each string
            for (int index = 0; index < mapElementList.Count; index++)
            {

                float X = (float)(mapElementList[index].Item1 * multiplier * scale + startPos.X);
                float Y = (float)(mapElementList[index].Item2 * multiplier * scale + startPos.Y);
                location = new Vector2(X, Y);

                IBlock blockToDraw;

                Console.WriteLine(mapElementList[index].Item3);

                switch (mapElementList[index].Item3)
                {
                    case "wall_1":
                        blockToDraw = BlockFactory.Instance.CreateFrontWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        break;
                    case "wall_2":
                        blockToDraw = BlockFactory.Instance.CreateLeftWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        break;
                    case "wall_3":
                        blockToDraw = BlockFactory.Instance.CreateRightWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        break;
                    case "wall_4":
                        blockToDraw = BlockFactory.Instance.CreateBackWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        break;
                }
            }

            return blocksListToDraw;
        }
    }
}