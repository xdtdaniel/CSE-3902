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

        private int scale;
        private int height;
        private int width;
        private int x;
        private int y;

        private Dictionary<string, int> hudItemList;

        public HUDNumberOfRuby(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //initial values
            numberOfRuby = new Texture2D[2];
            numberOfRuby = HUDFactory.LoadNumber(hudItemList["Ruby"]);
            //need to change later, value is incorrect
            scale = (int)LoadAll.Instance.scale;
            height = 8 * scale;
            width = 8 * scale;
            x = 104 * scale + (int)LoadAll.Instance.startPos.X;
            y = 16 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
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
            x = (int)newStartX + 104 * scale;
            y = (int)newStartY - 56 * scale + 16 * scale;
            numberOfRuby = HUDFactory.LoadNumber(hudItemList["Ruby"]);
        }

    }
}
