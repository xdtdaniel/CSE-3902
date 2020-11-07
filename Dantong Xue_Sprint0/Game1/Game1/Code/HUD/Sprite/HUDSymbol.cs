using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.Code.HUD.Sprite
{
    class HUDSymbol : IHUDSprite
    {
        private int scale;
        private int height;
        private int width;
        private int x;
        private int[] y;

        private Texture2D symbolX;
        public HUDSymbol()
        {
            scale = (int)LoadAll.Instance.scale;
            height = 8 * scale;
            width = 8 * scale;
            x = 96 * scale + (int)LoadAll.Instance.startPos.X;
            y = new int[3];
            y[0] = 16 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
            y[1] = 32 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
            y[2] = 40 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;


            symbolX = HUDFactory.LoadX();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, symbolX.Width, symbolX.Height);
            for (int i = 0; i < 3; i++)
            {
                Rectangle destinationRectangle = new Rectangle(x, y[i], width, height);

                spriteBatch.Draw(symbolX, destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX + 96 * scale;
            y[0] = (int)newStartY - 56 * scale + 16 * scale;
            y[1] = (int)newStartY - 56 * scale + 32 * scale;
            y[2] = (int)newStartY - 56 * scale + 40 * scale;
            // todo
        }
    }
}
