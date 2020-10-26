Author: Dantong Xue

This folder contains all files needed to load all objects on maps.

LoadEnemy was mainly written by Jason. LoadItem were mainly written by Zhihan. LoadAll, LoadMap, and MouseMapController.cs were mainly written by Dantong.

LoadAll is responsible for calling corresponding functions for specific kinds of objects (blocks, enemies, items). It also maintains the current map status to allow changes and accesses to the artifacts. Other functions can get block information from this class.

LoadMap loads a single map using csv files in /Map/Room/ directory. For specific information about csv file structure, please turn to the README file in /Map/Room/ directory.

LoadItem loads items for a single map.

LoadEnemy loads and stores enemies for each map as we do not want to revive the enemies when we come back from another room.

MouseMapController switches between different maps, Mouse Left Click for the next map and Mouse Right Click for the previous map.