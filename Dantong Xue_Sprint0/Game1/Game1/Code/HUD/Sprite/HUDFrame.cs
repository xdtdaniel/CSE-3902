using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Game1.Code.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.Code.HUD.Sprite
{
    class HUDFrame : IHUDSprite
    {
        // public
        public int level;

        // private
        private int scale;
        private int height;
        private int width;
        private int x;
        private int y;

        private Texture2D HUDFrameTexture;

        public HUDFrame()
        {
            level = 1;

            scale = (int)LoadAll.Instance.scale;
            height = 56 * scale;
            width = 256 * scale;
            x = (int)LoadAll.Instance.startPos.X;
            y = (int)LoadAll.Instance.startPos.Y - 56 * scale;

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
            y = (int)newStartY - 56 * scale;



            // todo
        }
    }
}
