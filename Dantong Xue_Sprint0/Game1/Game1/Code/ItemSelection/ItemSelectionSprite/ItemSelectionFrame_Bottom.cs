using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.ItemSelection.ItemSelectionSprite
{
    class ItemSelectionFrame_Bottom : IItemSelectionSprite
    {
        Texture2D Texture;
        int height;
        int width;
        private int x;
        private int y;
        private static int scale;
        public ItemSelectionFrame_Bottom(int position_x, int position_y)
        {
            Texture = ItemSelectionFactory.ItemSelectionFactory.LoadItemSelectionFrame_Bottom();
            x = position_x;
            y = position_y;
            scale = 3;
        }

        public void DrawSelectionScreen(SpriteBatch spriteBatch)
        {
            height = Texture.Height;
            width = Texture.Width;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width * scale, height * scale);//might change based on window size
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void UpdateSelectionScreen()
        {

        }
    }
}
