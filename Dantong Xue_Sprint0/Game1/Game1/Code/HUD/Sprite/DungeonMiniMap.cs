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
        private int blueSpotHeight = 3 * scale;
        private int blueSpotWidth = 3 * scale;
        private int miniRoomWidth = 8 * scale;
        private int miniRoomHeight = 4 * scale;


        private int mapX;
        private int mapY;
        private int blueSpotX;
        private int blueSpotY;
        private int redSpotX;
        private int redSpotY;
        private int spotOffsetX = 0;
        private int spotOffsetY = 0;
        private Dictionary<string, int> itemList;

        private int preMapX = 16 * scale;
        private int preMapY = -36 * scale;
        private int preBlueSpotX = 42 * scale;
        private int preBlueSpotY = -12 * scale;
        private int preRedSpotX = 48 * scale;
        private int preRedSpotY = -48 * scale;

        private int prevMapID;

        private Texture2D miniMap;
        private Texture2D spot;
        private Texture2D redSpot; //indicate the room with triforce.
        public DungeonMiniMap(Dictionary<string, int> itemList) {
            this.itemList = itemList;

            prevMapID = LoadAll.Instance.GetCurrentMapID();

            miniMap = HUDFactory.LoadDungeonMiniMapCell_Level1();
            spot = HUDFactory.LoadGreenSpot();
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
            sourceRectangle = new Rectangle(0, 0, spot.Width, spot.Height);
            destinationRectangle = new Rectangle(blueSpotX, blueSpotY, blueSpotWidth, blueSpotHeight);

            spriteBatch.Draw(spot, destinationRectangle, sourceRectangle, Color.White);

            //draw redspot if player have compass
            if (itemList["Compass"] > 0 &&itemList["Map"]>0) {
                if (LoadItem.getTriforceRoom() == 1 || LoadItem.getTriforceRoom() == 2)
                {                   
                    redSpotX -= LoadItem.getTriforceRoom() * miniRoomWidth;
                }
                if (LoadItem.getTriforceRoom() == 4) 
                {
                    redSpotX += miniRoomWidth * 2;
                    redSpotY += miniRoomHeight;
                }
                if (LoadItem.getTriforceRoom() == 5|| LoadItem.getTriforceRoom() == 6)
                {
                    redSpotX += miniRoomWidth* LoadItem.getTriforceRoom()-1;
                    redSpotY += miniRoomHeight;
                }
                if (LoadItem.getTriforceRoom() == 8)
                {
                    redSpotX += miniRoomWidth;
                    redSpotY += miniRoomHeight*2;
                }
                if (LoadItem.getTriforceRoom() == 9)
                {
                    redSpotX += miniRoomWidth*2;
                    redSpotY += miniRoomHeight * 2;
                }
                if (LoadItem.getTriforceRoom() == 10)
                {
                    redSpotX += miniRoomWidth * 3;
                    redSpotY += miniRoomHeight * 2;
                }
                if (LoadItem.getTriforceRoom() == 11)
                {
                    redSpotX += miniRoomWidth * 4;
                    redSpotY += miniRoomHeight * 2;
                }
                if (LoadItem.getTriforceRoom() == 12)
                {
                    redSpotX += miniRoomWidth;
                    redSpotY += miniRoomHeight * 3;
                }
                if (LoadItem.getTriforceRoom() == 13)
                {
                    redSpotX += miniRoomWidth * 2;
                    redSpotY += miniRoomHeight * 3;
                }
                if (LoadItem.getTriforceRoom() == 14)
                {
                    redSpotX += miniRoomWidth * 3;
                    redSpotY += miniRoomHeight * 3;
                }
                if (LoadItem.getTriforceRoom() == 15)
                {
                    redSpotX += miniRoomWidth * 2;
                    redSpotY += miniRoomHeight * 4;
                }
                if (LoadItem.getTriforceRoom() == 16)
                {
                    redSpotX += miniRoomWidth;
                    redSpotY += miniRoomHeight * 5;
                }
                if (LoadItem.getTriforceRoom() == 17)
                {
                    Debug.WriteLine("roomID: " + LoadItem.getTriforceRoom());
                    redSpotX += miniRoomWidth*2;
                    redSpotY += miniRoomHeight * 5;
                }
                if (LoadItem.getTriforceRoom() == 18)
                {
                    redSpotX += miniRoomWidth*3;
                    redSpotY += miniRoomHeight * 5;
                }

                //draw red spot if have compass
                sourceRectangle = new Rectangle(0, 0, redSpot.Width, redSpot.Height);
                destinationRectangle = new Rectangle(redSpotX, redSpotY, blueSpotWidth, blueSpotHeight);
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
            blueSpotX = spotOffsetX + preBlueSpotX + (int)newStartX;
            blueSpotY = spotOffsetY + preBlueSpotY + (int)newStartY;
            //update red spot position wwith camera
            redSpotX =  preRedSpotX + blueSpotWidth+(int)newStartX;
            redSpotY =  preRedSpotY + (int)newStartY;

        }
    }
}
