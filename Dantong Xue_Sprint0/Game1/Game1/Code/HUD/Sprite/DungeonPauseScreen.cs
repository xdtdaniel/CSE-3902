using Game1.Code.HUD.Factory;
using Game1.Code.Item.ItemFactory;
using Game1.Code.LoadFile;
using Game1.Code.Player;
using Game1.Code.Player.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Game1.Code.HUD.Sprite
{
    class DungeonPauseScreen : IHUDSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int mapHeight = 16 * scale;
        private int mapWidth = 8 * scale;
        private int compassHeight = 16 * scale;
        private int compassWidth = 15 * scale;
        private int cellSideLength = 6 * scale;
        private static int gridSideLenth = 8 * scale;
        private int bridgeSideLength = 2 * scale;
        private int spotSideLength = 4 * scale;

        private int spotX;
        private int spotY;
        private int firstCellPosX = 128 * scale + 3 * gridSideLenth + (int)LoadAll.Instance.startPos.X;
        private int firstCellPosY = -136 * scale + 7 * gridSideLenth;

        private int mapX;
        private int mapY;
        private int compassX;
        private int compassY;
        private List<Tuple<int, int>> cellPosList;
        private List<Tuple<bool, Vector2>> bridgePosList;
        private int currCellIndex = 0;
        private int prevMapID;
        private int pauseScreenStartPosX;
        private int pauseScreenStartPosY;

        private int preMapX = 48 * scale;
        private int preMapY = -120 * scale;
        private int preCompassX = 44 * scale;
        private int preCompassY = -80 * scale;

        private Dictionary<string, int> itemList;

        private Texture2D map;
        private Texture2D compass;
        private Texture2D cell;
        private Texture2D spot;

        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public DungeonPauseScreen(Dictionary<string, int> itemList) {
            this.itemList = itemList;

            // positions
            cellPosList = new List<Tuple<int, int>>();
            cellPosList.Add(new Tuple<int, int>(firstCellPosX, firstCellPosY));
            bridgePosList = new List<Tuple<bool, Vector2>>();

            // the bool variable: true if the bridge is horizontal, false if vertical
            bridgePosList.Add(new Tuple<bool, Vector2>(false, new Vector2(cellPosList[0].Item1 + bridgeSideLength * scale, cellPosList[0].Item2 + cellSideLength * scale)));

            prevMapID = LoadAll.Instance.GetCurrentMapID();
            spotX = cellPosList[0].Item1 + (cellSideLength - spotSideLength) / 2;
            spotY = cellPosList[0].Item2 + (cellSideLength - spotSideLength) / 2;

            // textures
            map = ItemSpriteFactory.CreateMap();
            compass = ItemSpriteFactory.CreateCompass();
            cell = HUDFactory.LoadBlackSpot();
            spot = HUDFactory.LoadGreenSpot();

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
            }
            // draw map cells
            for (int i = 0; i < cellPosList.Count; i++)
            {
                sourceRectangle = new Rectangle(0, 0, cell.Width, cell.Height);
                destinationRectangle = new Rectangle(cellPosList[i].Item1 + pauseScreenStartPosX, cellPosList[i].Item2 + pauseScreenStartPosY, cellSideLength, cellSideLength);

                spriteBatch.Draw(cell, destinationRectangle, sourceRectangle, Color.White);
            }

            // draw bridges
            for (int i = 0; i < bridgePosList.Count; i++)
            {
                int width;
                int height;
                if (bridgePosList[i].Item1) // horizontal
                {
                    width = bridgeSideLength;
                    height = bridgeSideLength;
                }
                else  // vertical
                {
                    width = bridgeSideLength;
                    height = bridgeSideLength;
                }
                sourceRectangle = new Rectangle(0, 0, cell.Width, cell.Height);
                destinationRectangle = new Rectangle((int)bridgePosList[i].Item2.X + pauseScreenStartPosX, (int)bridgePosList[i].Item2.Y + pauseScreenStartPosY, width, height);

                spriteBatch.Draw(cell, destinationRectangle, sourceRectangle, Color.White);
            }
        

            // draw compass item
            if (itemList["Compass"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, compass.Width, compass.Height);
                destinationRectangle = new Rectangle(compassX, compassY, compassWidth, compassHeight);

                spriteBatch.Draw(compass, destinationRectangle, sourceRectangle, Color.White);
            }

            // draw spot
            sourceRectangle = new Rectangle(0, 0, spot.Width, spot.Height);
            destinationRectangle = new Rectangle(spotX + pauseScreenStartPosX, spotY + pauseScreenStartPosY, spotSideLength, spotSideLength);

            spriteBatch.Draw(spot, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(float newStartX, float newStartY)
        {
            mapX = preMapX + (int)newStartX;
            mapY = preMapY + (int)newStartY;
            compassX = preCompassX + (int)newStartX;
            compassY = preCompassY + (int)newStartY;
            pauseScreenStartPosX = (int)newStartX;
            pauseScreenStartPosY = (int)newStartY;

            string doorSide = PlayerAndBlockCollisionHandler.doorSide;
            // get new room position if room changes
            if (prevMapID != LoadAll.Instance.GetCurrentMapID())
            {
                prevMapID = LoadAll.Instance.GetCurrentMapID();

                // new room position
                int newSpotX = cellPosList[currCellIndex].Item1;
                int newSpotY = cellPosList[currCellIndex].Item2;
                // new bridge position
                bool horizontal = true;
                int newBridgeX = newSpotX;
                int newBridgeY = newSpotY;
                switch (doorSide)
                {
                    case "up":
                        newSpotY -= gridSideLenth;
                        horizontal = false;
                        newBridgeX += bridgeSideLength;
                        newBridgeY -= bridgeSideLength;
                        break;
                    case "down":
                        newSpotY += gridSideLenth;
                        horizontal = false;
                        newBridgeX += bridgeSideLength;
                        newBridgeY += cellSideLength;
                        break;
                    case "left":
                        newSpotX -= gridSideLenth;
                        horizontal = true;
                        newBridgeX -= bridgeSideLength;
                        newBridgeY += bridgeSideLength;
                        break;
                    case "right":
                        newSpotX += gridSideLenth;
                        horizontal = true;
                        newBridgeX += cellSideLength;
                        newBridgeY += bridgeSideLength;
                        break;
                    default:
                        break;
                }

                // traverse to see if the room is explored
                bool spotFound = false;
                bool bridgeFound = false;
                for (int i = 0; i < cellPosList.Count; i++)
                {
                    // change current position to the room if it is explored
                    if (!spotFound && cellPosList[i].Item1 == newSpotX && cellPosList[i].Item2 == newSpotY)
                    {
                        currCellIndex = i;
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
                    cellPosList.Add(new Tuple<int, int>(newSpotX, newSpotY));
                    currCellIndex = cellPosList.Count - 1;
                }
                if (!bridgeFound)
                {
                    bridgePosList.Add(new Tuple<bool, Vector2>(horizontal, new Vector2(newBridgeX, newBridgeY)));

                }
            }
            spotX = cellPosList[currCellIndex].Item1 + (cellSideLength - spotSideLength) / 2;
            spotY = cellPosList[currCellIndex].Item2 + (cellSideLength - spotSideLength) / 2;
        }
    }
}
