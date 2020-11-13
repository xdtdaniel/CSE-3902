using Microsoft.Xna.Framework.Graphics;

namespace Game1.Player.Interface
{
    public interface IPlayerLinkState
    {
        void WoodenSwordAttack();
        void SwordBeamAttack();
        void UseItem();
        void TakeDamage(int dmgAmount);
        void KnockedBack(string collisionSide);
        void PickUp(int pickUp);
        void Update();
        void Draw(SpriteBatch spriteBatch);
        string GetStateName();
    }
}
