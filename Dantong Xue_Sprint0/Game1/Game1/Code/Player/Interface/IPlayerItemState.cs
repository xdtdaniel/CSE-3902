using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Player.Interface
{
    public interface IPlayerItemState
    {
        void UseItem(string itemName);
        string GetItemName();
        void Update();
        void CollisionResponse();
        void Draw(SpriteBatch spriteBatch);
        Rectangle GetRectangle();
        bool IsDone();
    }
}
