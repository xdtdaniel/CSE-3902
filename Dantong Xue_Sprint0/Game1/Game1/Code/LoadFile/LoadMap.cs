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
using Game1.Code.Block;
using System.Diagnostics;

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
        private double scale;
        private Vector2 startPos;

        private List<Tuple<IBlock, Vector2>> blocksListToDraw;


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
        private List<Rectangle> bombWalls;
        private List<IBlock> movableBlocksList;

        private Dictionary<string, List<Rectangle>> artifacts;

        public void LoadOneMap(string mapName) 
        
        {
            blocksListToDraw = new List<Tuple<IBlock, Vector2>>();

            // initialization of lists and artifacts dictionary

            blocks = new List<Rectangle>();
            holes = new List<Rectangle>();
            openDoors = new List<Rectangle>();
            shutDoors = new List<Rectangle>();
            lockedDoors = new List<Rectangle>();
            bombWalls = new List<Rectangle>();

            stairs = new List<Rectangle>();

            artifacts = new Dictionary<string, List<Rectangle>>();

            mapElementList = new List<Tuple<int, int, string>>();

            movableBlocksList = new List<IBlock>();

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
            blocksListToDraw.Add(new Tuple<IBlock, Vector2>(room, startPos));

            Vector2 location;
            
            //switch case for each string
            for (int index = 0;index < mapElementList.Count; index++)
            {
                
                float X = (float)(mapElementList[index].Item1 * multiplier * scale + startPos.X);
                float Y = (float)(mapElementList[index].Item2 * multiplier * scale + startPos.Y);
                location = new Vector2(X, Y);

                IBlock blockToDraw;
                IBlock movable;

                Console.WriteLine(mapElementList[index].Item3);

                switch (mapElementList[index].Item3)
                {
                    case "black":
                        blockToDraw = BlockFactory.Instance.CreateBlackBlock();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        // blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "block":
                        blockToDraw = BlockFactory.Instance.CreateFlatBlock();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        break;
                    case "dragon":
                        blockToDraw = BlockFactory.Instance.CreateDragon();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "dragonBlue":
                        blockToDraw = BlockFactory.Instance.CreateBlueDragon();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "fire":
                        blockToDraw = BlockFactory.Instance.CreateFire();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "fish":
                        blockToDraw = BlockFactory.Instance.CreateFish();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "fishBlue":
                        blockToDraw = BlockFactory.Instance.CreateBlueFish();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "floatBlock":
                        blockToDraw = BlockFactory.Instance.CreateFloatBlock();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "grey":
                        blockToDraw = BlockFactory.Instance.CreateGreyBlock();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "holeFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontHole();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        holes.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "holeLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftHole();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        holes.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "holeRight":
                        blockToDraw = BlockFactory.Instance.CreateRightHole();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        holes.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "holeBack":
                        blockToDraw = BlockFactory.Instance.CreateBackHole();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        holes.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "lockedDoorFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontLockedDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        lockedDoors.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "lockedDoorLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftLockedDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        lockedDoors.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "lockedDoorRight":
                        blockToDraw = BlockFactory.Instance.CreateRightLockedDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        lockedDoors.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "lockedDoorBack":
                        blockToDraw = BlockFactory.Instance.CreateBackLockedDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        lockedDoors.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "openDoorFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontOpenDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        openDoors.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "openDoorLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftOpenDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        openDoors.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "openDoorRight":
                        blockToDraw = BlockFactory.Instance.CreateRightOpenDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        openDoors.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "openDoorBack":
                        blockToDraw = BlockFactory.Instance.CreateBackOpenDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        openDoors.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "shutDoorFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontShutDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        shutDoors.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "shutDoorLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftShutDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        shutDoors.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "shutDoorRight":
                        blockToDraw = BlockFactory.Instance.CreateRightShutDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        shutDoors.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "shutDoorBack":
                        blockToDraw = BlockFactory.Instance.CreateBackShutDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        shutDoors.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "sandFloor":
                        blockToDraw = BlockFactory.Instance.CreateSandFloor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        break;
                    case "stair":
                        blockToDraw = BlockFactory.Instance.CreateStair();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        stairs.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "wallFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "wallLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "wallRight":
                        blockToDraw = BlockFactory.Instance.CreateRightWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "wallBack":
                        blockToDraw = BlockFactory.Instance.CreateBackWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "wallBW":
                        blockToDraw = BlockFactory.Instance.CreateBWWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "wallGrey":
                        blockToDraw = BlockFactory.Instance.CreateGreyWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        break;
                    case "water":
                        blockToDraw = BlockFactory.Instance.CreateWater();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "movableBlock":
                        // draw a flat block first
                        blockToDraw = BlockFactory.Instance.CreateFlatBlock();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));

                        // get a movable block then
                        movable = new MovableBlock(BlockFactory.Instance.GetMovableBlockTexture(), location);
                        movableBlocksList.Add(movable);
                        break;
                    case "wall_1":
                        blocks.Add(new Rectangle((int)location.X, (int)location.Y, (int)(112 * LoadAll.Instance.scale), (int)(32 * LoadAll.Instance.scale)));
                        break;
                    case "wall_2":
                        blocks.Add(new Rectangle((int)location.X, (int)location.Y, (int)(32 * LoadAll.Instance.scale), (int)(40 * LoadAll.Instance.scale)));
                        break;
                    case "invisible":
                        blocks.Add(new Rectangle((int)location.X, (int)location.Y, (int)(16 * LoadAll.Instance.scale), (int)(16 * LoadAll.Instance.scale)));
                        break;
                    case "bombWallFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        bombWalls.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "bombWallLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        bombWalls.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "bombWallRight":
                        blockToDraw = BlockFactory.Instance.CreateRightWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        bombWalls.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "bombWallBack":
                        blockToDraw = BlockFactory.Instance.CreateBackWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        bombWalls.Add(blockToDraw.GetRectangle(location));
                        break;
                }

            }

            artifacts.Add("blocks", blocks);
            artifacts.Add("holes", holes);
            artifacts.Add("openDoors", openDoors);
            artifacts.Add("shutDoors", shutDoors);
            artifacts.Add("lockedDoors", lockedDoors);
            artifacts.Add("stairs", stairs);
            artifacts.Add("bombWalls", bombWalls);
        }

        public Dictionary<string, List<Rectangle>> GetArtifacts()
        {
            return artifacts;
        }


        public List<Tuple<IBlock, Vector2>> GetBlocksToDraw()
        {
            return blocksListToDraw;
        }

        public List<IBlock> GetMovableBlocks()
        {
            return movableBlocksList;
        }


    }
}
