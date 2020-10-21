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

        private LoadAll()
        {
            multiplier = 8;
            scale = 3;
            startPos = new Vector2(0, 0);
            currMapID = 1;
            isSwitched = new List<bool>(new bool[MAP_COUNT + 1]);
        }
        private int currMapID = 1;

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

        public void SwitchToHole()
        {
            isSwitched[currMapID] = true;
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
            return LoadMap.Instance.GetMovableBlocks();
        }

        public int GetCurrentMapID() {
            return currMapID;
        }

    }


}
