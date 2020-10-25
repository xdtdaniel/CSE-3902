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

        private LoadAll()
        {
            multiplier = 8;
            scale = 3;
            startPos = new Vector2(0, 0);
            currMapID = 17;
            isSwitched = new List<bool>(new bool[MAP_COUNT + 1]);

            // those values are hard-coded and corresponding to the maps we have
            hasAlternative = new List<int>() { 8, 9, 10, 13, 14};

            
        }
        private int currMapID = 1;
        public bool noEnemy = false;
        private List<IBlock> movables;

        private const int MAP_COUNT = 18;

        public int multiplier { get; set; }
        public double scale { get; set; }
        public Vector2 startPos { get; set; }

        public void LoadRoom()
        {
            string mapName;
            if (isSwitched[currMapID])
            {
                mapName = currMapID.ToString() + "_after.csv";
            }
            else
            {
                mapName = currMapID.ToString() + ".csv";
            }
            
            LoadMap.Instance.LoadOneMap(mapName);
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

    }


}
