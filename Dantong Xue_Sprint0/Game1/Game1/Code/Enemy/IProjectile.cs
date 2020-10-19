using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Enemy
{
    public interface IProjectile
    {
        public void UpdateProjectile();
        public void DrawProjectile(SpriteBatch spriteBatch);
        public bool GetIsOnScreen();
        public void SetIsOnScreen(bool boolean);
        public void SetLocation(Vector2 location);
        public void SetDirection(int direction);
        public Rectangle GetRectangle();
        public void BounceBack();
    }
}
