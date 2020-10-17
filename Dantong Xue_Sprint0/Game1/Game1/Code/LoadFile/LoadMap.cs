using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.DirectoryServices.ActiveDirectory;
using Game1.Code.Block.BlockFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;

namespace Game1.Code.LoadFile
{
    class LoadMap
    {
        private int MAX_COLUMNS = 32;
        /*
            The default room layout has a size of 256*176
            Also, the sizes of blocks are either 16*16 or 32*32 (for doors).
            Grids are splitted in a 8*8 order as shown in csv file.
            In this case, we shall expect to have 22 rows and 32 columns.
        */
        private int multiplier;
        private int scale;
        private Vector2 startPos;

        private SpriteBatch spriteBatch;

        private class Cell 
        {
            private int column { get; set; }
            private int row { get; set; }            
            private string element { get; set; }

        }


        List<Tuple<int, int, string>> mapElementList;

        private static LoadMap instance = new LoadMap();

        public static LoadMap Instance
        {
            get
            {
                return instance;
            }
        }

        private LoadMap()
        {
            multiplier = LoadAll.Instance.multiplier;
            scale = LoadAll.Instance.scale;
            startPos = LoadAll.Instance.startPos;
        }


        private List<Rectangle> blocks;
        private List<Rectangle> holes;
        private List<Rectangle> openDoors;
        private List<Rectangle> shutDoors;
        private List<Rectangle> lockedDoors;
        private List<Rectangle> stairs;

        private Dictionary<string, List<Rectangle>> artifacts;

        public Dictionary<string, List<Rectangle>> LoadOneMap(SpriteBatch currSpriteBatch, string mapName) 
        
        {

            // initialization of lists and artifacts dictionary

            blocks = new List<Rectangle>();
            holes = new List<Rectangle>();
            openDoors = new List<Rectangle>();
            shutDoors = new List<Rectangle>();
            lockedDoors = new List<Rectangle>();
            stairs = new List<Rectangle>();

            artifacts = new Dictionary<string, List<Rectangle>>();

            spriteBatch = currSpriteBatch;
            mapElementList = new List<Tuple<int, int, string>>();

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
                        mapElementList.Add(new Tuple<int, int, string>(cell_x, cell_y, strList[i]));
                    }
                    
                    cell_x++;
                }
                cell_y++;

            }


            IBlock room;
            room = BlockFactory.Instance.CreateRoom();
            room.DrawBlock(spriteBatch, startPos);

            Vector2 location;
            
            //switch case for each string
            for (int index = 0;index < mapElementList.Count; index++)
            {
                
                float X = mapElementList[index].Item1 * multiplier * scale + startPos.X;
                float Y = mapElementList[index].Item2 * multiplier * scale + startPos.Y;
                location = new Vector2(X, Y);

                IBlock blockToDraw;

                Console.WriteLine(mapElementList[index].Item3);

                switch (mapElementList[index].Item3)
                {
                    case "black":
                        blockToDraw = BlockFactory.Instance.CreateBlackBlock();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "block":
                        blockToDraw = BlockFactory.Instance.CreateFlatBlock();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "dragon":
                        blockToDraw = BlockFactory.Instance.CreateDragon();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "dragonBlue":
                        blockToDraw = BlockFactory.Instance.CreateBlueDragon();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "fire":
                        blockToDraw = BlockFactory.Instance.CreateFire();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "fish":
                        blockToDraw = BlockFactory.Instance.CreateFish();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "fishBlue":
                        blockToDraw = BlockFactory.Instance.CreateBlueFish();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "floatBlock":
                        blockToDraw = BlockFactory.Instance.CreateFloatBlock();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "grey":
                        blockToDraw = BlockFactory.Instance.CreateGreyBlock();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "holeFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontHole();
                        holes.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "holeLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftHole();
                        holes.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "holeRight":
                        blockToDraw = BlockFactory.Instance.CreateRightHole();
                        holes.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "holeBack":
                        blockToDraw = BlockFactory.Instance.CreateBackHole();
                        holes.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "lockedDoorFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontLockedDoor();
                        lockedDoors.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "lockedDoorLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftLockedDoor();
                        lockedDoors.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "lockedDoorRight":
                        blockToDraw = BlockFactory.Instance.CreateRightLockedDoor();
                        lockedDoors.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "lockedDoorBack":
                        blockToDraw = BlockFactory.Instance.CreateBackLockedDoor();
                        lockedDoors.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "openDoorFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontOpenDoor();
                        openDoors.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "openDoorLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftOpenDoor();
                        openDoors.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "openDoorRight":
                        blockToDraw = BlockFactory.Instance.CreateRightOpenDoor();
                        openDoors.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "openDoorBack":
                        blockToDraw = BlockFactory.Instance.CreateBackOpenDoor();
                        openDoors.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "shutDoorFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontShutDoor();
                        shutDoors.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "shutDoorLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftShutDoor();
                        shutDoors.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "shutDoorRight":
                        blockToDraw = BlockFactory.Instance.CreateRightShutDoor();
                        shutDoors.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "shutDoorBack":
                        blockToDraw = BlockFactory.Instance.CreateBackShutDoor();
                        shutDoors.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "sandFloor":
                        blockToDraw = BlockFactory.Instance.CreateSandFloor();
                        blockToDraw.DrawBlock(spriteBatch, location);
                        break;
                    case "stair":
                        blockToDraw = BlockFactory.Instance.CreateStair();
                        stairs.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "wallFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontWall();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "wallLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftWall();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "wallRight":
                        blockToDraw = BlockFactory.Instance.CreateRightWall();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "wallBack":
                        blockToDraw = BlockFactory.Instance.CreateBackWall();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "wallBW":
                        blockToDraw = BlockFactory.Instance.CreateBWWall();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "wallGrey":
                        blockToDraw = BlockFactory.Instance.CreateGreyWall();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "water":
                        blockToDraw = BlockFactory.Instance.CreateWater();
                        blocks.Add(blockToDraw.DrawBlock(spriteBatch, location));
                        break;
                    case "wall_1":
                        blocks.Add(new Rectangle((int)location.X, (int)location.Y, 112 * LoadAll.Instance.scale, 32 * LoadAll.Instance.scale));
                        break;
                    case "wall_2":
                        blocks.Add(new Rectangle((int)location.X, (int)location.Y, 32 * LoadAll.Instance.scale, 40 * LoadAll.Instance.scale));
                        break;

                }

            }

            artifacts.Add("blocks", blocks);
            artifacts.Add("holes", holes);
            artifacts.Add("openDoors", openDoors);
            artifacts.Add("shutDoors", shutDoors);
            artifacts.Add("lockedDoors", lockedDoors);
            artifacts.Add("stairs", stairs);

            return artifacts;

        }





    }
}
