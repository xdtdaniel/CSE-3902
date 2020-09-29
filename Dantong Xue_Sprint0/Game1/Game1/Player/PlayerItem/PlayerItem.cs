using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Player.PlayerCharacter
{
    public class PlayerItem
    {
        public IPlayerItemDrawer state;

        public int x;
        public int y;
        public int direction;
        public PlayerItem()
        {
            this.state = new NoItem(this);
            x = 0;
            y = 0;
            direction = -1;
        }

        public void UseItem(int itemNum)
        {
            state.UseItem(itemNum);
        }
        public void Update(int x, int y, int direction)
        {
            state.Update();
            this.x = x;
            this.y = y;
            this.direction = direction;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }
    }
}
