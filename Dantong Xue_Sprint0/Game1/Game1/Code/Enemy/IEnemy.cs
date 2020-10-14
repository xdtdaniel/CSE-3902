using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public interface IEnemy
    {
        public void UpdateEnemy(Game game);
        public void DrawEnemy(SpriteBatch spriteBatch);
        public void FireProjectile();
        public Rectangle GetRectangle();
    }
}
