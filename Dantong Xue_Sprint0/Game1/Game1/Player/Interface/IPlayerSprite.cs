using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2
{
    interface IPlayerSprite
    {

        void Draw(SpriteBatch spriteBatch, int x, int y, int currentFrame, int direction);
    }
}
