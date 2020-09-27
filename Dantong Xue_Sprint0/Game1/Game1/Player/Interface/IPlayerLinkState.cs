using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Player.Interface
{
    public interface IPlayerLinkState
    {
        void AttackN();
        void AttackZ();
        void UseItem();
        void TakeDamage();
        void PickUp(int pickUp);
        void Update(ref int x, ref int y, int direction, bool isMoving);
        void Draw(SpriteBatch spriteBatch, int x, int y, int direction);
    }
}
