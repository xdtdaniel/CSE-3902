This is the Readme file for Sprint 5. It consists the info from Sprint 4 as well.

[New Features Added in Sprint 5]
- New levels (Jason Lian, Dantong Xue):
   We added four new levels (19, 20, 21, 22) that can be accessed by going down at the initial starting level. Level 20 is designed so that you need to hide and run. Level 21 needs you to determine which path to go. Arrows are implemented as escalators. Level 22 has a new Boss of Saw.
- New Achievement System (Baihua Yang):
- New Weapons (Fan Shen):
- New HUD Elements (Zhihan Li, Baihua Yang): Add RPG element Experience to HUD, it count the number of killed enemies and calculate level based on it. Each time Link level up
will have new ability point, that acn be used to learn new skill. And we also add prompt when Link level up, to guide user to ability tree screen.
- New Skill System Including Exp Bar (Baihua Yang, Zhihan Li):
For each ability on ability tree, it has name and description on the right of the screen to let user get known about each ability.
Each ability can be controlled by number keys from [1] to [8], and link can use these ability to attack enemies.
- New Cheat Code Option (Patrick Cheng): 

[Complete List of Controls]
[W,A,S,D / Arrow Up,Left,Down,Right] Move Up,Left,Down,Right
[N] Attack
[Z] Use current item
[P] Go to/back from item selection interface

-----[P]-----Item Selection Screen
[U] Item select left
[I] Item select right
[B] Choose item to use in inventory

-----[O]-----Ability Tree Screen
[U] select previous ability
[I] select next ability
[B] Choose to add newww ability point

[Space] Pause/unpause the game
[M] Respawn after death
[Q] Quit
[R] Hard restart (kill current process and start a new one)
[Mouse left/right Clicks] Teleport between maps

[HUD]
Author: Baihua Yang, Zhihan Li.
  [Description of inventory Control]
    Press [P] to see the item selection screen, Press [P] again to back to the current game screen. On item selection screen, Use [U] & [I] to move the
    selection frame left and right. Press [B] to select the inventory item to use, and the selected item will display on tab B on HUD.
    
  [Description of Features]
    HUD part display above the current room. It used to display the basic informations of Link, it includes Link's Life#, Key#, Ruby#, Bomb#, Mini Map,
    current position, ccurrent level of dungeon, current weapons(tab A & B). All elements in HUD are moved with camera to ensure all sprites display on 
    the correcct place. 
    Item selection part display all the items Link had. Item selection provide a function for player to select different items to use
    and it also display the current postion of Link.
    
[Camera]
Author: Jason Lian
Camera features have been integrated to other part of this sprint. The camera class provides basic control of transition in four directions.
It also supports the reset function which reset the camera location to the initial location, used for the ressting of the game.
Camera transition function is incorportaed in the room transition part. The scrolling speed can be changed by changing the speed variable.

[Room Scrolling Switch]
Author: Dantong Xue
Room scrolling will apply when link are walking through doors.

[Sound]
Author: Fan Shen
  [Description of Features]
    Audio provides soundeffects(SFX) and background music functionality to the game with an ISounds interface with multiple concrete classes reponsible for different kinds of       SFX in Game. The interface provides mainly 2 functions: Play and Stop by utilizing built-in functions of SoundEffectInstance. For specific few SFX that needs to be looped       like lowhealth and arrow sound, SoundEffectInstance.isRepeated is set to true manually in the specfic class and can be modified or added accordingly in the future.               AudioPlayer is a seperate static class for other classes in other parts of the game to call and load the specific SFX objects.

[States]
Author: Patrick Cheng, Dantong Xue, Baihua Yang, Zhihan Li, Jason Lian.
      1. Pause Screen Press: [Space] to pause the game, press [Space] to resume.
      2. Winning State: Grab the triforce, change the screen color to green, end the game. 
      3. Game over State: Change the screen color to black, Prompt user to restart a new game by press [M].    
      
[Start Screen]
Author: Dantong Xue.
       Start Screen, press [Enter] to start game.
       
[Code Analysis]
       No Warning or Error found in this Sprint.
 
