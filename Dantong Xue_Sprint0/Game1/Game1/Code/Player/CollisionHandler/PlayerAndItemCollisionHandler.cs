using Game1.Code.Item.ItemInterface;
using Game1.Code.Item.ItemSprite;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game1.Code.Player
{
    class PlayerAndItemCollisionHandler
    {
        string collidedSide;
        //used to store the removed items, it might used to count number of each item player had.
        private List<Tuple<IItemSprite, string>> outRoomList = new List<Tuple<IItemSprite, string>>();
        private static PlayerAndItemCollisionHandler instance = new PlayerAndItemCollisionHandler();
        public static PlayerAndItemCollisionHandler Instance
        {
            get
            {
                return instance;
            }
        }
        public PlayerAndItemCollisionHandler()
        {
            collidedSide = "";
        }
        IItemSprite item;
        public void HandleCollision(Link link, List<Tuple<IItemSprite, string>> roomItemList)
        {
            for (int  index= 0;index < roomItemList.Count;index++)
            {
                collidedSide = CollisionDetection.Instance.isCollided(link.GetRectangle(), roomItemList[index].Item1.GetRectangle());
                if (collidedSide != "")
                {
                    //  might pick up item, might change hud.  
                    int X = 0;
                    int Y = 0;
                    //Add all player collide items to a list,  no need to record item ccurrent location
                    switch (roomItemList[index].Item2)
                    {
                        case "arrow":
                            link.itemList["arrow"]++;
                            item = new Arrow(X,Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "arrow"));
                            roomItemList.RemoveAt(index);
                            roomItemList[index].Item1.Update();
                            break;
                        case "bomb":
                            link.itemList["bomb"]++;
                            item = new Bomb(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "bomb"));
                            roomItemList.RemoveAt(index);
                            break;
                        case "boomerang":
                            link.itemList["boomerang"]++;
                            item = new Boomerang(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "boomerang"));
                            roomItemList.RemoveAt(index);
                            break;
                        case "bow":
                            link.itemList["bow"]++;
                            link.PickUp(3);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "bow"));
                            roomItemList.RemoveAt(index);
                            break;
                        case "clock":
                            link.itemList["clock"]++;
                            item = new Clock(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "clock"));
                            roomItemList.RemoveAt(index);
                            break;
                        case "compass":
                            link.itemList["compass"]++;
                            item = new Compass(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "compass"));
                            roomItemList.RemoveAt(index);
                            break;
                        case "fairy":
                            link.itemList["fairy"]++;
                            item = new Fairy(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "fairy"));
                            roomItemList.RemoveAt(index);
                            break;
                        case "heart":
                            link.itemList["heart"]++;
                            item = new Heart(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "heart"));
                            roomItemList.RemoveAt(index);
                            break;
                        case "heartcontainer":
                            link.itemList["heart_container"]++;
                            item = new HeartContainer(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "heart_container"));
                            roomItemList.RemoveAt(index);
                            break;
                        case "key":
                            link.itemList["key"]++;
                            item = new Key(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "key"));
                            roomItemList.RemoveAt(index);
                            break;
                        case "map":
                            link.itemList["map"]++;
                            item = new Map(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "map"));
                            roomItemList.RemoveAt(index);
                            break;
                        case "ruby":
                            link.itemList["ruby"]++;
                            item = new Ruby(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "ruby"));
                            roomItemList.RemoveAt(index);
                            break;
                        case "triforce":
                            link.itemList["triforce"]++;
                            link.PickUp(2);                          
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "triforce"));
                            roomItemList.RemoveAt(index);
                            break;
                    }

                }
                


            }


        }

        //might use it later
        public List<Tuple<IItemSprite, string>> GetOutRoomItemList()
        {
            return outRoomList;
        }

    }
}
