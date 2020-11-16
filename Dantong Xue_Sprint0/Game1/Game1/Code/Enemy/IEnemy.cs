using System;
using System.Collections.Generic;
using System.Text;
using Game1.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public interface IEnemy
    {
        public void UpdateEnemy(Game1 game);
        public void DrawEnemy(SpriteBatch spriteBatch, Vector2 startPosition);
        public void FireProjectile();
        public Rectangle GetRectangle();
        public List<IProjectile> GetProjectile();
        public void TakeDamage(int damageAmount);
        public int GetHP();
        public void Freeze();
    }
}
