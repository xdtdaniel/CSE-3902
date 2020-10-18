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
        private double scale = 2;
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
            roomItems = new List<IItemSprite>();
            for (int index = 0; index < RoomItemList.Count; index++)
            {

                int X = (int)(RoomItemList[index].Item1 * multiplier * scale);
                int Y = (int)(RoomItemList[index].Item2 * multiplier * scale);
                location = new Vector2(X, Y);

                IItemSprite item;

                switch (RoomItemList[index].Item3)
                {
                    case "arrow":
                        item = ItemSpriteFactory.Instance.CreateArrow();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        
                        roomItems.Add(item);
                        break;
                    case "bomb":
                        item = ItemSpriteFactory.Instance.CreateBomb();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "boomerang":
                        item = ItemSpriteFactory.Instance.CreateBoomerang();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "bow":
                        item = ItemSpriteFactory.Instance.CreateBow();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "clock":
                        item = ItemSpriteFactory.Instance.CreateClock();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "compass":
                        item = ItemSpriteFactory.Instance.CreateCompass();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "fairy":
                        item = ItemSpriteFactory.Instance.CreateFairy();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "heart":
                        item = ItemSpriteFactory.Instance.CreateHeart();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "heartcontainer":
                        item = ItemSpriteFactory.Instance.CreateHeartContainer();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "key":
                        item = ItemSpriteFactory.Instance.CreateKey();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "map":
                        item = ItemSpriteFactory.Instance.CreateKey();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "ruby":
                        item = ItemSpriteFactory.Instance.CreateRuby();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                    case "triforce":
                        item = ItemSpriteFactory.Instance.CreateTriforce();
                        item.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        roomItems.Add(item);
                        break;
                }

            }



        }
        public void UpdateAllItem()
        {
            for (int i = 0; i < roomItems.Count; i++)
            {
                roomItems[i].Update();
            }
        }



    }
}
