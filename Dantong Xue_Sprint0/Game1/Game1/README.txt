This is the README file for Sprint 3, it contain the description of the features of the program, and the code analysis for sprint 3.

[Clarification for Sprint 2 Feedback]

- We include a screenshot of task board this time. We will consider switching to GitLab for the next sprint as it provided agile management tools.
- We did not end up merging all our factories together for the fact that the code for that single class will be too long. Also, as it might violate the idea of "doing one thing", it may not have a high cohesion.
- We considered using IDrawable/IUpdate for this Sprint, but ended up not using that as the parameters for different components of this game differed a lot.

[Controls]

Player (link):
	WASD/Arrow Up, Left, Down, Right to move the player
	N, Z to attack (two types)
	Num 1-6 Use different items.
Maps:
	Mouse left to the next map, right to the previous map.

 [Description of Sprint 3 features]
 
Sprint 3 is about implementing collision detection and handling, and level loading.
Sprint 3 includes all the parts we have done for sprint 2(with some changes and additions based on sprint 2 classes).

The new classes add for sprint 3 is:
      1. CollisionDetection.cs ---> a class that returns a string of direction for collision handlers to check if 2 objects are collided.
      2. CollisionHandler files ---> a collection of collision hanlders that displays the collision response of 2 objects in the room.
            1) PlayerAndBlockCollisionHandler.cs
            2) PlayerAndBlockCollisionHandler.cs
            3) PlayerAndItemCollisionHandler.cs
            4) PlayerItemaAndBlockCollisionHandler.cs
            5) PlayerItemaAndEnemyCollisionHandler.cs
      3. Load files  ---> a collection of classes to read and parse from .csv file, and returns a list of objects that can be drawn and updated later.
            1) LoadAll.cs
            2) LoadEnemy.cs
            3) LoadItem.cs
            4  LoadMap.cs
            5) MouseMapController.cs  --->  a controller class that gets user's mouse inputs to change room.
                                            left click to switch to previous room, right click to switch to next room in order.
      4. Map file  ---> a collection of .csv file for level1 room layout(rooms, enemies, items).       
      5. OneHandHoldBow.cs ---> display a special Link state when Link picks up a Bow.
      6. TwoHandHoldTriforceLink.cs --->  display a special Link state when Link picks up a Triforce.
      7. DrawAllItem.cs   ---> call IItemSprite Draw() method on the roomItemList return from LoadItem.cs
      8. UpdateAllItem.cs ---> call IItemSprite Update() method on the roomItemList return from LoadItem.cs
      9. PlayerPanel.cs  ---> a class to call other classes and display current Link's status and position.
      10. KnockedBackLink.cs ---> a new state class of link that causes link to be knocked back when hit. 

About doors
Doors are implemented such that if you approach a locked door, the door will open as we assume player has infinite many keys in Sprint 3. Shut doors such as the one behind the dragon will open after you kill all the enemies. Specific walls can be blown up using bomb and you will see a hole as you expected.
      
 [Code Analysis]

No Warnings or Errors in the code. Below are the descriptions for Messages.
      
IDE0044 Make field readonly appeared several times. In all circumstances, it is intended so it is not an issue.

IDE0052	Private member 'Game1._graphics' can be removed as the value assigned to it is never read. This variable stays there for possible future usage.

IDE0052	Private member 'Trap.MovingState' can be removed as the value assigned to it is never read. This variable stays there for possible future usage.



