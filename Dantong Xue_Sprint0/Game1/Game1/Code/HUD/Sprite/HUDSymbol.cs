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
        private int yOrigin;
        private int yDistance;

        private Texture2D symbolX;
        public HUDSymbol()
        {
            scale = (int)LoadAll.Instance.scale;
            height = 8 * scale;
            width = 8 * scale;
            x = 96 * scale;
            y = new int[3];
            y[0] = 16 * scale;
            y[1] = 32 * scale;
            y[2] = 40 * scale;
            yOrigin = y[0];
            yDistance = 176 * scale;


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

        public void Update(bool enabled, int speed)
        {
            if (enabled)
            {
                if (y[0] < yOrigin + yDistance)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        y[i] += speed;
                    }
                }
            }
            else
            {
                if (y[0] > yOrigin )
                {
                    for (int i = 0; i < 3; i++)
                    {
                        y[i] -= speed;
                    }
                }
            }
            // todo
        }
    }
}
