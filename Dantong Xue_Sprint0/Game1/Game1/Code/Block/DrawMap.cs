using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Block
{
    class DrawMap
    {

        private static DrawMap instance = new DrawMap();

        public static DrawMap Instance
        {
            get
            {
                return instance;
            }
        }

        private DrawMap()
        {

        }

        public void DrawCurrMap(SpriteBatch currSpriteBatch, List<Tuple<IBlock, Vector2>> blockList)
        {
            for (int i = 0; i < blockList.Count; i++)
            {
                IBlock currBlock = blockList[i].Item1;
                Vector2 currPos = blockList[i].Item2;

                currBlock.DrawBlock(currSpriteBatch, currPos);
            }
        }

        public void DrawMovableBlocks(SpriteBatch currSpriteBatch, List<IBlock> movableBlocks)
        {
            for (int i = 0; i < movableBlocks.Count; i++)
            {
                IBlock currBlock = movableBlocks[i];
                currBlock.DrawBlock(currSpriteBatch, new Vector2(0, 0));
                currBlock.UpdateBlock();
            }
        }
    }
}
