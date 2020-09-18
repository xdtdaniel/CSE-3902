using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    public interface IController
    {
        void Update(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Game1 g);

    }
}
