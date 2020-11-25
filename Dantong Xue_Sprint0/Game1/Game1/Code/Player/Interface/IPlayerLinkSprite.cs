using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Player.Interface
{
    interface IPlayerLinkSprite
    {

        void Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, string direction);
    }
}
