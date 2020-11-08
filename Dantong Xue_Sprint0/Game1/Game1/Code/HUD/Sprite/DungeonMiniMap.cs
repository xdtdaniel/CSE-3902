using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;

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

        private Texture2D miniMap;
        private Texture2D spot;
        public DungeonMiniMap(int level) {
            scale = (int)LoadAll.Instance.scale;
            miniMapHeight = 32 * scale;
            miniMapWidth = 64 * scale;
            spotHeight = 3 * scale;
            spotWidth = 3 * scale;
            mapX = 16 * scale + (int)LoadAll.Instance.startPos.X;
            mapY = 20 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
            spotX = 16 * scale + 26 * scale + (int)LoadAll.Instance.startPos.X;
            spotY = 20 * scale + 24 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;


            miniMap = HUDFactory.LoadDungeonMiniMapCell_Level1();
            spot = HUDFactory.LoadGreenSpot();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, miniMap.Width, miniMap.Height);
            Rectangle destinationRectangle = new Rectangle(mapX, mapY, miniMapWidth, miniMapHeight);  

            spriteBatch.Draw(miniMap, destinationRectangle, sourceRectangle, Color.White);


            sourceRectangle = new Rectangle(0, 0, spot.Width, spot.Height);
            destinationRectangle = new Rectangle(spotX, spotY, spotWidth, spotHeight);

            spriteBatch.Draw(spot, destinationRectangle, sourceRectangle, Color.White);

        }

        public void Update(float newStartX, float newStartY)
        {
            mapX = (int)newStartX + 16 * scale;
            mapY = (int)newStartY - 56 * scale + 20 * scale;
            spotX = 16 * scale + 26 * scale + (int)LoadAll.Instance.startPos.X;
            spotY = 20 * scale + 24 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
            // todo
        }
    }
}
