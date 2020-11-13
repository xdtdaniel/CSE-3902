using Game1.Code.Audio;
using Game1.Code.Item.ItemInterface;
using Game1.Code.Item.ItemSprite;
using Game1.Code.LoadFile;
using Game1.Player.PlayerCharacter;
using System;
using System.Collections.Generic;

namespace Game1.Code.Player
{
    public static class PlayerAndItemCollisionHandler
    {
        static string collidedSide = "";
        //used to store the removed items, it might used to count number of each item player had.
        static private List<Tuple<IItemSprite, string>> outRoomList = new List<Tuple<IItemSprite, string>>();
        static IItemSprite item;
        private static int mapID;
        
        static public void HandleCollision(Link link, List<Tuple<IItemSprite, string>> roomItemList)
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
                        case "Arrow":
                            link.itemList["Arrow"]++;
                            item = new Arrow(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "Arrow"));
                            roomItemList.RemoveAt(index);
                            AudioPlayer.getItem.Play();
                            break;
                        case "Bomb":
                            link.itemList["Bomb"]++;
                            item = new Bomb(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "Bomb"));
                            roomItemList.RemoveAt(index);
                            AudioPlayer.getItem.Play();
                            break;
                        case "Boomerang":
                            link.itemList["Boomerang"]++;
                            item = new Boomerang(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "Boomerang"));
                            roomItemList.RemoveAt(index);
                            AudioPlayer.getItem.Play();
                            break;
                        case "Bow":
                            link.itemList["Bow"]++;
                            link.PickUp(3);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "Bow"));
                            roomItemList.RemoveAt(index);
                            AudioPlayer.getItem.Play();
                            break;
                        case "Clock":
                            link.itemList["Clock"]++;
                            item = new Clock(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "Clock"));
                            roomItemList.RemoveAt(index);
                            mapID = LoadAll.Instance.GetCurrentMapID();
                            AudioPlayer.getItem.Play();
                            break;
                        case "Compass":
                            link.itemList["Compass"]++;
                            item = new Compass(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "Compass"));
                            roomItemList.RemoveAt(index);
                            AudioPlayer.getItem.Play();
                            break;
                        case "Fairy":
                            link.itemList["Fairy"]++;
                            item = new Fairy(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "Fairy"));
                            roomItemList.RemoveAt(index);
                            AudioPlayer.getItem.Play();
                            break;
                        case "Heart":
                            link.itemList["Heart"] += 2;
                            if (link.itemList["Heart"] > link.itemList["HeartContainer"])
                            {
                                link.itemList["Heart"] = link.itemList["HeartContainer"];
                            }
                            item = new Heart(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "Heart"));
                            roomItemList.RemoveAt(index);
                            AudioPlayer.getHeart.Play();
                            break;
                        case "HeartContainer":
                            link.itemList["HeartContainer"] += 2;
                            link.itemList["Heart"] += 2;
                            link.PickUp(4);
                            item = new HeartContainer(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "HeartContainer"));
                            roomItemList.RemoveAt(index);
                            AudioPlayer.getHeart.Play();
                            break;
                        case "Key":
                            link.itemList["Key"]++;
                            item = new Key(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "Key"));
                            roomItemList.RemoveAt(index);
                            AudioPlayer.getHeart.Play();
                            break;
                        case "Map":
                            link.itemList["Map"]++;
                            item = new Map(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "Map"));
                            roomItemList.RemoveAt(index);
                            AudioPlayer.getItem.Play();
                            break;
                        case "Ruby":
                            link.itemList["Ruby"]++;
                            item = new Ruby(X, Y);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "Ruby"));
                            roomItemList.RemoveAt(index);
                            AudioPlayer.getRupee.Play();
                            break;
                        case "Triforce":
                            link.itemList["Triforce"]++;
                            link.PickUp(2);
                            outRoomList.Add(new Tuple<IItemSprite, string>(item, "Triforce"));
                            roomItemList.RemoveAt(index);
                            link.Win();
                            AudioPlayer.getTriforce.Play();
                            break;
                    }

                }
                


            }


        }

        //might use it later
        static public List<Tuple<IItemSprite, string>> GetOutRoomItemList()
        {
            return outRoomList;
        }

        static public int getMapID() {

            return mapID;
        }
    }
}
