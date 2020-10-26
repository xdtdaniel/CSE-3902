This is the README file for enemy classes.

Author: Jason Lian
Last modified date: 10/25/2020

Enemy folder contains all the classes related to enemies and npcs in the game. 
Interface IEnemy contains three necessary methods for all the enemy objects: draw, update, 
and if the enemy type can fire projectile, the fire projectile method. There is no interface 
for projectile objects. Classes contain implementation details for projectile is only referenced
by the corresponding enemy class. 

For sprint 2, the keyboard controller of the enemy classes uses a collection of enemies that
contains all the enemy objects implemented so far.

For sprint 3, LoadEnemy class is added and it load all the enemies in the dungeon, Trap is added
to all the enemy classes, but require further implementation. Now all the enemy have collision 
handling with other objects and are able to take damage.

By far, this folder include implementation for the following enemies/npcs: 
Aquamentus (dragon), Gel (slime), Goriya (dog-like enemy which can throw boomerang), 
Keese (bat), Stalfos (skeleton), Walmaster (hand),Trap, Merchant, Old Man and Fire.