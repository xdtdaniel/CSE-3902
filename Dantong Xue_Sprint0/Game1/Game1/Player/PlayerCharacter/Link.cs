using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Player.PlayerCharacter
{
    public class Link 
    {
        public int x;
        public int y;
        public int damageTimeCounter;
        public bool isDamaged;

        public IPlayerLinkState state;
        public Link()
        {
            x = 300;
            y = 300;
            damageTimeCounter = 0;
            isDamaged = false;

            state = new NormalLink(this);
        }

        public void AttackN()
        {
            state.AttackN();
        }
        public void AttackZ()
        {
            state.AttackZ();
        }
        public void UseItem()
        {
            state.UseItem();
        }
        public void TakeDamage()
        {
            state.TakeDamage();
        }
        public void PickUp(int pickUp)
        {
            state.PickUp(pickUp);
        }
        public void Update(int direction, bool isMoving)
        {
            state.Update(ref x, ref y, direction, isMoving);
        }
        public void Draw(SpriteBatch spriteBatch, int direction)
        {
            state.Draw(spriteBatch, x, y, direction);
        }
    }
}
