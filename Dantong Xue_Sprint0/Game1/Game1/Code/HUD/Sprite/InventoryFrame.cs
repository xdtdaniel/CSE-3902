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
        private static int scale = (int)LoadAll.Instance.scale;
        private int height = 88 * scale;
        private int width = 256 * scale;
        private int x;
        private int y;

        private int preY = -232 * scale;

        private Texture2D Texture;
        public InventoryFrame() {
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
            y = (int)newStartY + preY;
        }
    }
}
