using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Game1.Code.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System.Collections.Generic;
using System.Diagnostics;

namespace Game1.Code.HUD.Sprite
{
    class DungeonMiniMap : IHUDSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int miniMapHeight = 32 * scale;
        private int miniMapWidth = 64 * scale;
        private int greenSpotHeight = 3 * scale;
        private int greenSpotWidth = 3 * scale;
        private static int miniRoomWidth = 8 * scale;
        private static int miniRoomHeight = 4 * scale;

        private static int numberOfRoom = 18;
        private Vector2[] miniRoomPosOnMap = new Vector2[numberOfRoom];
        private Vector2 roomPos_1 = new Vector2(2 * miniRoomWidth, miniRoomHeight);
        private Vector2 roomPos_2 = new Vector2(3 * miniRoomWidth, miniRoomHeight);
        private Vector2 roomPos_3 = new Vector2(2 * miniRoomWidth, 2 * miniRoomHeight);
        private Vector2 roomPos_4 = new Vector2(3 * miniRoomWidth, 2 * miniRoomHeight);
        private Vector2 roomPos_5 = new Vector2(5 * miniRoomWidth, 2 * miniRoomHeight);
        private Vector2 roomPos_6 = new Vector2(6 * miniRoomWidth, 2 * miniRoomHeight);
        private Vector2 roomPos_7 = new Vector2(1 * miniRoomWidth, 3 * miniRoomHeight);
        private Vector2 roomPos_8 = new Vector2(2 * miniRoomWidth, 3 * miniRoomHeight);
        private Vector2 roomPos_9 = new Vector2(3 * miniRoomWidth, 3 * miniRoomHeight);
        private Vector2 roomPos_10 = new Vector2(4 * miniRoomWidth, 3 * miniRoomHeight);
        private Vector2 roomPos_11 = new Vector2(5 * miniRoomWidth, 3 * miniRoomHeight);
        private Vector2 roomPos_12 = new Vector2(2 * miniRoomWidth, 4 * miniRoomHeight);
        private Vector2 roomPos_13 = new Vector2(3 * miniRoomWidth, 4 * miniRoomHeight);
        private Vector2 roomPos_14 = new Vector2(4 * miniRoomWidth, 4 * miniRoomHeight);
        private Vector2 roomPos_15 = new Vector2(3 * miniRoomWidth, 5 * miniRoomHeight);
        private Vector2 roomPos_16 = new Vector2(2 * miniRoomWidth, 6 * miniRoomHeight);
        private Vector2 roomPos_17 = new Vector2(3 * miniRoomWidth, 6 * miniRoomHeight);
        private Vector2 roomPos_18 = new Vector2(4 * miniRoomWidth, 6 * miniRoomHeight);
        
        private int mapX;
        private int mapY;
        private int greenSpotX;
        private int greenSpotY;
        private int redSpotX;
        private int redSpotY;
        private int spotOffsetX = 0;
        private int spotOffsetY = 0;
        private Dictionary<string, int> itemList;

        private int preMapX = 16 * scale;
        private int preMapY = -36 * scale;
        private int preGreenSpotX = 42 * scale;
        private int preGreenSpotY = -12 * scale;
        private int preRedSpotX = 2 * scale;

        private int prevMapID;

        private Texture2D miniMap;
        private Texture2D greenSpot;
        private Texture2D redSpot; //indicate the room with triforce.
        public DungeonMiniMap(Dictionary<string, int> itemList) {
            this.itemList = itemList;

            miniRoomPosOnMap = new Vector2[numberOfRoom];
            miniRoomPosOnMap[0] = roomPos_1;
            miniRoomPosOnMap[1] = roomPos_2;
            miniRoomPosOnMap[2] = roomPos_3;
            miniRoomPosOnMap[3] = roomPos_4;
            miniRoomPosOnMap[4] = roomPos_5;
            miniRoomPosOnMap[5] = roomPos_6;
            miniRoomPosOnMap[6] = roomPos_7;
            miniRoomPosOnMap[7] = roomPos_8;
            miniRoomPosOnMap[8] = roomPos_9;
            miniRoomPosOnMap[9] = roomPos_10;
            miniRoomPosOnMap[10] = roomPos_11;
            miniRoomPosOnMap[11] = roomPos_12;
            miniRoomPosOnMap[12] = roomPos_13;
            miniRoomPosOnMap[13] = roomPos_14;
            miniRoomPosOnMap[14] = roomPos_15;
            miniRoomPosOnMap[15] = roomPos_16;
            miniRoomPosOnMap[16] = roomPos_17;
            miniRoomPosOnMap[17] = roomPos_18;

            prevMapID = LoadAll.Instance.GetCurrentMapID();

            miniMap = HUDFactory.LoadDungeonMiniMapCell_Level1();
            greenSpot = HUDFactory.LoadGreenSpot();
            redSpot = HUDFactory.LoadRedSpot();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            // draw mini map if link has a Map
            if (itemList["Map"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, miniMap.Width, miniMap.Height);
                destinationRectangle = new Rectangle(mapX, mapY, miniMapWidth, miniMapHeight);

                spriteBatch.Draw(miniMap, destinationRectangle, sourceRectangle, Color.White);
            }


            // draw link spot
            sourceRectangle = new Rectangle(0, 0, greenSpot.Width, greenSpot.Height);
            destinationRectangle = new Rectangle(greenSpotX, greenSpotY, greenSpotWidth, greenSpotHeight);

            spriteBatch.Draw(greenSpot, destinationRectangle, sourceRectangle, Color.White);

            //draw redspot if player have compass
            if (itemList["Compass"] > 0 && itemList["Map"] > 0) {
                int triforceRoomID = LoadItem.getTriforceRoom() - 1; // map id starts from 1

                redSpotX += (int)miniRoomPosOnMap[triforceRoomID].X;
                redSpotY += (int)miniRoomPosOnMap[triforceRoomID].Y;
               
                sourceRectangle = new Rectangle(0, 0, redSpot.Width, redSpot.Height);
                destinationRectangle = new Rectangle(redSpotX, redSpotY, greenSpotWidth, greenSpotHeight);

                spriteBatch.Draw(redSpot, destinationRectangle, sourceRectangle, Color.White);
            }

        }

        public void Update(float newStartX, float newStartY)
        {
            string doorSide = PlayerAndBlockCollisionHandler.doorSide;

            if (prevMapID != LoadAll.Instance.GetCurrentMapID()) {
                prevMapID = LoadAll.Instance.GetCurrentMapID();
                switch (doorSide)
                {
                    case "up":
                        spotOffsetY -= miniRoomHeight;
                        break;
                    case "down":
                        spotOffsetY += miniRoomHeight;
                        break;
                    case "left":
                        spotOffsetX -= miniRoomWidth;
                        break;
                    case "right":
                        spotOffsetX += miniRoomWidth;
                        break;
                    default:
                        break;
                }
            }
            mapX = (int)newStartX + preMapX;
            mapY = (int)newStartY + preMapY;
            greenSpotX = spotOffsetX + preGreenSpotX;
            greenSpotY = spotOffsetY + preGreenSpotY + (int)newStartY;
            //update red spot position wwith camera
            redSpotX = preRedSpotX + mapX;
            redSpotY = mapY;

        }
    }
}
