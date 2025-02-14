﻿using System;
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
        private List<Rectangle> leftArrows;
        private List<Rectangle> rightArrows;
        private List<Rectangle> upArrows;
        private List<Rectangle> downArrows;

        // designated for level 21
        private List<Rectangle> unlock1;
        private List<Rectangle> unlock2;
        private List<Rectangle> unlock3;
        private List<Rectangle> unlock4;


        private Dictionary<string, List<Rectangle>> artifacts;

        public void LoadOneMap(string mapName) 
        
        {
            startPos = LoadAll.Instance.startPos;
            blocksListToDraw = new List<Tuple<IBlock, Vector2>>();

            // initialization of lists and artifacts dictionary

            blocks = new List<Rectangle>();
            holes = new List<Rectangle>();
            openDoors = new List<Rectangle>();
            shutDoors = new List<Rectangle>();
            lockedDoors = new List<Rectangle>();
            bombWalls = new List<Rectangle>();
            leftArrows = new List<Rectangle>();
            rightArrows = new List<Rectangle>();
            upArrows = new List<Rectangle>();
            downArrows = new List<Rectangle>();
            unlock1 = new List<Rectangle>();
            unlock2 = new List<Rectangle>();
            unlock3 = new List<Rectangle>();
            unlock4 = new List<Rectangle>();
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

            int doorPositionOffset = 12;
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
                        holes.Add(blockToDraw.GetRectangle(new Vector2(location.X, (float)(location.Y - doorPositionOffset * scale / 2))));
                        break;
                    case "holeLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftHole();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        holes.Add(blockToDraw.GetRectangle(new Vector2((float)(location.X - doorPositionOffset * scale / 2), location.Y)));
                        break;
                    case "holeRight":
                        blockToDraw = BlockFactory.Instance.CreateRightHole();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        holes.Add(blockToDraw.GetRectangle(new Vector2((float)(location.X + doorPositionOffset * scale / 2), location.Y)));
                        break;
                    case "holeBack":
                        blockToDraw = BlockFactory.Instance.CreateBackHole();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        holes.Add(blockToDraw.GetRectangle(new Vector2(location.X, (float)(location.Y + doorPositionOffset * scale / 2))));
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

                    case "entrance":
                        blockToDraw = BlockFactory.Instance.CreateBackOpenDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        blocks.Add(blockToDraw.GetRectangle(location));
                        break;
                    // the collision object for open doors should be a little smaller than normal, more natural this way
                    case "openDoorFront":
                        blockToDraw = BlockFactory.Instance.CreateFrontOpenDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        openDoors.Add(blockToDraw.GetRectangle(new Vector2(location.X, (float)(location.Y - doorPositionOffset * scale))));
                        break;
                    case "openDoorLeft":
                        blockToDraw = BlockFactory.Instance.CreateLeftOpenDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        openDoors.Add(blockToDraw.GetRectangle(new Vector2((float)(location.X - doorPositionOffset * scale), location.Y)));
                        break;
                    case "openDoorRight":
                        blockToDraw = BlockFactory.Instance.CreateRightOpenDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        openDoors.Add(blockToDraw.GetRectangle(new Vector2((float)(location.X + doorPositionOffset * scale), location.Y)));
                        break;
                    case "openDoorBack":
                        blockToDraw = BlockFactory.Instance.CreateBackOpenDoor();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        openDoors.Add(blockToDraw.GetRectangle(new Vector2(location.X, (float)(location.Y + doorPositionOffset * scale))));
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
                    case "stairBack":
                        blockToDraw = BlockFactory.Instance.CreateGreyWall();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        stairs.Add(blockToDraw.GetRectangle(new Vector2(location.X, (float)(location.Y - multiplier * scale))));
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
                    case "leftArrow":
                        blockToDraw = BlockFactory.Instance.CreateLeftArrow();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        leftArrows.Add(new Rectangle((int)(location.X + 8 * LoadAll.Instance.scale), (int)(location.Y + 8 * LoadAll.Instance.scale), 6, 6));
                        break;
                    case "rightArrow":
                        blockToDraw = BlockFactory.Instance.CreateRightArrow();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        rightArrows.Add(new Rectangle((int)(location.X + 8 * LoadAll.Instance.scale), (int)(location.Y + 8 * LoadAll.Instance.scale), 6, 6));
                        break;
                    case "upArrow":
                        blockToDraw = BlockFactory.Instance.CreateUpArrow();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        upArrows.Add(new Rectangle((int)(location.X + 8 * LoadAll.Instance.scale), (int)(location.Y + 8 * LoadAll.Instance.scale), 6, 6));
                        break;
                    case "downArrow":
                        blockToDraw = BlockFactory.Instance.CreateDownArrow();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        downArrows.Add(new Rectangle((int)(location.X + 8 * LoadAll.Instance.scale), (int)(location.Y + 8 * LoadAll.Instance.scale), 6, 6));
                        break;
                    case "unlock_1":
                        blockToDraw = BlockFactory.Instance.CreateFlatBlock();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        unlock1.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "unlock_2":
                        blockToDraw = BlockFactory.Instance.CreateFlatBlock();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        unlock2.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "unlock_3":
                        blockToDraw = BlockFactory.Instance.CreateFlatBlock();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        unlock3.Add(blockToDraw.GetRectangle(location));
                        break;
                    case "unlock_4":
                        blockToDraw = BlockFactory.Instance.CreateFlatBlock();
                        blocksListToDraw.Add(new Tuple<IBlock, Vector2>(blockToDraw, location));
                        unlock4.Add(blockToDraw.GetRectangle(location));
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
            artifacts.Add("leftArrows", leftArrows);
            artifacts.Add("rightArrows", rightArrows);
            artifacts.Add("upArrows", upArrows);
            artifacts.Add("downArrows", downArrows);
            artifacts.Add("unlock1", unlock1);
            artifacts.Add("unlock2", unlock2);
            artifacts.Add("unlock3", unlock3);
            artifacts.Add("unlock4", unlock4);
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

        public List<Rectangle> GetBlocks()
        {
            return blocks;
        }
    }
}
