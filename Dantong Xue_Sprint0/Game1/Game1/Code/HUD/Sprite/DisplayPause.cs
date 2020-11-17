using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Game1.Code.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.Code.HUD.Sprite
{
    class DisplayPause : IHUDSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int x;
        private int y;

        private int preY = -56 * scale;

        private Texture2D pauseTexture;

        private Game1 game;

        public DisplayPause(Game1 game)
        {
            pauseTexture = HUDFactory.LoadPause();
            this.game = game;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (game.camera.pausedType == 0)
            {
                Rectangle sourceRectangle = new Rectangle(0, 0, pauseTexture.Width, pauseTexture.Height);
                Rectangle destinationRectangle = new Rectangle(x, y, game._graphics.PreferredBackBufferWidth, game._graphics.PreferredBackBufferHeight);

                spriteBatch.Draw(pauseTexture, destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX;
            y = (int)newStartY + preY;
        }
    }
}
