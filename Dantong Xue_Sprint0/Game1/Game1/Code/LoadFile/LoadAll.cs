using Game1.Code.Item.ItemInterface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game1.Code.LoadFile
{
    class LoadAll
    {

        private static LoadAll instance = new LoadAll();

        public static LoadAll Instance
        {
            get
            {
                return instance;
            }
        }

        private List<bool> isSwitched;
        private List<int> hasAlternative;
        private Color mapColor = Color.White;
        private List<int> isUnlocked;
        private int currMapID = 1;
        public bool noEnemy = false;
        private List<IBlock> movables;
        // original 18
        public const int MAP_COUNT = 21;
        private RoomAdjacencyList roomAdjacencyList;
        private List<Tuple<IBlock, Vector2>> oldRoomMapBlocksToDraw;
        private Game1 game1;
        private const int defaultMultiplier = 8;
        private const int defaultScale = 3;
        private const int arrowLevelID = 21;

        public int multiplier { get; set; }
        public double scale { get; set; }
        public Vector2 startPos;

        /* 
         * This corresponds to the door status for the room.
         * if the door has a lock/unlock feature, this 
         * will be useful.
         * 
         * Specifically, binary (0000) represents doors in default status
         * Each digit corresponds to up, left, down, right four doors
         * 
         * If up door is unlocked, the binary will become 1000, or 8 in dec
         * 
         */



        private LoadAll()
        {
            multiplier = defaultMultiplier;
            scale = defaultScale;
            startPos = new Vector2(0, 56 * (int)scale);
            currMapID = 17;
            isSwitched = new List<bool>(new bool[MAP_COUNT + 1]);
            isUnlocked = new List<int>(new int[MAP_COUNT + 1]);

            // those values are hard-coded and corresponding to the maps we have
            hasAlternative = new List<int>() { 5, 8, 9, 10, 12, 13, 14};

            roomAdjacencyList = new RoomAdjacencyList();
            oldRoomMapBlocksToDraw = new List<Tuple<IBlock, Vector2>>();
        }

        public void GetGameObject(Game1 g)
        {
            game1 = g;
        }

        private void ScrollRoom(string scrollingDirection)
        {
            // change starting position for scrolling transition
            switch (scrollingDirection)
            {
                case "left":
                    startPos.X -= (float)(256 * scale);
                    break;
                case "right":
                    startPos.X += (float)(256 * scale);
                    break;
                case "up":
                    startPos.Y -= (float)(176 * scale);
                    break;
                case "down":
                    startPos.Y += (float)(176 * scale);
                    break;
            }
        }


        private string GetRoomFileName(int mapID)
        {
            string mapName;
            if (isSwitched[mapID])
            {
                mapName = mapID.ToString() + "_" + Convert.ToString(isUnlocked[mapID], 2).PadLeft(4, '0') + "_after.csv";
            }
            else
            {
                mapName = mapID.ToString() + "_" + Convert.ToString(isUnlocked[mapID], 2).PadLeft(4, '0') + ".csv";
            }

            return mapName;
        }

        public void LoadRoom()
        {
            LoadMap.Instance.LoadOneMap(GetRoomFileName(currMapID));
        }

        public void ChangeRoom(string door)
        {
            int nextRoomID = roomAdjacencyList.GetAdjacency(currMapID, door);
            
            if (nextRoomID != 0)
            {
                oldRoomMapBlocksToDraw = LoadMap.Instance.GetBlocksToDraw();
                ScrollRoom(door);
                game1.camera.UpdateMovingState(door);
                currMapID = nextRoomID;
                LoadRoom();
            }
        }


        public void PrevMap()
        {
            currMapID -= 1;
            if (currMapID < 1)
            {
                currMapID = MAP_COUNT;
            }

            LoadRoom();
        }

        public void NextMap()
        {
            currMapID += 1;
            if (currMapID > MAP_COUNT)
            {
                currMapID = 1;
            }

            LoadRoom();
        }

        public bool SwitchToAlternative(string collideSide)
        {
            if (hasAlternative.Contains(currMapID))
            { 
                isSwitched[currMapID] = true;

                // unlock adjacent holes
                if (collideSide != "")
                {
                    UnlockAdjacentHole(collideSide);
                }
                return true;
            }
            return false;
        }

        private void UnlockAdjacentHole(string collideSide)
        {
            string holeDirection = "";
            switch (collideSide)
            {
                case "up":
                    holeDirection = "down";
                    break;
                case "down":
                    holeDirection = "up";
                    break;
                case "left":
                    holeDirection = "right";
                    break;
                case "right":
                    holeDirection = "left";
                    break;
            }
            isSwitched[roomAdjacencyList.GetAdjacency(currMapID, holeDirection)] = true;
        }



        public Dictionary<string, List<Rectangle>> GetMapArtifacts()
        {
            return LoadMap.Instance.GetArtifacts();
        }

        public void ResetRoomID()
        {
            currMapID = 17;
        }

        public List<List<Tuple<IBlock, Vector2>>> GetMapBlocksToDraw()
        {
            List<List<Tuple<IBlock, Vector2>>> toDraw = new List<List<Tuple<IBlock, Vector2>>>();
            toDraw.Add(oldRoomMapBlocksToDraw);
            toDraw.Add(LoadMap.Instance.GetBlocksToDraw());
            return toDraw;
        }

        public List<IBlock> GetMovableBlocks()
        {
            movables = LoadMap.Instance.GetMovableBlocks();
            return movables;
        }

        private int GetHoleCount()
        {
            Dictionary<string, List<Rectangle>> artifacts = LoadMap.Instance.GetArtifacts();
            return artifacts["bombWalls"].Count;
        }

        public int GetCurrentMapID() 
        {
            return currMapID;
        }

        public void UnderWorldTransition()
        {
            // switch back and forth from the undr
            if (currMapID == 1)
            {
                currMapID = 3;
            }
            else if (currMapID == 3)
            {
                currMapID = 1;
            }

            LoadRoom();
        }

        public void SetEnemyStatus(bool enemyStatus)
        {
            noEnemy = enemyStatus;

            if (noEnemy && movables.Count == 0 && GetHoleCount() == 0)
            {
                SwitchToAlternative("");
                LoadRoom();
            }
        }

        public void UnlockDoor(string door)
        {
            if (door != "") 
            { 
                switch (door)
                {
                    case "up":
                        isUnlocked[currMapID] += 8;
                        break;
                    case "left":
                        isUnlocked[currMapID] += 4;
                        break;
                    case "down":
                        isUnlocked[currMapID] += 2;
                        break;
                    case "right":
                        isUnlocked[currMapID] += 1;
                        break;
                }


                if (currMapID != arrowLevelID)
                {
                    UnlockAdjacentDoor(door);
                }
                

                LoadRoom();
            }
        }

        private void UnlockAdjacentDoor(string door)
        {
            if (door != "")
            {
                int nextRoomID = roomAdjacencyList.GetAdjacency(currMapID, door);
                if (nextRoomID != 0)
                {
                    switch (door)
                    {
                        case "up":
                            isUnlocked[nextRoomID] += 2;
                            break;
                        case "left":
                            isUnlocked[nextRoomID] += 1;
                            break;
                        case "down":
                            isUnlocked[nextRoomID] += 8;
                            break;
                        case "right":
                            isUnlocked[nextRoomID] += 4;
                            break;
                    }
                }
                
            }
        }

        public void ChangeMapColor(Color color)
        {
            mapColor = color;
        }

        public Color GetMapColor()
        {
            return mapColor;
        }

        public void ResetMap()
        {
            // startPos = new Vector2(0, 56 * (int)scale);
            currMapID = 17;
            isSwitched = new List<bool>(new bool[MAP_COUNT + 1]);
            isUnlocked = new List<int>(new int[MAP_COUNT + 1]);

            // those values are hard-coded and corresponding to the maps we have
            hasAlternative = new List<int>() { 5, 8, 9, 10, 12, 13, 14 };

            roomAdjacencyList = new RoomAdjacencyList();
            oldRoomMapBlocksToDraw = new List<Tuple<IBlock, Vector2>>();

            LoadRoom();

        }
    }
}
