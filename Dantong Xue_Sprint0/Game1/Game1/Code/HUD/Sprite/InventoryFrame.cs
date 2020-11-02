using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.HUD.Sprite
{
    class InventoryFrame : IHUDSprite
    {
        private int scale;
        private int height;
        private int width;
        private int x;
        private int minY;
        private int y;
        private int maxY;
        private int factor;

        private Texture2D Texture;
        public InventoryFrame() {
            scale = (int)LoadAll.Instance.scale;
            height = 88 * scale;
            width = 256 * scale;
            x = 0;
            minY = -176 * scale;
            y = minY;
            maxY = 0;
            factor = 1;

            Texture = HUDFactory.LoadInventoryFrame();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);  

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(bool enabled, int speed)
        {
            if (enabled)
            {
                if (y < maxY)
                {
                    y += speed;
                }
            }
            else
            {
                if (y > minY)
                {
                    y -= speed;
                }
            }
            // todo
        }
    }
}
