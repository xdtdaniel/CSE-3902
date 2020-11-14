using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Game1.Code.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.Code.HUD.Sprite
{
    class HUDFrame : IHUDSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int height = 56 * scale;
        private int width = 256 * scale;
        private int x;
        private int y;

        private int preY = -56 * scale;

        private Texture2D HUDFrameTexture;

        public HUDFrame()
        {
            HUDFrameTexture = HUDFactory.LoadHUDFrame();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, HUDFrameTexture.Width, HUDFrameTexture.Height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);  

            spriteBatch.Draw(HUDFrameTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX;
            y = (int)newStartY + preY;
        }
    }
}
