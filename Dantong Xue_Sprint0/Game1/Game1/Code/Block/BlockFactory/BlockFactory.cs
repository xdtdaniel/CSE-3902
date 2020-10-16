using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Block.BlockFactory
{
    class BlockFactory
    {
        private Texture2D black;
        private Texture2D block;
        private Texture2D dragon;
        private Texture2D dragonBlue;
        private Texture2D fire;
        private Texture2D fish;
        private Texture2D fishBlue;
        private Texture2D floatBlock;
        private Texture2D grey;
        private Texture2D holeFront;
        private Texture2D holeLeft;
        private Texture2D holeRight;
        private Texture2D holeBack;
        private Texture2D lockedDoorFront;
        private Texture2D lockedDoorLeft;
        private Texture2D lockedDoorRight;
        private Texture2D lockedDoorBack;
        private Texture2D openDoorFront;
        private Texture2D openDoorLeft;
        private Texture2D openDoorRight;
        private Texture2D openDoorBack;
        private Texture2D shutDoorFront;
        private Texture2D shutDoorLeft;
        private Texture2D shutDoorRight;
        private Texture2D shutDoorBack;
        private Texture2D sandFloor;
        private Texture2D stair;
        private Texture2D wallFront;
        private Texture2D wallLeft;
        private Texture2D wallRight;
        private Texture2D wallBack;
        private Texture2D wallBW;
        private Texture2D wallGrey;
        private Texture2D water;
        private Texture2D room;

        private static BlockFactory instance = new BlockFactory();

        public static BlockFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockFactory()
        {

        }

        public void LoadAllTexture(ContentManager content)
        {
            black = content.Load<Texture2D>("Sprite/Blocks/black");
            block = content.Load<Texture2D>("Sprite/Blocks/block");
            dragon = content.Load<Texture2D>("Sprite/Blocks/dragon");
            dragonBlue = content.Load<Texture2D>("Sprite/Blocks/dragon_blue");
            fire = content.Load<Texture2D>("Sprite/Blocks/fire");
            fish = content.Load<Texture2D>("Sprite/Blocks/fish");
            fishBlue = content.Load<Texture2D>("Sprite/Blocks/fish_blue");
            floatBlock = content.Load<Texture2D>("Sprite/Blocks/float_block");
            grey = content.Load<Texture2D>("Sprite/Blocks/grey");
            holeFront = content.Load<Texture2D>("Sprite/Blocks/hole_1");
            holeLeft = content.Load<Texture2D>("Sprite/Blocks/hole_2");
            holeRight = content.Load<Texture2D>("Sprite/Blocks/hole_3");
            holeBack = content.Load<Texture2D>("Sprite/Blocks/hole_4");
            lockedDoorFront = content.Load<Texture2D>("Sprite/Blocks/locked_door_1");
            lockedDoorLeft = content.Load<Texture2D>("Sprite/Blocks/locked_door_2");
            lockedDoorRight = content.Load<Texture2D>("Sprite/Blocks/locked_door_3");
            lockedDoorBack = content.Load<Texture2D>("Sprite/Blocks/locked_door_4");
            openDoorFront = content.Load<Texture2D>("Sprite/Blocks/open_door_1");
            openDoorLeft = content.Load<Texture2D>("Sprite/Blocks/open_door_2");
            openDoorRight = content.Load<Texture2D>("Sprite/Blocks/open_door_3");
            openDoorBack = content.Load<Texture2D>("Sprite/Blocks/open_door_4");
            shutDoorFront = content.Load<Texture2D>("Sprite/Blocks/shut_door_1");
            shutDoorLeft = content.Load<Texture2D>("Sprite/Blocks/shut_door_2");
            shutDoorRight = content.Load<Texture2D>("Sprite/Blocks/shut_door_3");
            shutDoorBack = content.Load<Texture2D>("Sprite/Blocks/shut_door_4");
            sandFloor = content.Load<Texture2D>("Sprite/Blocks/sand_floor");
            stair = content.Load<Texture2D>("Sprite/Blocks/stair");
            wallFront = content.Load<Texture2D>("Sprite/Blocks/wall_1");
            wallLeft = content.Load<Texture2D>("Sprite/Blocks/wall_2");
            wallRight = content.Load<Texture2D>("Sprite/Blocks/wall_3");
            wallBack = content.Load<Texture2D>("Sprite/Blocks/wall_4");
            wallBW = content.Load<Texture2D>("Sprite/Blocks/wall_b_w");
            wallGrey = content.Load<Texture2D>("Sprite/Blocks/wall_grey");
            water = content.Load<Texture2D>("Sprite/Blocks/water");
            room = content.Load<Texture2D>("Sprite/Blocks/room_interior");
        }

        public IBlock CreateRoom()
        {
            return new NonMovingNonAnimatedBlock(room);
        }

        public IBlock CreateBlackBlock()
        {
            return new NonMovingNonAnimatedBlock(black);
        }

        public IBlock CreateFlatBlock()
        {
            return new NonMovingNonAnimatedBlock(block);
        }

        public IBlock CreateDragon()
        {
            return new NonMovingNonAnimatedBlock(dragon);
        }

        public IBlock CreateBlueDragon()
        {
            return new NonMovingNonAnimatedBlock(dragonBlue);
        }

        public IBlock CreateFire()
        {
            return new NonMovingNonAnimatedBlock(fire);
        }

        public IBlock CreateFish()
        {
            return new NonMovingNonAnimatedBlock(fish);
        }

        public IBlock CreateBlueFish()
        {
            return new NonMovingNonAnimatedBlock(fishBlue);
        }

        public IBlock CreateFloatBlock()
        {
            return new NonMovingNonAnimatedBlock(floatBlock);
        }

        public IBlock CreateGreyBlock()
        {
            return new NonMovingNonAnimatedBlock(grey);
        }

        public IBlock CreateFrontHole()
        {
            return new NonMovingNonAnimatedBlock(holeFront);
        }

        public IBlock CreateLeftHole()
        {
            return new NonMovingNonAnimatedBlock(holeLeft);
        }

        public IBlock CreateRightHole()
        {
            return new NonMovingNonAnimatedBlock(holeRight);
        }

        public IBlock CreateBackHole()
        {
            return new NonMovingNonAnimatedBlock(holeBack);
        }

        public IBlock CreateFrontLockedDoor()
        {
            return new NonMovingNonAnimatedBlock(lockedDoorFront);
        }

        public IBlock CreateLeftLockedDoor()
        {
            return new NonMovingNonAnimatedBlock(lockedDoorLeft);
        }

        public IBlock CreateRightLockedDoor()
        {
            return new NonMovingNonAnimatedBlock(lockedDoorRight);
        }

        public IBlock CreateBackLockedDoor()
        {
            return new NonMovingNonAnimatedBlock(lockedDoorBack);
        }

        public IBlock CreateFrontOpenDoor()
        {
            return new NonMovingNonAnimatedBlock(openDoorFront);
        }

        public IBlock CreateLeftOpenDoor()
        {
            return new NonMovingNonAnimatedBlock(openDoorLeft);
        }

        public IBlock CreateRightOpenDoor()
        {
            return new NonMovingNonAnimatedBlock(openDoorRight);
        }

        public IBlock CreateBackOpenDoor()
        {
            return new NonMovingNonAnimatedBlock(openDoorBack);
        }

        public IBlock CreateFrontShutDoor()
        {
            return new NonMovingNonAnimatedBlock(shutDoorFront);
        }

        public IBlock CreateLeftShutDoor()
        {
            return new NonMovingNonAnimatedBlock(shutDoorLeft);
        }

        public IBlock CreateRightShutDoor()
        {
            return new NonMovingNonAnimatedBlock(shutDoorRight);
        }

        public IBlock CreateBackShutDoor()
        {
            return new NonMovingNonAnimatedBlock(shutDoorBack);
        }

        public IBlock CreateSandFloor()
        {
            return new NonMovingNonAnimatedBlock(sandFloor);
        }

        public IBlock CreateStair()
        {
            return new NonMovingNonAnimatedBlock(stair);
        }

        public IBlock CreateFrontWall()
        {
            return new NonMovingNonAnimatedBlock(wallFront);
        }

        public IBlock CreateLeftWall()
        {
            return new NonMovingNonAnimatedBlock(wallLeft);
        }

        public IBlock CreateRightWall()
        {
            return new NonMovingNonAnimatedBlock(wallRight);
        }

        public IBlock CreateBackWall()
        {
            return new NonMovingNonAnimatedBlock(wallBack);
        }

        public IBlock CreateBWWall()
        {
            return new NonMovingNonAnimatedBlock(wallBW);
        }

        public IBlock CreateGreyWall()
        {
            return new NonMovingNonAnimatedBlock(wallGrey);
        }

        public IBlock CreateWater()
        {
            return new NonMovingNonAnimatedBlock(water);
        }
    }
}
