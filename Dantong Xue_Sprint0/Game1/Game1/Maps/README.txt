Author: Dantong Xue

This folders contains Maps csv files for this game.

file "test_colored.xlsx" is basically a template of how are our csv files organized. You may look at that to get more idea since it is colored and easy to understand.

Level1_marked.png has numbers on each level. This tells user how we numbered our maps.

In Room folders, all csv files are the actual files supporting reading different components of the maps.

The naming strategy is as followed:
ALL enemy/item files are referred as level#_enemy.csv or level#_item.csv
For the blocks on the map, the naming strategy goes as:
level#_doorstatus_otherstatus.csv

doorstatus refers to if a door has been unlocked using keys. In specific, each doorstatus is a four-bit binary (0000). Each digit from high to low refers to up, left, down, right, four doors. 0000 refers to default status, 0010 refers to the "down" door has been unlocked, etc.

otherstatus refers to the doors opened by killing all enemies or holes blown up by bombs.