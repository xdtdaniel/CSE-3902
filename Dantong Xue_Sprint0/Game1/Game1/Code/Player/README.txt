Author: Baihua Yang

Added in Sprint 5:
    Jump, dash, 8 abilities. 
_______________________________________________________________________________________________________
Player has 6 folders and 1 concrete class:
    CollisionHandler, Control, Factory, Interface, PlayerCharacter, PlayerItem and PlayerPanel.cs.
    
CollisionHandler: Files that generate collision responses when 2 objects are collided.

Control: An interface and a concrete class to control Link sprite.

Factory: PlayerCharacterFactory.cs produces character related sprites and PlayerItemFactory.cs produces item related sprites. 

Interface: IPlayerItemDrawer.cs: Interface for item drawer. IPlayerLinkState.cs: Interface for Link state. IPlayerSprite.cs: Interface for player sprite. 

PlayerCharacter: Contains LinkSprite and LinkState folders and Link.cs. Classes in LinkSprite provide Draw() method for classes in LinkState to draw the according sprites on screen. Classes in LinkState implement different states of Link using state pattern. Link.cs is the main class of Player.

PlayerItemAndAbility: Contains PlayerAbility, PlayerItemSprite and PlayerItemDrawer folders. PlayerAbility class has abilities classes that can be learned and used by Link. Classes in PlayerItemSprite provide Draw() method for classes in PlayerItemDrawer to draw the according sprites on screen. Classes in PlayerItemDrawer implement different states of items and abilities. 

PlayerPanel.cs: Integrate all the commands for Player so only a PlayerCommand and a Link instances in main game class are needed. 

***Player Control***

W or ↑: Move up
A or ←: Move left
S or ↓: Move down
D or →: Move right
N: Sword attack
Z: Use current selected item
J: Jump
K: Dash
D1 - D8: Use learned abilities

