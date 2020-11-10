using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Game1.Code.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System.Collections.Generic;

namespace Game1.Code.HUD.Sprite
{
    class DungeonMiniMap : IHUDSprite
    {
        private int scale;
        private int miniMapHeight;
        private int miniMapWidth;
        private int spotHeight;
        private int spotWidth;


        private int mapX;
        private int mapY;
        private int spotX;
        private int spotY;
        private int spotOffsetX;
        private int spotOffsetY;
        private Dictionary<string, int> itemList;

        private int prevMapID;

        private Texture2D miniMap;
        private Texture2D spot;
        public DungeonMiniMap(Dictionary<string, int> itemList) {
            this.itemList = itemList;
            scale = (int)LoadAll.Instance.scale;
            miniMapHeight = 32 * scale;
            miniMapWidth = 64 * scale;
            spotHeight = 3 * scale;
            spotWidth = 3 * scale;
            mapX = 16 * scale + (int)LoadAll.Instance.startPos.X;
            mapY = 20 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
            spotX = 16 * scale + 26 * scale + (int)LoadAll.Instance.startPos.X;
            spotY = 20 * scale + 24 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
            spotOffsetX = 0;
            spotOffsetY = 0;
            prevMapID = LoadAll.Instance.GetCurrentMapID();

            miniMap = HUDFactory.LoadDungeonMiniMapCell_Level1();
            spot = HUDFactory.LoadGreenSpot();
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
            destinationRectangle = new Rectangle(spotX, spotY, spotWidth, spotHeight);

            spriteBatch.Draw(spot, destinationRectangle, sourceRectangle, Color.White);

        }

        public void Update(float newStartX, float newStartY)
        {
            string doorSide = PlayerAndBlockCollisionHandler.doorSide;

            if (prevMapID != LoadAll.Instance.GetCurrentMapID()) {
                prevMapID = LoadAll.Instance.GetCurrentMapID();
                switch (doorSide)
                {
                    case "up":
                        spotOffsetY -= 4 * scale;
                        break;
                    case "down":
                        spotOffsetY += 4 * scale;
                        break;
                    case "left":
                        spotOffsetX -= 8 * scale;
                        break;
                    case "right":
                        spotOffsetX += 8 * scale;
                        break;
                    default:
                        break;
                }
            }
            mapX = (int)newStartX + 16 * scale;
            mapY = (int)newStartY - 56 * scale + 20 * scale;
            spotX = spotOffsetX + 16 * scale + 26 * scale + (int)newStartX;
            spotY = spotOffsetY + 20 * scale + 24 * scale + (int)newStartY - 56 * scale;
           
        }
    }
}
