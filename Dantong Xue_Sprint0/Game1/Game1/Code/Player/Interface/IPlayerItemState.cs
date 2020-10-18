using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Player.Interface
{
    public interface IPlayerItemState
    {
        void UseItem(int itemNum);
        void Update();
        Rectangle GetRectangle();
        void Draw(SpriteBatch spriteBatch);
    }
}
