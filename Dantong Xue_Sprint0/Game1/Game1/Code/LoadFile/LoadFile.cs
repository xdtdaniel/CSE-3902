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

namespace Game1.Code.LoadFile
{
    class LoadFile
    {

        private int MAX_ROWS = 22;
        private int MAX_COLUMNS = 32;

        /*
            The default XNA framework has a screen size of 800*480
            Also, the sizes of blocks are either 16*16 or 32*32 (for doors).
            In this case, we shall expect to have 30 rows and 50 columns as
            we calculated 800/16=50 and 480/16=30.
        */
        private int multiplier = 8;

        private SpriteBatch spriteBatch;

        private class Cell {
            private int column { get; set; }
            private int row { get; set; }            
            private string element { get; set; }

        }
        List<Tuple<int, int, string>> mapElementList;

        private static LoadFile instance = new LoadFile();

        public static LoadFile Instance
        {
            get
            {
                return instance;
            }
        }

        private LoadFile()
        {

        }

        public void LoadMap(SpriteBatch currSpriteBatch) {
            spriteBatch = currSpriteBatch;
            mapElementList = new List<Tuple<int, int, string>>();
            StreamReader streamReader = new StreamReader("test.csv");
            string line;
            string[] str = new string[MAX_COLUMNS];
            int cell_x = 0;
            int cell_y = 0;
            //each loop add 1 line to list
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();
                //seperate a line by comma. this string array should have all strings seperately.              
                    str = line.Split(',');   

                //cell_x, and cell_y represent the postion in csv
                for (int i = 0; i < MAX_COLUMNS; i++)
                {
                    mapElementList.Add(new Tuple<int, int, string>(cell_x, cell_y, str[i]));
                    cell_x++;
                }
                cell_y++;

            }

            IBlock room;
            room = BlockFactory.Instance.CreateRoom();
            room.DrawBlock(spriteBatch, new Vector2(0, 0));

            Vector2 location;
            
            //switch case for each string
            for (int index = 0;index < mapElementList.Count; index++)
            {
                location.X = mapElementList[index].Item1 * multiplier;
                location.Y = mapElementList[index].Item2 * multiplier;
                IBlock blockToDraw;

                switch (mapElementList[index].Item3)
                {
                    case "black":
                        blockToDraw = BlockFactory.Instance.CreateBlackBlock();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "block":
                        blockToDraw = BlockFactory.Instance.CreateFlatBlock();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "dragon":
                        blockToDraw = BlockFactory.Instance.CreateDragon();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "dragonBlue":
                        blockToDraw = BlockFactory.Instance.CreateBlueDragon();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "fire":
                        blockToDraw = BlockFactory.Instance.CreateFire();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "fish":
                        blockToDraw = BlockFactory.Instance.CreateFish();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "fishBlue":
                        blockToDraw = BlockFactory.Instance.CreateBlueFish();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "floatBlock":
                        blockToDraw = BlockFactory.Instance.CreateFloatBlock();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "grey":
                        blockToDraw = BlockFactory.Instance.CreateGreyBlock();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "holeFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontHole();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "holeLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftHole();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "holeRight":
                        blockToDraw = BlockFactory.Instance.CreateRightHole();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "holeBack":
                        blockToDraw = BlockFactory.Instance.CreateBackHole();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "lockedDoorFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontLockedDoor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "lockedDoorLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftLockedDoor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "lockedDoorRight":
                        blockToDraw = BlockFactory.Instance.CreateRightLockedDoor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "lockedDoorBack":
                        blockToDraw = BlockFactory.Instance.CreateBackLockedDoor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "openDoorFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontOpenDoor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "openDoorLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftOpenDoor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "openDoorRight":
                        blockToDraw = BlockFactory.Instance.CreateRightOpenDoor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "openDoorBack":
                        blockToDraw = BlockFactory.Instance.CreateBackOpenDoor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "shutDoorFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontShutDoor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "shutDoorLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftShutDoor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "shutDoorRight":
                        blockToDraw = BlockFactory.Instance.CreateRightShutDoor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "shutDoorBack":
                        blockToDraw = BlockFactory.Instance.CreateBackShutDoor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "sandFloor":
                        blockToDraw = BlockFactory.Instance.CreateSandFloor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "stair":
                        blockToDraw = BlockFactory.Instance.CreateStair();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "wallFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontWall();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "wallLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftWall();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "wallRight":
                        blockToDraw = BlockFactory.Instance.CreateRightWall();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "wallBack":
                        blockToDraw = BlockFactory.Instance.CreateBackWall();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "wallBW":
                        blockToDraw = BlockFactory.Instance.CreateBWWall();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "wallGrey":
                        blockToDraw = BlockFactory.Instance.CreateGreyWall();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "water":
                        blockToDraw = BlockFactory.Instance.CreateWater();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;


                }

            }



        }





    }
}
