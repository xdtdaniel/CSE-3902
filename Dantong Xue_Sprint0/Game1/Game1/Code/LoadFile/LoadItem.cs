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

        private class Cell
        {
            private int column { get; set; }
            private int row { get; set; }
            private string element { get; set; }

        }
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

                IItemSprite itemToDraw;

                switch (RoomItemList[index].Item3)
                {
                    case "arrow":
                        itemToDraw = ItemSpriteFactory.Instance.CreateArrow();
                        itemToDraw.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        break;
                    case "bomb":
                        itemToDraw = ItemSpriteFactory.Instance.CreateBomb();
                        itemToDraw.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        break;
                    case "boomerang":
                        itemToDraw = ItemSpriteFactory.Instance.CreateBoomerang();
                        itemToDraw.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        break;
                    case "bow":
                        itemToDraw = ItemSpriteFactory.Instance.CreateBow();
                        itemToDraw.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        break;
                    case "clock":
                        itemToDraw = ItemSpriteFactory.Instance.CreateClock();
                        itemToDraw.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        break;
                    case "compass":
                        itemToDraw = ItemSpriteFactory.Instance.CreateCompass();
                        itemToDraw.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        break;
                    case "fairy":
                        itemToDraw = ItemSpriteFactory.Instance.CreateFairy();
                        itemToDraw.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        break;
                    case "heart":
                        itemToDraw = ItemSpriteFactory.Instance.CreateHeart();
                        itemToDraw.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        break;
                    case "heartcontainer":
                        itemToDraw = ItemSpriteFactory.Instance.CreateHeartContainer();
                        itemToDraw.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        break;
                    case "key":
                        itemToDraw = ItemSpriteFactory.Instance.CreateKey();
                        itemToDraw.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        break;
                    case "map":
                        itemToDraw = ItemSpriteFactory.Instance.CreateMap();
                        itemToDraw.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        break;
                    case "ruby":
                        itemToDraw = ItemSpriteFactory.Instance.CreateRuby();
                        itemToDraw.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        break;
                    case "triforce":
                        itemToDraw = ItemSpriteFactory.Instance.CreateTriforce();
                        itemToDraw.Draw(spriteBatch, (int)location.X, (int)location.Y);
                        break;
                }

            }



        }



    }
}
