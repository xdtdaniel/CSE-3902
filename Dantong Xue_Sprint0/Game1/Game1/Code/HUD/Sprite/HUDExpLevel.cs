using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;

namespace Game1.Code.HUD.Sprite
{
    class HUDExpLevel : IHUDSprite
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
        private int preMapY = -48 * scale;
        private int preLevelX = 160 * scale;
        private int preLevelY = -24 * scale;

        //private Texture2D Texture;
        private Texture2D expLevelTexture;
        private int explevel;

        private IHUDSprite exp = new HUDExp();
        public HUDExpLevel(int level)
        {
            // Texture = HUDFactory.LoadDungeonMiniMapFrame();
            expLevelTexture = HUDFactory.LoadNumber(explevel)[1]; // level number has one digit
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // draw "LEVEL - "
            //Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
           // Rectangle destinationRectangle = new Rectangle(mapX, mapY, width, height);
            //spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            // draw exp level number
            sourceRectangle = new Rectangle(0, 0, expLevelTexture.Width, expLevelTexture.Height);
            destinationRectangle = new Rectangle(levelX, levelY, levelNumberSideLength, levelNumberSideLength);

            spriteBatch.Draw(expLevelTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(float newStartX, float newStartY)
        {
            //mapX = (int)newStartX + preMapX;
            //mapY = (int)newStartY + preMapY;
            levelX = (int)newStartX + preLevelX;
            levelY = (int)newStartY + preLevelY;
            explevel = HUDExp.getCurrentLevel();
            expLevelTexture = HUDFactory.LoadNumber(explevel)[1];
        }
    }
}