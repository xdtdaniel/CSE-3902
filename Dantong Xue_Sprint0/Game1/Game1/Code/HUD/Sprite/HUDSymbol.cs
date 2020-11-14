using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.Code.HUD.Sprite
{
    class HUDSymbol : IHUDSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int height = 8 * scale;
        private int width = 8 * scale;
        private int[] x;
        private int[] y;
        private int numberOfMultipleSymbol = 4;

        private int preX_0 = 96 * scale;
        private int preX_1 = 96 * scale;
        private int preX_2 = 96 * scale;
        private int preX_3 = 136 * scale;
        private int preY_0 = -40 * scale;
        private int preY_1 = -24 * scale;
        private int preY_2 = -16 * scale;
        private int preY_3 = -200 * scale;

        private Texture2D symbolX;
        public HUDSymbol()
        {
            x = new int[numberOfMultipleSymbol];
            y = new int[numberOfMultipleSymbol];

            symbolX = HUDFactory.LoadX();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, symbolX.Width, symbolX.Height);
            for (int i = 0; i < numberOfMultipleSymbol; i++)
            {
                Rectangle destinationRectangle = new Rectangle(x[i], y[i], width, height);

                spriteBatch.Draw(symbolX, destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public void Update(float newStartX, float newStartY)
        {
            x[0] = preX_0 + (int)newStartX;
            x[1] = preX_1 + (int)newStartX;
            x[2] = preX_2 + (int)newStartX;
            x[3] = preX_3 + (int)newStartX;
            y[0] = preY_0 + (int)newStartY;
            y[1] = preY_1 + (int)newStartY;
            y[2] = preY_2 + (int)newStartY;
            y[3] = preY_3 + (int)newStartY;
        }
    }
}
