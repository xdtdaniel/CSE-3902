
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Player.Interface
{
    public interface IPlayerAbility
    {
        void Update();
        void Use();
        string GetAbilityName();
        bool IsLearned();
        void Learn();
    }
}
