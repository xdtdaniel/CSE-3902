using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Game1.Code.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.Code.HUD.Sprite
{
    class DashChargeIndicator : IHUDSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int dashChargeOffset_x = 3 * scale;
        private int dashChargeOffset_y = 16 * scale;
        private int glitterOffset_x = 2 * scale;
        private int glitterOffset_y = 20 * scale;
        private int dashChargeWidth = 6 * scale;
        private int dashChargeHeight = 3 * scale;
        private int glitterWidth = 8 * scale;
        private int glitterHeight = 4 * scale;
        private float transparency = 0;

        private int glitterCurrentFrame = 0;
        private int glitterSecondFrame = 0;
        private int glitterSecondFrameThreshold = 10;
        private int glitterTotalFrame = 3;

        private bool glittered = false;

        private Texture2D emptyDashCharge;
        private Texture2D fullDashCharge;
        private Texture2D[] dashChargeGlitter;

        private Game1 game;

        public DashChargeIndicator(Game1 game)
        {
            emptyDashCharge = HUDFactory.LoadEmptyDashChagre();
            fullDashCharge = HUDFactory.LoadFullDashCharge();
            dashChargeGlitter = HUDFactory.LoadDashChargeGlitter();
            this.game = game;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // draw indicator frame
            Rectangle sourceRectangle = new Rectangle(0, 0, emptyDashCharge.Width, emptyDashCharge.Height);
            Rectangle destinationRectangle = new Rectangle(game.link.x + dashChargeOffset_x, game.link.y + dashChargeOffset_y, dashChargeWidth, dashChargeHeight);

            spriteBatch.Draw(emptyDashCharge, destinationRectangle, sourceRectangle, Color.White);

            // draw filled indicator if dash is ready
            sourceRectangle = new Rectangle(0, 0, fullDashCharge.Width, fullDashCharge.Height);
            destinationRectangle = new Rectangle(game.link.x + dashChargeOffset_x, game.link.y + dashChargeOffset_y, dashChargeWidth, dashChargeHeight);

            spriteBatch.Draw(fullDashCharge, destinationRectangle, sourceRectangle, Color.White * transparency);

            // glitter once when dash is ready
            if (!glittered && transparency == 1)
            {
                sourceRectangle = new Rectangle(0, 0, dashChargeGlitter[glitterCurrentFrame].Width, dashChargeGlitter[glitterCurrentFrame].Height);
                destinationRectangle = new Rectangle(game.link.x + glitterOffset_x, game.link.y + glitterOffset_y, glitterWidth, glitterHeight);

                spriteBatch.Draw(dashChargeGlitter[glitterCurrentFrame], destinationRectangle, sourceRectangle, Color.White * transparency);

            }

        }

        public void Update(float newStartX, float newStartY)
        {
            transparency = (float)game.link.timeSinceDash / game.link.timeBetweenDash;
            if (glittered && transparency != 1)
            {
                glittered = false;
            }

            if (!glittered && transparency == 1)
            {
                glitterSecondFrame++;
                if (glitterSecondFrame == glitterSecondFrameThreshold)
                {
                    glitterSecondFrame = 0;
                    glitterCurrentFrame++;
                }
                if (glitterCurrentFrame == glitterTotalFrame)
                {
                    glitterCurrentFrame = 0;
                    glittered = true;
                }
            }
        }
    }
}
