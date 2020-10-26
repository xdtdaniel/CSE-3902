This is the README file for Sprint 3, it contain the description of the features of the program, and the code analysis for sprint 3.

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
            5) MouseEnemyController.cs  ---> a controller class that gets user's mouse inputs to change enemies to certain room.
            6) MouseMapController.cs  --->  a controller class that gets user's mouse inputs to change room.
                                            left click to switch to previous room, right click to switch to next room in order.
      4. Map file  ---> a collection of .csv file for level1 room layout(rooms, enemies, items).       
      5. OneHandHoldBow.cs ---> display a special Link state when Link picks up a Bow.
      6. TwoHandHoldTriforceLink.cs --->  display a special Link state when Link picks up a Triforce.
      7. DrawAllItem.cs   ---> call IItemSprite Draw() method on the roomItemList return from LoadItem.cs
      8. UpdateAllItem.cs ---> call IItemSprite Update() method on the roomItemList return from LoadItem.cs
      9. PlayerPanel.cs  ---> a class to call other classes and display current Link's status and position.
      10. KnockedBackLink.cs ---> a new state class of link that causes link to be knocked back when hit. 
      
      
 [Code Analysis]
      
