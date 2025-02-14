﻿using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.HUD.Sprite
{
    public class HUDNumberOfBomb : IHUDSprite
    {
        private Texture2D[] numberOfBomb;

        private static int scale = (int)LoadAll.Instance.scale;
        private int height = 8 * scale;
        private int width = 8 * scale;
        private int x;
        private int y;

        private int preX = 104 * scale;
        private int preY = -16 * scale;

        private Dictionary<string, int> hudItemList;

        public HUDNumberOfBomb(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //initial values
            numberOfBomb = new Texture2D[2]; // 2-digit number
            numberOfBomb = HUDFactory.LoadNumber(hudItemList["Bomb"]);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 2; i++) // 2-digit number
            {
                Rectangle sourceRectangle = new Rectangle(0, 0, numberOfBomb[i].Width, numberOfBomb[i].Height);
                Rectangle destinationRectangle = new Rectangle(x + i * width, y, width, height);

                spriteBatch.Draw(numberOfBomb[i], destinationRectangle, sourceRectangle, Color.White);
            }
        }
        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX + preX;
            y = (int)newStartY + preY;
            numberOfBomb = HUDFactory.LoadNumber(hudItemList["Bomb"]);
        }

    }
}
