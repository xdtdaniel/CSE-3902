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

        private List<int> isUnlocked;

        private LoadAll()
        {
            multiplier = 8;
            scale = 3;
            startPos = new Vector2(0, 0);
            currMapID = 17;
            isSwitched = new List<bool>(new bool[MAP_COUNT + 1]);
            isUnlocked = new List<int>(new int[MAP_COUNT + 1]);

            // those values are hard-coded and corresponding to the maps we have
            hasAlternative = new List<int>() { 5, 8, 9, 10, 13, 14};
        }
        private int currMapID = 1;
        public bool noEnemy = false;
        private List<IBlock> movables;

        private const int MAP_COUNT = 18;

        public int multiplier { get; set; }
        public double scale { get; set; }
        public Vector2 startPos { get; set; }

        private string GetRoomFileName()
        {
            string mapName;
            if (isSwitched[currMapID])
            {
                mapName = currMapID.ToString() + "_" + Convert.ToString(isUnlocked[currMapID], 2).PadLeft(4, '0') + "_after.csv";
            }
            else
            {
                mapName = currMapID.ToString() + "_" + Convert.ToString(isUnlocked[currMapID], 2).PadLeft(4, '0') + ".csv";
            }

            return mapName;
        }

        public void LoadRoom()
        {
            LoadMap.Instance.LoadOneMap(GetRoomFileName());
        }

        public void LoadRoomItem() 
        {
            string itemMapName  = currMapID.ToString()+"_item.csv";
            LoadItem.Instance.LoadRoomItem(itemMapName);
        }

        public void PrevMap()
        {
            currMapID -= 1;
            if (currMapID < 1)
            {
                currMapID = MAP_COUNT;
            }
        }

        public void NextMap()
        {
            currMapID += 1;
            if (currMapID > MAP_COUNT)
            {
                currMapID = 1;
            }
        }

        public bool SwitchToAlternative()
        {
            if (hasAlternative.Contains(currMapID))
            { 
                isSwitched[currMapID] = true;
                return true;
            }
            return false;
        }

        public Dictionary<string, List<Rectangle>> GetMapArtifacts()
        {
            return LoadMap.Instance.GetArtifacts();
        }

        public List<Tuple<IBlock, Vector2>> GetMapBlocksToDraw()
        {
            return LoadMap.Instance.GetBlocksToDraw();
        }

        public List<IBlock> GetMovableBlocks()
        {
            movables = LoadMap.Instance.GetMovableBlocks();
            return movables;
        }

        public int GetCurrentMapID() 
        {
            return currMapID;
        }

        public void SetEnemyStatus(bool enemyStatus)
        {
            noEnemy = enemyStatus;
            Debug.WriteLine(noEnemy);

            if (noEnemy && movables.Count == 0)
            {
                SwitchToAlternative();
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

                LoadRoom();
            }
        }

    }


}
