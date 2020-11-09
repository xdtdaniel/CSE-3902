using Game1.Code.HUD.Factory;
using Game1.Code.Item.ItemFactory;
using Game1.Code.LoadFile;
using Game1.Code.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Game1.Code.HUD.Sprite
{
    class DungeonPauseScreen : IHUDSprite
    {
        private int scale;
        private int mapHeight;
        private int mapWidth;
        private int compassHeight;
        private int compassWidth;
        private int spotHeight;
        private int spotWidth;
        private int cellSideLenth;
        private (int, int) bridgeSideLength;


        private int mapX;
        private int mapY;
        private int compassX;
        private int compassY;
        private List<Tuple<int, int>> spotPosList;
        private List<Tuple<bool, Vector2>> bridgePosList;
        private int currSpotIndex;
        private int prevMapID;
        private int spotOffsetX;
        private int spotOffsetY;


        private Dictionary<string, int> itemList;

        private Texture2D map;
        private Texture2D compass;
        private Texture2D spot;

        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public DungeonPauseScreen(Dictionary<string, int> itemList) {
            scale = (int)LoadAll.Instance.scale;
            this.itemList = itemList;

            // sizes
            mapHeight = 16 * scale;
            mapWidth = 8 * scale;
            compassHeight = 16 * scale;
            compassWidth = 15 * scale;
            spotHeight = spotWidth = 6 * scale;
            cellSideLenth = 8 * scale;
            bridgeSideLength = (2 * scale, 2 * scale); 

            // positions
            mapX = 48 * scale + (int)LoadAll.Instance.startPos.X;
            mapY = 112 * scale - 176 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
            compassX = 44 * scale + (int)LoadAll.Instance.startPos.X;
            compassY = 44 * scale - 176 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
            spotPosList = new List<Tuple<int, int>>();
            spotPosList.Add(new Tuple<int, int>(128 * scale + 3 * cellSideLenth + (int)LoadAll.Instance.startPos.X, 96 * scale + 7 * cellSideLenth - 176 * scale - 56 * scale));
            bridgePosList = new List<Tuple<bool, Vector2>>();
            // the bool variable: true if the bridge is horizontal, false if vertical
            bridgePosList.Add(new Tuple<bool, Vector2>(false, new Vector2(spotPosList[0].Item1 + 2 * scale, spotPosList[0].Item2 + 6 * scale)));
            currSpotIndex = 0;
            prevMapID = LoadAll.Instance.GetCurrentMapID();

            // textures
            map = ItemSpriteFactory.CreateMap();
            compass = ItemSpriteFactory.CreateCompass();
            spot = HUDFactory.LoadBlackSpot();

            // rectangles for drawing
            sourceRectangle = new Rectangle();
            destinationRectangle = new Rectangle();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // draw map item
            if (itemList["Map"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, map.Width, map.Height); 
                destinationRectangle = new Rectangle(mapX, mapY, mapWidth, mapHeight); 

                spriteBatch.Draw(map, destinationRectangle, sourceRectangle, Color.White);

                // draw map cells
                for (int i = 0; i < spotPosList.Count; i++)
                {
                    sourceRectangle = new Rectangle(0, 0, spot.Width, spot.Height);
                    destinationRectangle = new Rectangle(spotPosList[i].Item1 + spotOffsetX, spotPosList[i].Item2 + spotOffsetY, spotWidth, spotHeight);

                    spriteBatch.Draw(spot, destinationRectangle, sourceRectangle, Color.White);
                }

                // draw bridges
                for (int i = 0; i < bridgePosList.Count; i++)
                {
                    int width;
                    int height;
                    if (bridgePosList[i].Item1) // horizontal
                    {
                        width = bridgeSideLength.Item2;
                        height = bridgeSideLength.Item1;
                    }
                    else  // vertical
                    {
                        width = bridgeSideLength.Item1;
                        height = bridgeSideLength.Item2;
                    }
                    sourceRectangle = new Rectangle(0, 0, spot.Width, spot.Height);
                    destinationRectangle = new Rectangle((int)bridgePosList[i].Item2.X + spotOffsetX, (int)bridgePosList[i].Item2.Y + spotOffsetY, width, height);

                    spriteBatch.Draw(spot, destinationRectangle, sourceRectangle, Color.White);
                }
            }

            // draw compass item
            if (itemList["Compass"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, compass.Width, compass.Height);
                destinationRectangle = new Rectangle(compassX, compassY, compassWidth, compassHeight);

                spriteBatch.Draw(compass, destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public void Update(float newStartX, float newStartY)
        {
            mapX = 48 * scale + (int)newStartX;
            mapY = 112 * scale - 176 * scale + (int)newStartY - 56 * scale;
            compassX = 44 * scale + (int)newStartX;
            compassY = 152 * scale - 176 * scale + (int)newStartY - 56 * scale;
            spotOffsetX = (int)newStartX;
            spotOffsetY = (int)newStartY;

            // get new room position if room changes
            if (prevMapID != LoadAll.Instance.GetCurrentMapID())
            {
                prevMapID = LoadAll.Instance.GetCurrentMapID();

                // new room position
                string doorSide = PlayerAndBlockCollisionHandler.doorSide;
                int newSpotX = spotPosList[currSpotIndex].Item1;
                int newSpotY = spotPosList[currSpotIndex].Item2;
                // new bridge position
                bool horizontal = true;
                int newBridgeX = newSpotX;
                int newBridgeY = newSpotY;
                switch (doorSide)
                {
                    case "up":
                        newSpotY -= cellSideLenth;
                        horizontal = false;
                        newBridgeX += bridgeSideLength.Item2;
                        newBridgeY -= bridgeSideLength.Item2;
                        break;
                    case "down":
                        newSpotY += cellSideLenth;
                        horizontal = false;
                        newBridgeX += bridgeSideLength.Item2;
                        newBridgeY += spotHeight;
                        break;
                    case "left":
                        newSpotX -= cellSideLenth;
                        horizontal = true;
                        newBridgeX -= bridgeSideLength.Item2;
                        newBridgeY += bridgeSideLength.Item2;
                        break;
                    case "right":
                        newSpotX += cellSideLenth;
                        horizontal = true;
                        newBridgeX += spotWidth;
                        newBridgeY += bridgeSideLength.Item2;
                        break;
                    default:
                        break;
                }

                // traverse to see if the room is explored
                bool spotFound = false;
                bool bridgeFound = false;
                for (int i = 0; i < spotPosList.Count; i++)
                {
                    // change current position to the room if it is explored
                    if (!spotFound && spotPosList[i].Item1 == newSpotX && spotPosList[i].Item2 == newSpotY)
                    {
                        currSpotIndex = i;
                        spotFound = true;
                    }
                }
                for (int i = 0; i < bridgePosList.Count; i++)
                {
                    if (!bridgeFound && bridgePosList[i].Item2.X == newBridgeX && bridgePosList[i].Item2.Y == newBridgeY)
                    {
                        bridgeFound = true;
                    }
                }
                // add to list if not explored
                if (!spotFound)
                {
                    spotPosList.Add(new Tuple<int, int>(newSpotX, newSpotY));
                    currSpotIndex = spotPosList.Count - 1;
                }
                if (!bridgeFound)
                {
                    bridgePosList.Add(new Tuple<bool, Vector2>(horizontal, new Vector2(newBridgeX, newBridgeY)));

                }

            }
        }
    }
}
