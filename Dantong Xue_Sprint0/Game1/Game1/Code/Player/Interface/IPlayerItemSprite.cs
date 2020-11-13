using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    interface IPlayerItemSprite
    {

        Rectangle Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction);
    }
}
