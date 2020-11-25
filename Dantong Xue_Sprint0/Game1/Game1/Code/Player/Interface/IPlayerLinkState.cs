using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Player.Interface
{
    public interface IPlayerLinkState
    {
        void UseItem();
        void TakeDamage(int dmgAmount);
        void KnockedBack(string collisionSide);
        void PickUp(int pickUp);
        void Update();
        void Draw(SpriteBatch spriteBatch);
        string GetStateName();
    }
}
