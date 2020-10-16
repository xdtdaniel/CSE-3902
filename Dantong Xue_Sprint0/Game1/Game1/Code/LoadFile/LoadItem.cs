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

namespace Game1.Code.LoadFile
{
    /*
     * this is load item class which load item to the room
     */
    class LoadItem
    {
        private int MAX_COLUMNS = 32;
        private int multiplier = 8;
        public int scale = 2;
        private SpriteBatch spriteBatch;
        private Vector2 startPos;
        private List<IItemSprite> roomItems;

        List<Tuple<int, int, string>> RoomItemList;

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


        public void LoadRoomItem(SpriteBatch currSpriteBatch)
        {
            spriteBatch = currSpriteBatch;
            RoomItemList = new List<Tuple<int, int, string>>();
            string filePath = System.IO.Path.GetFullPath("room1Item.csv");
            StreamReader streamReader = new StreamReader(filePath);
            string line;
            string[] strList = new string[MAX_COLUMNS];
            int cell_x = 0;
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
                        RoomItemList.Add(new Tuple<int, int, string>(cell_x, cell_y, strList[i]));
                    }

                    cell_x++;
                }
                cell_y++;

            }

            
            Vector2 location;
            for (int index = 0; index < RoomItemList.Count; index++)
            {

                int X = RoomItemList[index].Item1 * multiplier * scale;
                int Y = RoomItemList[index].Item2 * multiplier * scale;
                location = new Vector2(X, Y);

                IItemSprite item;

                switch (RoomItemList[index].Item3)
                {
                    case "arrow":
                        item = new Arrow();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "bomb":
                        item = new Bomb();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "boomerang":
                        item = new Boomerang();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "bow":
                        item = new Bow();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "clock":
                        item = new Clock();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "compass":
                        item = new Compass();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "fairy":
                        item = new Fairy();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "heart":
                        item = new Heart();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "heartcontainer":
                        item = new HeartContainer();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "key":
                        item = new Key();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "map":
                        item = new Map();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "ruby":
                        item = new Ruby();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "triforce":
                        item = new Triforce();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                }

            }



        }



    }
}
