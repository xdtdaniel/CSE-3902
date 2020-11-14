using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;

namespace Game1.Code.HUD.Sprite
{
    class DungeonMiniMapFrame : IHUDSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int height = 40 * scale;
        private int width = 64 * scale;
        private int levelNumberSideLength = 8 * scale;
        private int mapX;
        private int mapY;
        private int levelX;
        private int levelY;

        private int preMapX = 16 * scale;
        private int preMapY = - 48 * scale;
        private int preLevelX = 64 * scale;
        private int preLevelY = -48 * scale;

        private Texture2D Texture;
        private Texture2D levelTexture;
        public DungeonMiniMapFrame(int level) {
            Texture = HUDFactory.LoadDungeonMiniMapFrame();
            levelTexture = HUDFactory.LoadNumber(level)[1]; // level number has one digit
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // draw "LEVEL - "
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Rectangle destinationRectangle = new Rectangle(mapX, mapY, width, height);  

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            // draw level number
            sourceRectangle = new Rectangle(0, 0, levelTexture.Width, levelTexture.Height);
            destinationRectangle = new Rectangle(levelX, levelY, levelNumberSideLength, levelNumberSideLength);

            spriteBatch.Draw(levelTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(float newStartX, float newStartY)
        {
            mapX = (int)newStartX + preMapX;
            mapY = (int)newStartY + preMapY;
            levelX = (int)newStartX + preLevelX;
            levelY = (int)newStartY + preLevelY;
        }
    }
}
