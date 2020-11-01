using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.ItemSelection.ItemSelectionSprite
{
    public interface IItemSelectionSprite
    {
        void DrawSelectionScreen(SpriteBatch spriteBatch);
        void UpdateSelectionScreen();
    }
}
