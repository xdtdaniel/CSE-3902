Author: Dantong Xue

This block part will be responsible to show different blocks. "t" switches to the previous block and "y" switches to the next.

The block contains several parts. First, we have an IBlock interface, which will be implemented using 4 different concrete classes later. The 4 concrete block classes include MovingAnimatedBlock, MovingNonAnimatedBlock, NonMovingAnimatedBlock, and NonMovingNonAnimatedBlock. The last one will be used most frequently. Currently, fire used NonMovingAnimatedBlock, since the source sprite is spritesheet like. The other 2 classes are there just in case they will be used in future sprints.

BlockKeyboardController as the name will change between different blocks. "t" switches to the previous block and "y" switches to the next. It will wrap around at the beginning/end of the block list.

BlockCollection is used to show different blocks.

BlockFactory will load all contents related to blocks and handle the instantiation process.