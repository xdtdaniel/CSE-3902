using Game1.Code.Block.BlockFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Block
{
    class BlockCollection
    {

        private List<IBlock> blockList;
        private static int index;

        public BlockCollection()
        {
            
            blockList = new List<IBlock>();
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateBackHole());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateBackLockedDoor());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateBackOpenDoor());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateBackShutDoor());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateBackWall());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateBlackBlock());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateBlueDragon());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateBlueFish());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateBWWall());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateDragon());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateFire());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateFish());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateFlatBlock());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateFloatBlock());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateFrontHole());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateFrontLockedDoor());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateFrontOpenDoor());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateFrontShutDoor());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateFrontWall());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateGreyBlock());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateGreyWall());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateLeftHole());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateLeftLockedDoor());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateLeftOpenDoor());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateLeftShutDoor());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateLeftWall());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateRightHole());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateRightLockedDoor());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateRightOpenDoor());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateRightShutDoor());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateRightWall());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateSandFloor());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateStair());
            blockList.Add(BlockFactory.BlockFactory.Instance.CreateWater());

            index = 0;
        }

        public void DrawCurrent(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Begin();
            
            blockList[index].DrawBlock(spriteBatch, location);
            spriteBatch.End();
        }

        public void UpdateCurrent()
        {
            blockList[index].UpdateBlock();
        }

        public void MoveNext()
        {
            index++;
            if (index == blockList.Count)
            {
                index = 0;
            }
        }

        public void MovePrev()
        {
            index--;
            if (index < 0)
            {
                index = blockList.Count - 1;
            }
        }
    }
}
