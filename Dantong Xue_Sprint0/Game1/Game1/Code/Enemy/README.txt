This is the README file for enemy classes.

Author: Jason Lian
Last modified date: 12/03/2020

This folder contains for all enemy, projectile and NPC types in the game.

Enemy and Npc calsses implement the IEnemy interface and projectile classes implement the IProjectile interface.

IEnemy interface contains three necessary methods for all the enemy objects: draw, update, 
and if the enemy type can fire projectile, the fire projectile method. There is no interface 
for projectile objects. Classes contain implementation details for projectile is only referenced
by the corresponding enemy class. The interface also contains methods for getting and changing
the hp of enemies. It provide the method for getting the collision rectangle, it also provide a 
freeze method to serve for the functionality of the clock item.

The IProjectile interface allow the client class to control the initial position, direction and
whether the projectile is on screen or not. The implementation details of each projectile class
are known by the corresponding enemy class. It is not possible to only use projectile object and
not use the corresponding enemy in the game.

All types in the original dungeon:

Enemies: Gel, Keese, Stalfos, Goriya, Wallmaster, Trap, Aquamentus (use a different sprite and a slightly different attacking logic)
NPCs: Merchant, Old man

New enemy types for Sprint 5:
Saw, New trap(red), New trap(Yellow)

HP values of enemies are adjusted accordingly for balance reason due to the new features in the game.