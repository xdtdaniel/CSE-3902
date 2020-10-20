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
using Game1.Code.Item.ItemFactory;
using Game1.Code.Item.ItemSprite;
using Microsoft.Xna.Framework.Content;
using System.Reflection;

namespace Game1.Code.LoadFile
{
    /*
     * this is load item class used to initialize all items in the room
     */
    class LoadItem
    {
        private int MAX_COLUMNS = 32;
        private int multiplier = 8;
        private double scale = 2;
        private Vector2 startPos;
        private int X;
        private int Y;          
        List<Tuple<int, int, string>> RoomItemList;
        private List<Tuple<IItemSprite, string>> inRoom = new List<Tuple<IItemSprite, string>>();

        private static LoadItem instance = new LoadItem();

        public static LoadItem Instance
        {
            get
            {
                return instance;
            }
        }

        private LoadItem()
        {
            multiplier = LoadAll.Instance.multiplier;
            scale = LoadAll.Instance.scale;
            startPos = LoadAll.Instance.startPos;
        }
      

        public void LoadRoomItem(string mapName)
        {
     
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
            inRoom.Clear();//?
            for (int index = 0; index < RoomItemList.Count; index++)
            {

                 X = (int)(RoomItemList[index].Item1 * multiplier * scale);
                 Y = (int)(RoomItemList[index].Item2 * multiplier * scale);

                location = new Vector2(X, Y);
                IItemSprite item;

                switch (RoomItemList[index].Item3)
                {
                    case "arrow":
                        item = new Arrow(X, Y);
                        inRoom.Add(new Tuple<IItemSprite, string>(item, "arrow"));
                       
                        break;
                    case "bomb":
                        item = new Bomb( X, Y);
                        inRoom.Add(new Tuple<IItemSprite, string>(item, "bomb"));
                        break;
                    case "boomerang":
                        item = new Boomerang( X, Y);
                        inRoom.Add(new Tuple<IItemSprite, string>(item, "boomerang"));
                        break;
                    case "bow":
                        item = new Bow(X,Y);
                        inRoom.Add(new Tuple<IItemSprite, string>(item, "bow"));
                        break;
                    case "clock":
                        item = new Clock(X, Y);
                        inRoom.Add(new Tuple<IItemSprite, string>(item, "clock"));
                        break;
                    case "compass":
                        item = new Compass(X, Y);
                        inRoom.Add(new Tuple<IItemSprite, string>(item, "compass"));
                        break;
                    case "fairy":
                        item = new Fairy(X,Y);
                        inRoom.Add(new Tuple<IItemSprite, string>(item, "fairy"));
                        break;
                    case "heart":
                        item = new Heart(X,Y);
                        inRoom.Add(new Tuple<IItemSprite, string>(item, "heart"));
                        break;
                    case "heartcontainer":
                        item = new HeartContainer(X, Y);
                        inRoom.Add(new Tuple<IItemSprite, string>(item, "heart_container"));//from item factory
                        break;
                    case "key":
                        item = new Key(X,Y);
                        inRoom.Add(new Tuple<IItemSprite, string>(item, "key"));
                        break;
                    case "map":
                        item = new Map(X,Y);
                        inRoom.Add(new Tuple<IItemSprite, string>(item, "map"));
                        break;
                    case "ruby":
                        item = new Ruby( X,Y);
                        inRoom.Add(new Tuple<IItemSprite, string>(item, "ruby"));
                        break;
                    case "triforce":
                        item = new Triforce( X,Y);
                        inRoom.Add(new Tuple<IItemSprite, string>(item, "triforce"));
                        break;
                }

            }

         
        }

        public List<Tuple<IItemSprite, string>> GetItemList()
        {
            return inRoom;
        }
    }
}
