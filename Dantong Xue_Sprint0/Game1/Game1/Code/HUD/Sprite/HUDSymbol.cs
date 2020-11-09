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
        private int[] x;
        private int[] y;
        private int numberOfSymbol;

        private Texture2D symbolX;
        public HUDSymbol()
        {
            scale = (int)LoadAll.Instance.scale;
            numberOfSymbol = 4;
            height = 8 * scale;
            width = 8 * scale;
            x = new int[numberOfSymbol];
            y = new int[numberOfSymbol];


            symbolX = HUDFactory.LoadX();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, symbolX.Width, symbolX.Height);
            for (int i = 0; i < numberOfSymbol; i++)
            {
                Rectangle destinationRectangle = new Rectangle(x[i], y[i], width, height);

                spriteBatch.Draw(symbolX, destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public void Update(float newStartX, float newStartY)
        {
            x[0] = 96 * scale + (int)newStartX;
            x[1] = 96 * scale + (int)newStartX;
            x[2] = 96 * scale + (int)newStartX;
            x[3] = 136 * scale + (int)newStartX;
            y[0] = (int)newStartY - 56 * scale + 16 * scale;
            y[1] = (int)newStartY - 56 * scale + 32 * scale;
            y[2] = (int)newStartY - 56 * scale + 40 * scale;
            y[3] = -176 * scale + 32 * scale + (int)newStartY - 56 * scale;
            // todo
        }
    }
}
