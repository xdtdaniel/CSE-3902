using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.DirectoryServices.ActiveDirectory;
using Game1.Code.Block.BlockFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Item.ItemInterface;
using Game1.Code.Item.ItemSprite;
using Microsoft.Xna.Framework.Content;
using System.Reflection;
using System.Diagnostics;

namespace Game1.Code.LoadFile
{
    /*
     * this is load item class used to initialize all items in the room
     */
    public class LoadItem
    {
        private int MAX_COLUMNS = 32;
        private int multiplier = 8;
        private const int MAP_COUNT = LoadAll.MAP_COUNT;
        private int CurrentMapID;
        private double scale = 2;
        private int X;
        private int Y;
        private Vector2 startPos;
        List<Tuple<int, int, string>> RoomItemList;
        private List<Tuple<IItemSprite, string>>[] AllItemInRoom = new List<Tuple<IItemSprite, string>>[MAP_COUNT];
        private List<Tuple<IItemSprite, string>> inRoomItems = new List<Tuple<IItemSprite, string>>();
        private List<Tuple<IItemSprite, string>>[] AllItemInRoomCpoy = new List<Tuple<IItemSprite, string>>[MAP_COUNT];
        private List<Tuple<IItemSprite, string>> inRoomItemsCopy = new List<Tuple<IItemSprite, string>>();
        private static int triforce_RoomID;
        private static int crown_RoomID;

        public LoadItem(int currentMapID)
        {
            multiplier = LoadAll.Instance.multiplier;
            scale = LoadAll.Instance.scale;
            startPos = new Vector2(0, 56 * (int)scale);
            CurrentMapID = currentMapID;

        }

        public void LoadAllItem()
        {
            for (int i = 0; i < MAP_COUNT; i++)
            {
                LoadRoomItem(i + 1);             
                AllItemInRoom[i] = inRoomItems;
                AllItemInRoomCpoy[i] = inRoomItemsCopy;
                inRoomItems = new List<Tuple<IItemSprite, string>>();
                inRoomItemsCopy = new List<Tuple<IItemSprite, string>>();


            }
        }

        public void LoadRoomItem(int mapID)
        {
            string mapName = mapID.ToString() + "_item.csv";
            RoomItemList = new List<Tuple<int, int, string>>();
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pathNew = filePath.Substring(0, filePath.IndexOf("bin"));
            pathNew = pathNew + "Maps\\Room\\" + mapName;
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
                        RoomItemList.Add(new Tuple<int, int, string>(cell_x, cell_y, strList[i]));
                    }

                    cell_x++;
                }
                cell_y++;

            }

            Vector2 location;
            Vector2 startPos = LoadAll.Instance.startPos;
            for (int index = 0; index < RoomItemList.Count; index++)
            {

                 X = (int)(RoomItemList[index].Item1 * multiplier * scale + startPos.X);
                 Y = (int)(RoomItemList[index].Item2 * multiplier * scale + startPos.Y-56*scale);
               
                location = new Vector2(X, Y);
                IItemSprite item;
                IItemSprite itemCopy;

                switch (RoomItemList[index].Item3)
                {
                    case "arrow":
                        item = new Arrow(X, Y);
                        itemCopy = new Arrow(X,Y);
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "Arrow"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "Arrow"));
                        break;
                    case "bomb":
                        item = new Bomb( X, Y);
                        itemCopy  = new Bomb(X, Y);
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "Bomb"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "Bomb"));
                        break;
                    case "boomerang":
                        item = new Boomerang( X, Y);
                        itemCopy = new Boomerang(X,Y);
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "Boomerang"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "Boomerang"));
                        break;
                    case "bow":
                        item = new Bow(X,Y);
                        itemCopy = new Bow(X, Y);
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "Bow"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "Bow"));
                        break;
                    case "clock":
                        item = new Clock(X, Y);
                        itemCopy= new Clock(X, Y);
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "Clock"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "Clock"));
                        break;
                    case "compass":
                        item = new Compass(X, Y);
                        itemCopy= new Compass(X, Y);
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "Compass"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "Compass"));
                        break;
                    case "fairy":
                        item = new Fairy(X,Y);
                        itemCopy = new Fairy(X, Y);
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "Fairy"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "Fairy"));
                        break;
                    case "heart":
                        item = new Heart(X,Y);
                        itemCopy = new Heart(X, Y);
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "Heart"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "Heart"));
                        break;
                    case "heartcontainer":
                        item = new HeartContainer(X, Y);
                        itemCopy = new HeartContainer(X, Y);
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "HeartContainer"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "HeartContainer"));
                        break;
                    case "key":
                        item = new Key(X,Y);
                        itemCopy = new Key(X, Y);
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "Key"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "Key"));
                        break;
                    case "map":
                        item = new Map(X,Y);
                        itemCopy = new Map(X, Y);
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "Map"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "Map"));
                        break;
                    case "ruby":
                        item = new Ruby( X,Y);
                        itemCopy = new Ruby(X, Y);
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "Ruby"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "Ruby"));
                        break;
                    case "triforce":
                        item = new Triforce( X,Y);
                        itemCopy = new Triforce(X, Y);
                        triforce_RoomID = mapID;
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "Triforce"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "Triforce"));
                        break;
                    case "crown":
                        item = new Crown(X, Y);
                        itemCopy = new Crown(X, Y);
                        crown_RoomID = mapID;
                        inRoomItems.Add(new Tuple<IItemSprite, string>(item, "Crown"));
                        inRoomItemsCopy.Add(new Tuple<IItemSprite, string>(item, "Crown"));
                        break;
                }

            }
        }


        // reload item to restart
        public void ResetAllItems()
        {
            AllItemInRoom = new List<Tuple<IItemSprite, string>>[MAP_COUNT];

            inRoomItems.Clear();
            for (int i = 0; i < MAP_COUNT; i++)
            {
                Tuple<IItemSprite, string>[] Array = new Tuple<IItemSprite, string>[AllItemInRoomCpoy[i].Count];
                AllItemInRoomCpoy[i].CopyTo(Array);
                for (int j = 0; j < AllItemInRoomCpoy[i].Count; j++)
                {
                    inRoomItems.Add(Array[j]);
                }

                AllItemInRoom[i] = inRoomItems;

                inRoomItems = new List<Tuple<IItemSprite, string>>();
            }
        }
        static public int getTriforceRoom()
        {

            return triforce_RoomID;
        }
        static public int getCrownRoom()
        {

            return crown_RoomID;
        }

        public List<Tuple<IItemSprite, string>> GetItemList()
        {
           return AllItemInRoom[CurrentMapID - 1];
        }
        public void setRoomID(int id) {

            CurrentMapID = id;
        }
        public void Previous()
        {
            CurrentMapID--;
            if (CurrentMapID < 1)
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



    }
}
