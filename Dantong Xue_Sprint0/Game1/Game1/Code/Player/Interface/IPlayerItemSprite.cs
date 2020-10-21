using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    interface IPlayerItemSprite
    {

        Rectangle Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction);
    }
}
