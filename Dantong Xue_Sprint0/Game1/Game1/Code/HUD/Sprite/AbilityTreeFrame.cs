using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Game1.Code.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.Code.HUD.Sprite
{
    class AbilityTreeFrame : IHUDSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int height = 176 * scale;
        private int width = 256 * scale;
        private int x;
        private int y;
        private int apOffset_x = 150 * scale;
        private int apOffset_y = 160 * scale;

        private int preY = 176 * scale;

        private Texture2D AbilityTreeFrameTexture;

        private Game1 game;

        public AbilityTreeFrame(Game1 game)
        {
            AbilityTreeFrameTexture = HUDFactory.LoadAbilityTreeFrame();
            this.game = game;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, AbilityTreeFrameTexture.Width, AbilityTreeFrameTexture.Height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);  

            spriteBatch.Draw(AbilityTreeFrameTexture, destinationRectangle, sourceRectangle, Color.White);

            string ap = "Ability Point: " + game.link.abilityPoint;
            spriteBatch.DrawString(game._spriteFont, ap.ToString(), new Vector2(x + apOffset_x, y + apOffset_y), Color.White);
        }

        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX;
            y = (int)newStartY + preY;
        }
    }
}
