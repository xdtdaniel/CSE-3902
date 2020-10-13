using Microsoft.Xna.Framework;
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


        public IBlock CreateBlackBlock(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(black, location);
        }

        public IBlock CreateFlatBlock(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(block, location);
        }

        public IBlock CreateDragon(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(dragon, location);
        }

        public IBlock CreateBlueDragon(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(dragonBlue, location);
        }

        public IBlock CreateFire(Vector2 location)
        {
            return new NonMovingAnimatedBlock(fire, 1, 2);
        }

        public IBlock CreateFish(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(fish,location);
        }

        public IBlock CreateBlueFish(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(fishBlue,location);
        }

        public IBlock CreateFloatBlock(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(floatBlock, location);
        }

        public IBlock CreateGreyBlock(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(grey, location);
        }

        public IBlock CreateFrontHole(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(holeFront, location);
        }

        public IBlock CreateLeftHole(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(holeLeft, location);
        }

        public IBlock CreateRightHole(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(holeRight, location);
        }

        public IBlock CreateBackHole(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(holeBack, location);
        }

        public IBlock CreateFrontLockedDoor(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(lockedDoorFront, location);
        }

        public IBlock CreateLeftLockedDoor(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(lockedDoorLeft, location);
        }

        public IBlock CreateRightLockedDoor(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(lockedDoorRight, location);
        }

        public IBlock CreateBackLockedDoor(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(lockedDoorBack, location);
        }

        public IBlock CreateFrontOpenDoor(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(openDoorFront, location);
        }

        public IBlock CreateLeftOpenDoor(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(openDoorLeft, location);
        }

        public IBlock CreateRightOpenDoor(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(openDoorRight, location);
        }

        public IBlock CreateBackOpenDoor(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(openDoorBack, location);
        }

        public IBlock CreateFrontShutDoor(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(shutDoorFront, location);
        }

        public IBlock CreateLeftShutDoor(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(shutDoorLeft, location);
        }

        public IBlock CreateRightShutDoor(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(shutDoorRight, location);
        }

        public IBlock CreateBackShutDoor(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(shutDoorBack, location);
        }

        public IBlock CreateSandFloor(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(sandFloor, location);
        }

        public IBlock CreateStair(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(stair, location);
        }

        public IBlock CreateFrontWall(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(wallFront, location);
        }

        public IBlock CreateLeftWall(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(wallLeft, location);
        }

        public IBlock CreateRightWall(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(wallRight, location);
        }

        public IBlock CreateBackWall(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(wallBack, location);
        }

        public IBlock CreateBWWall(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(wallBW, location);
        }

        public IBlock CreateGreyWall(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(wallGrey, location);
        }

        public IBlock CreateWater(Vector2 location)
        {
            return new NonMovingNonAnimatedBlock(water, location);
        }
    }
}
