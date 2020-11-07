using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Game1.Code.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace Game1.Code.HUD.Sprite
{
    class InventoryFrame : IHUDSprite
    {
        private int scale;
        private int height;
        private int width;
        private int x;
        private int y;

        private Texture2D Texture;
        public InventoryFrame() {
            scale = (int)LoadAll.Instance.scale;
            height = 88 * scale;
            width = 256 * scale;
            x = (int)LoadAll.Instance.startPos.X;
            y = -176 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;

            Texture = HUDFactory.LoadInventoryFrame();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);  

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX;
            y = (int)newStartY - 56 * scale - 176 * scale;
            // todo
        }
    }
}
