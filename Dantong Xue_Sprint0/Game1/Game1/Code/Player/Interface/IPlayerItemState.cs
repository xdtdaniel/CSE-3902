using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Player.Interface
{
    public interface IPlayerItemState
    {
        string GetItemName();
        void Update();
        void CollisionResponse(int enemyIndex);
        void Draw(SpriteBatch spriteBatch);
        Rectangle GetRectangle();
        int GetDamage();
        bool IsDone();
    }
}
