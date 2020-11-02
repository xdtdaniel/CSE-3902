using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;

namespace Game1.Code.HUD.Sprite
{
    class DungeonMiniMapFrame : IHUDSprite
    {
        private int scale;
        private int height;
        private int width;
        private int levelNumberSideLength;
        private int mapX;
        private int minMapY;
        private int mapY;
        private int levelX;
        private int levelY;
        private int maxMapY;

        private Texture2D Texture;
        private Texture2D[] levelTexture;
        public DungeonMiniMapFrame(int level) {
            scale = (int)LoadAll.Instance.scale;
            height = 40 * scale;
            width = 64 * scale;
            levelNumberSideLength = 8 * scale;
            mapX = 16 * scale;
            minMapY = 8 * scale;
            mapY = minMapY;
            levelX = 64 * scale;
            levelY = mapY;
            maxMapY = 184 * scale;

            Texture = HUDFactory.LoadDungeonMiniMapFrame();
            levelTexture = new Texture2D[2];
            levelTexture = HUDFactory.LoadNumber(level);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // draw "LEVEL - "
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Rectangle destinationRectangle = new Rectangle(mapX, mapY, width, height);  

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            // draw level number
            sourceRectangle = new Rectangle(0, 0, levelTexture[0].Width, levelTexture[0].Height);
            destinationRectangle = new Rectangle(levelX, levelY, levelNumberSideLength, levelNumberSideLength);

            spriteBatch.Draw(levelTexture[0], destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(bool enabled, int speed)
        {
            if (enabled)
            {
                if (mapY < maxMapY)
                {
                    mapY += speed;
                    levelY += speed;
                }
            }
            else
            {
                if (mapY > minMapY)
                {
                    mapY -= speed;
                    levelY -= speed;
                }
            }
            // todo
        }
    }
}
