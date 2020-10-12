using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.DirectoryServices.ActiveDirectory;
using Game1.Code.Block.BlockFactory;
using System.Drawing;
using Microsoft.Xna.Framework;

namespace Game1.Code.LoadFile
{
    class LoadFile
    {
        int MAX_ROWS = 23;
        int MAX_COLUMNS = 26;
        private class Cell {
            private int column { get; set; }
            private int row { get; set; }            
            private string element { get; set; }

        }
        List<Tuple<int, int, string>> mapElementList;

        public LoadFile() {
            mapElementList = new List<Tuple<int, int, string>>();
            StreamReader streamReader = new StreamReader("PartialLevelOne.csv");
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
            Vector2 location;
            
            //switch case for each string
            for (int index = 0;index < mapElementList.Count; index++)
            {
                location.X = mapElementList[index].Item1;
                location.Y = mapElementList[index].Item2;
                switch (mapElementList[index].Item3)
                {
                    case "black": 
                        BlockFactory.Instance.CreateBlackBlock(location);// need to pass row anad columbs and multiply by the block's width and height?
                        break;
                    case "block":
                        BlockFactory.Instance.CreateFlatBlock(location);
                        break;
                    case "dragon":
                        BlockFactory.Instance.CreateDragon(location);
                        break;
                    case "dragonBlue":
                        BlockFactory.Instance.CreateBlueDragon(location);
                        break;
                    case "fire":
                        BlockFactory.Instance.CreateFire(location);
                        break;
                    case "fish":
                        BlockFactory.Instance.CreateFish(location);
                        break;
                    case "fishBlue":
                        BlockFactory.Instance.CreateBlueFish(location);
                        break;
                    case "floatBlock":
                        BlockFactory.Instance.CreateFloatBlock(location);
                        break;
                    case "grey":
                        BlockFactory.Instance.CreateGreyBlock(location);
                        break;
                    case "holeFront":
                        BlockFactory.Instance.CreateFrontHole(location);
                        break;
                    case "holeLeft":
                        BlockFactory.Instance.CreateLeftHole(location);
                        break;
                    case "holeRight":
                        BlockFactory.Instance.CreateRightHole(location);
                        break;
                    case "holeBack":
                        BlockFactory.Instance.CreateBackHole(location);
                        break;
                    case "lockedDoorFront":
                        BlockFactory.Instance.CreateFrontLockedDoor(location);
                        break;
                    case "lockedDoorLeft":                       
                        BlockFactory.Instance.CreateLeftLockedDoor(location);
                        break;
                    case "lockedDoorRight":
                        BlockFactory.Instance.CreateRightLockedDoor(location);
                        break;
                    case "lockedDoorBack":
                        BlockFactory.Instance.CreateBackLockedDoor(location);
                        break;
                    case "openDoorFront":
                        BlockFactory.Instance.CreateFrontOpenDoor(location);
                        break;
                    case "openDoorLeft":
                        BlockFactory.Instance.CreateLeftOpenDoor(location);
                        break;
                    case "openDoorRight":
                        BlockFactory.Instance.CreateRightOpenDoor(location);
                        break;
                    case "openDoorBack":
                        BlockFactory.Instance.CreateBackOpenDoor(location);
                        break;
                    case "shutDoorFront":
                        BlockFactory.Instance.CreateFrontShutDoor(location);
                        break;
                    case "shutDoorLeft":
                        BlockFactory.Instance.CreateLeftShutDoor(location);
                        break;
                    case "shutDoorRight":
                        BlockFactory.Instance.CreateRightShutDoor(location);
                        break;
                    case "shutDoorBack":
                        BlockFactory.Instance.CreateBackShutDoor(location);
                        break;
                    case "sandFloor":
                        BlockFactory.Instance.CreateSandFloor(location);
                        break;
                    case "stair":
                        BlockFactory.Instance.CreateStair(location);
                        break;
                    case "wallFront":
                        BlockFactory.Instance.CreateFrontWall(location);
                        break;
                    case "wallLeft":
                        BlockFactory.Instance.CreateLeftWall(location);
                        break;
                    case "wallRight":
                        BlockFactory.Instance.CreateRightWall(location);
                        break;
                    case "wallBack":
                        BlockFactory.Instance.CreateBackWall(location);
                        break;
                    case "wallBW":
                        BlockFactory.Instance.CreateBWWall(location);
                        break;
                    case "wallGrey":
                        BlockFactory.Instance.CreateGreyWall(location);
                        break;
                    case "water":
                        BlockFactory.Instance.CreateWater(location);
                        break;


                }

            }



        }





    }
}
