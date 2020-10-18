using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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

        private LoadAll()
        {
            multiplier = 8;
            scale = 3;
            startPos = new Vector2(0, 0);
            currMapID = 1;
        }

        private List<string> mapList;
        private int currMapID = 1;

        public int multiplier { get; set; }
        public int scale { get; set; }
        public Vector2 startPos { get; set; }

        public void LoadRoom()
        {
            string mapName = currMapID.ToString() + ".csv";
            LoadMap.Instance.LoadOneMap(mapName);
            string enemyMapName = currMapID.ToString() + "_enemy.csv";
            LoadEnemy.Instance.LoadAllEnemy(enemyMapName);
        }

        public void ChangeMap(int mapID)
        {
            currMapID = mapID;
        }

        public Dictionary<string, List<Rectangle>> GetMapArtifacts()
        {
            return LoadMap.Instance.GetArtifacts();
        }

        public List<Tuple<IBlock, Vector2>> GetMapBlocksToDraw()
        {
            return LoadMap.Instance.GetBlocksToDraw();
        }


    }


}
