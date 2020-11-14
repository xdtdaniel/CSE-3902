using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.Code.HUD.Sprite
{
    class DungeonPauseScreenFrame : IHUDSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int height = 88 * scale;
        private int width = 256 * scale;
        private int x;
        private int y;

        private int preY = -144 * scale;

        private Texture2D Texture;
        public DungeonPauseScreenFrame() {
            Texture = HUDFactory.LoadDungeonPauseScreenFrame();
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
