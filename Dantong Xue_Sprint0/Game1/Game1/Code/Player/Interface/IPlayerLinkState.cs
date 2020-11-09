using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Player.Interface
{
    public interface IPlayerLinkState
    {
        void AttackN();
        void AttackZ();
        void UseItem();
        void TakeDamage(int dmgAmount);
        void KnockedBack(string collisionSide);
        void PickUp(int pickUp);
        void Update();
        void Draw(SpriteBatch spriteBatch);
        string GetStateName();
    }
}
