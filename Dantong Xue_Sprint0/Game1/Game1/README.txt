This is README file for sprint 2, it includes the description of program control, and code analysis.

This program have 4 main parts, Player, Enemy, Block, Item. And a keyboard controller to quit and reset a game.


//Player description//  Press 'W', 'A', 'S', 'D' to move the Link. Press 'Z', 'N' to control the Link to attack. Press number keys to switch items used by Link. Press 'e' to display an injured Link.
Author: Baihua Yang

Player has 5 folders and 1 concrete class:
    Control, Factory, Interface, PlayerCharacter, PlayerItem and PlayerCommand.cs.
    
Control: An interface and a concrete class to control Link sprite.

Factory: PlayerCharacterFactory.cs produces character related sprites and PlayerItemFactory.cs produces item related sprites. 

Interface: IPlayerItemDrawer.cs: Interface for item drawer. IPlayerLinkState.cs: Interface for Link state. IPlayerSprite.cs: Interface for player sprite. 

PlayerCharacter: Contains LinkSprite and LinkState folders and Link.cs. Classes in LinkSprite provide Draw() method for classes in LinkState to draw the according sprites on screen. Classes in LinkState implement different states of Link using state pattern. Link.cs is the main class of Player.

PlayerItem: Contains PlayerItemSprite and PlayerItemDrawer folders and PlayerItem.cs. Classes in PlayerItemSprite provide Draw() method for classes in PlayerItemDrawer to draw the according sprites on screen. Classes in PlayerItemDrawer implement different states of item using state pattern. PlayerItem.cs is the instance represents the item that is being used by Link. 

PlayerCommand.cs: Integrate all the commands for Player so only a PlayerCommand and a Link instances in main game class are needed. 

/* required in Game1 class */

public class Game1 : Game
    {
        public Link link;
        private PlayerCommand playerCommand;

        protected override void Initialize()
        {
            link = new Link();
            playerCommand = new PlayerCommand(spriteBatch, this);
        }

        protected override void LoadContent()
        {
            PlayerCharacterFactory.Instance.LoadAllTextures(Content);
            PlayerItemFactory.Instance.LoadAllTextures(Content);
        }
        protected override void Update(GameTime gameTime)
        {
            playerCommand.PlayerUpdate();
        }
        protected override void Draw(GameTime gameTime)
        {
            playerCommand.PlayerDraw();
        }
    }
}


//Enemy description//  Switch between Enemies by press 'O' and 'P'. 
Author: Jason Lian

﻿This is the README file for enemy classes.
Last modified date: 10/03/2020

Enemy folder contains all the classes related to enemies and npcs in the game. 
Interface IEnemy contains three necessary methods for all the enemy objects: draw, update, 
and if the enemy type can fire projectile, the fire projectile method. There is no interface 
for projectile objects. Classes contain implementation details for projectile is only referenced
by the corresponding enemy class. 

For sprint 2, the keyboard controller of the enemy classes uses a collection of enemies that
contains all the enemy objects implemented so far.

By far, this folder include implementation for the following enemies/npcs: 
Aquamentus (dragon), Gel (slime), Goriya (dog-like enemy which can throw boomerang), 
Keese (bat), Stalfos (skeleton), Walmaster (hand), Merchant, Old Man and Fire.


//Block description// Switch between Blocks by press 'T' and 'Y'. 
Author: Dantong Xue

This block part will be responsible to show different blocks. "t" switches to the previous block and "y" switches to the next.

The block contains several parts. First, we have an IBlock interface, which will be implemented using 4 different concrete classes later. The 4 concrete block classes include MovingAnimatedBlock, MovingNonAnimatedBlock, NonMovingAnimatedBlock, and NonMovingNonAnimatedBlock. The last one will be used most frequently. Currently, fire used NonMovingAnimatedBlock, since the source sprite is spritesheet like. The other 2 classes are there just in case they will be used in future sprints.

BlockKeyboardController as the name will change between different blocks. "t" switches to the previous block and "y" switches to the next. It will wrap around at the beginning/end of the block list.

BlockCollection is used to show different blocks.

BlockFactory will load all contents related to blocks and handle the instantiation process.


//Item description// Switch between items by press 'U' and 'I'.
Author: Zhihan Li
This is the README file for Item part
Item include 5 parts.

ItemFacotory, IItemInterface, ItemSprite, ItemKeyboardController, ItemLists.
ItemFactory contain all the required items in item part and it use "instance" to call all the createItem() methods in ItemSprite folder. 
All methods inside ItemSprite inherited from IItemSprite interface, each method have a Draw() method to draw the item, and Update()  method for some items(Heart, Fairy,  
Rubee, Triforce).
IItemInterfaace contain 2 methods Draw() and Update().
ItemKeyboardController is used to get user's keyboardinput for item control.  "U" for previous item, "I" for next item in item list. It include 2 methods, Update() to update  
current item with user input, Draw is used to call Draw() method of  each item.
ItemList is a class to generate a list of items by call itemList.Add(ItemFactory.ItemSpriteFactory.Instance."CreateItem()";
ItemList has an  static int  index  used to iterate all  items  in the list. It  has Draw(),  Update(), MovePrev(), MoveNext, all use index to distinct items.


Here is required code in Game1 class:

public class Game1 : Game
    {
        public IItemSprite item; 
        private ItemKeyboardController itemKeyboardController;

        protected override void Initialize()
        {
            itemKeyboardController = new ItemKeyboardController();
            playerCommand = new PlayerCommand(spriteBatch, this);
        }

        protected override void LoadContent()
        {
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            
        }
        protected override void Update(GameTime gameTime)
        {

            itemKeyboardController.Update(this);

        }
        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            itemKeyboardController.Draw(_spriteBatch, 400, 200);
            _spriteBatch.End();

        }

    }
}

//QuitResetController description//  Press 'Q' to quit current game, press 'R' to quit current game and start a new game.
Author: Zhihan Li
This controller used to quit or restart a game based on user's keyboard input.


//Code Analysis Result//
2 Warnings
Severity	Code	Description	Project	File	Line	Suppression State
Warning	CA2213	'Game1' contains field '_graphics' that is of IDisposable type 'GraphicsDeviceManager', but it is never disposed. Change the Dispose method on 'Game1' to call Close or Dispose on this field.	Game1	C:\Users\~!\Downloads\CSE-3902-master\CSE-3902-master\Dantong Xue_Sprint0\Game1\Game1\Game1.cs	19	Active
Severity	Code	Description	Project	File	Line	Suppression State
Warning	CA2213	'Game1' contains field '_spriteBatch' that is of IDisposable type 'SpriteBatch', but it is never disposed. Change the Dispose method on 'Game1' to call Close or Dispose on this field.	Game1	C:\Users\~!\Downloads\CSE-3902-master\CSE-3902-master\Dantong Xue_Sprint0\Game1\Game1\Game1.cs	21	Active

Fiexed by suppress in Source: #pragma warning disable CA2213 // Disposable fields should be disposed
Problem Fixed.
