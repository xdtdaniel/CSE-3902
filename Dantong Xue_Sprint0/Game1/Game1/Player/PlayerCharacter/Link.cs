using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Player.PlayerCharacter
{
    public class Link 
    {
        public int x;
        public int y;
        public int damageTimeCounter;
        public bool isDamaged;

        PlayerItem item;

        public IPlayerLinkState state;
        public Link()
        {
            x = 300;
            y = 300;
            damageTimeCounter = 0;
            isDamaged = false;

            state = new NormalLink(this);

            item = new PlayerItem();
            item.state = new NoItem(item);
        }

        public void AttackN()
        {
            state.AttackN();
        }
        public void AttackZ()
        {
            state.AttackZ();
        }
        public void UseItem(int itemNum)
        {
            state.UseItem();
            item.UseItem(itemNum);
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
            item.Update(x, y, direction);
        }
        public void Draw(SpriteBatch spriteBatch, int direction)
        {
            state.Draw(spriteBatch, x, y, direction);
            item.Draw(spriteBatch);
        }
    }
}
