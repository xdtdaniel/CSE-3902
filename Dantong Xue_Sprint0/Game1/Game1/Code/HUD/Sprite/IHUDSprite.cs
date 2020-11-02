using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Code.HUD.Sprite
{
    public interface IHUDSprite
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(bool enabled, int speed);
    }
}
