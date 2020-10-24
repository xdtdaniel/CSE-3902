This is the README file for Sprint 3, it contain the description of the control of the program, and the code analysis for sprint 3.
The sprint 3 is about implement collision detection and handling, and Level loading.

Sprint 3 include all the parts we have down for sprint 2(with some changes and addition on sprint 2 classes).

The new classes add for sprint 3 is:
      1. CollisionDetection.cs ---> a class that return a string of direction for collision handler to check if 2 object is collide.
      2. CollisionHandler file ---> a collection of collision hanlder use to display the collision respond of any 2 objects in the room.
            1) PlayerAndBlockCollisionHandler.cs
            2) PlayerAndBlockCollisionHandler.cs
            3) PlayerAndItemCollisionHandler.cs
            4) PlayerItemaAndBlockCollisionHandler.cs
            5) PlayerItemaAndEnemyCollisionHandler.cs
      3. Load file  ---> a collection of classes to read and parse from .csv file, and it return a list of object that can be draw and update later.
            1) LoadAll.cs
            2) LoadEnemy.cs
            3) LoadItem.cs
            4  LoadMap.cs
            5) MouseEnemyController.cs  ---> a controller class that get user's mouse input to change enemies to certain room.
            6) MouseMapController.cs  --->  a controller class that get user's mouse input to change room.
      4. Map file  ---> a collection of .csv file for level1 room layout(rooms, enemies, items).       
      5. OneHandHoldBow.cs ---> display a special Link state when Link pick up a Bow.
      6. TwoHandHoldTriforceLink.cs --->  display a special Link state when Link pick up a Triforce.
      7. DrawAllItem.cs   ---> call IItemSprite Draw() method on the roomItemList return from LoadItem.cs
      8. UpdateAllItem.cs ---> call IItemSprite Update() method on the roomItemList return from LoadItem.cs
      9. PlayerPanel.cs  ---> a class to call other classes and display current Link's status and position.
