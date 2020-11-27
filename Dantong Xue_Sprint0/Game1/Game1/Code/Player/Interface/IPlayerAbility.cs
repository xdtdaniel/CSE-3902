
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Player.Interface
{
    public interface IPlayerAbility
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
        string GetAbilityName();
        bool IsDone();
    }
}
