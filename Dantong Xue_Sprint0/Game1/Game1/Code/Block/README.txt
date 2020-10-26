Author: Dantong Xue

For Sprint 3, several classes has been removed as they will no longer be used for block purposes. A new Movable Block has been supported with MovableBlock.cs file. For drawing all blocks on the map, a new class DrawMap has been added and is used in Game1 class.

#Historical README for Sprint 2#
This block part will be responsible to show different blocks. "t" switches to the previous block and "y" switches to the next.

The block contains several parts. First, we have an IBlock interface, which will be implemented using 4 different concrete classes later. The 4 concrete block classes include MovingAnimatedBlock, MovingNonAnimatedBlock, NonMovingAnimatedBlock, and NonMovingNonAnimatedBlock. The last one will be used most frequently. Currently, fire used NonMovingAnimatedBlock, since the source sprite is spritesheet like. The other 2 classes are there just in case they will be used in future sprints.

BlockKeyboardController as the name will change between different blocks. "t" switches to the previous block and "y" switches to the next. It will wrap around at the beginning/end of the block list.

BlockCollection is used to show different blocks.

BlockFactory will load all contents related to blocks and handle the instantiation process.