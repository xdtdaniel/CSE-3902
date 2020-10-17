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
            currMapID = 2;
        }

        private List<string> mapList;
        private int currMapID = 1;
        private Dictionary<string, List<Rectangle>> artifacts;

        public int multiplier { get; set; }
        public int scale { get; set; }
        public Vector2 startPos { get; set; }

        public void LoadRoom(SpriteBatch currSpriteBatch)
        {
            string mapName = currMapID.ToString() + ".csv";
            artifacts = LoadMap.Instance.LoadOneMap(currSpriteBatch, mapName);
        }

        public void ChangeMap(int mapID)
        {
            currMapID = mapID;
        }

        public Dictionary<string, List<Rectangle>> GetArtifacts()
        {
            return artifacts;
        }


    }


}
