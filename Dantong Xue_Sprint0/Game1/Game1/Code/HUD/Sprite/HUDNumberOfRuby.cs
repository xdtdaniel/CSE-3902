using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.HUD.Sprite
{
    public class HUDNumberOfRuby : IHUDSprite
    {
        private Texture2D[] numberOfRuby;

        private static int scale = (int)LoadAll.Instance.scale;
        private int height = 8 * scale;
        private int width = 8 * scale;
        private int x;
        private int y;

        private int preX = 104 * scale;
        private int preY = -40 * scale;

        private Dictionary<string, int> hudItemList;

        public HUDNumberOfRuby(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //initial values
            numberOfRuby = new Texture2D[2];
            numberOfRuby = HUDFactory.LoadNumber(hudItemList["Ruby"]);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 2; i++)
            {
                Rectangle sourceRectangle = new Rectangle(0, 0, numberOfRuby[i].Width, numberOfRuby[i].Height);
                Rectangle destinationRectangle = new Rectangle(x + i * width, y, width, height);

                spriteBatch.Draw(numberOfRuby[i], destinationRectangle, sourceRectangle, Color.White);
            }
        }
        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX + preX;
            y = (int)newStartY + preY;
            numberOfRuby = HUDFactory.LoadNumber(hudItemList["Ruby"]);
        }

    }
}
