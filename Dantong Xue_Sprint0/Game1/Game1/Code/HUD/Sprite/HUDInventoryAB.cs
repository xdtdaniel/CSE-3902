using Game1.Code.HUD.Factory;
using Game1.Code.Item.ItemFactory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Game1.Code.HUD.Sprite
{
    public class HUDInventoryAB 
    {

        private Texture2D[] objects;
        private int scale;
        private int height;
        private int width;
        private int x;
        private int y;
        private int i;


        private Dictionary<string, int> hudItemList;

        public HUDInventoryAB(Dictionary<string, int> itemList, int index)
        {
            i = index;
           
            hudItemList = itemList;
            objects = new Texture2D[9];
            objects[0] = ItemSpriteFactory.CreateBomb();
            objects[1] = ItemSpriteFactory.CreateBoomerang();
            objects[2] = ItemSpriteFactory.CreateWoodenSword();
            objects[3] = ItemSpriteFactory.CreateSwordBeam();
            objects[4] = ItemSpriteFactory.CreateBow();
            objects[5] = ItemSpriteFactory.CreateClock();
            objects[6] = ItemSpriteFactory.CreateBlueCandle();
            objects[7] = ItemSpriteFactory.CreateBluePotion();
            objects[8] = ItemSpriteFactory.CreateBlueRing();

            scale = (int)LoadAll.Instance.scale;
            height = 16 * scale;
            width = 8 * scale;
            x = 128 * scale + (int)LoadAll.Instance.startPos.X;
            y = 24 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
        }

        public void Draw(SpriteBatch spriteBatch, int index)
        {
            //Rectangle sourceRectangle = new Rectangle(0, 0, objects[i].Width, objects[i].Height);
            //Rectangle destinationRectangle = new Rectangle(x, y, width, height);
            //spriteBatch.Draw(objects[i], destinationRectangle, sourceRectangle, Color.White);
            Rectangle sourceRectangle = new Rectangle(0, 0, objects[2].Width, objects[2].Height);
            Rectangle destinationRectangle = new Rectangle(x + width * scale, y, width, height);
            spriteBatch.Draw(objects[2], destinationRectangle, sourceRectangle, Color.White);
            foreach (KeyValuePair<string, int> KeyValue in hudItemList)
            {

                switch (index)
                {
                    case 0:
                        if (hudItemList["Bomb"] > 0)
                        {
                            sourceRectangle = new Rectangle(0, 0, objects[0].Width, objects[0].Height);
                            destinationRectangle = new Rectangle(x, y, width, height);
                            spriteBatch.Draw(objects[0], destinationRectangle, sourceRectangle, Color.White);
                        }
                        break;
                    case 1:
                        if (hudItemList["Boomerang"] > 0)
                        {
                            sourceRectangle = new Rectangle(0, 0, objects[1].Width, objects[1].Height);
                            destinationRectangle = new Rectangle(x, y, width, height);
                            spriteBatch.Draw(objects[1], destinationRectangle, sourceRectangle, Color.White);
                        }

                        break;
                    case 2:
                        if (hudItemList["WoodenSword"] > 0)
                        {
                            sourceRectangle = new Rectangle(0, 0, objects[2].Width, objects[2].Height);
                            destinationRectangle = new Rectangle(x, y, width, height);
                            spriteBatch.Draw(objects[2], destinationRectangle, sourceRectangle, Color.White);
                        }
                        break;
                    case 3:
                        if (hudItemList["SwordBeam"] > 0)
                        {
                            sourceRectangle = new Rectangle(0, 0, objects[3].Width, objects[3].Height);
                            destinationRectangle = new Rectangle(x, y, width, height);
                            spriteBatch.Draw(objects[3], destinationRectangle, sourceRectangle, Color.White);
                        }
                        break;
                    case 4:
                        if (hudItemList["Bow"] > 0)
                        {
                            sourceRectangle = new Rectangle(0, 0, objects[4].Width, objects[4].Height);
                            destinationRectangle = new Rectangle(x, y, width, height);
                            spriteBatch.Draw(objects[4], destinationRectangle, sourceRectangle, Color.White);
                        }
                        break;
                    case 5:
                        if (hudItemList["Clock"] > 0)
                        {
                            sourceRectangle = new Rectangle(0, 0, objects[5].Width, objects[5].Height);
                            destinationRectangle = new Rectangle(x, y, width, height);
                            spriteBatch.Draw(objects[5], destinationRectangle, sourceRectangle, Color.White);
                        }
                        break;
                    case 6:
                        if (hudItemList["BlueCandle"] > 0)
                        {
                            sourceRectangle = new Rectangle(0, 0, objects[6].Width, objects[6].Height);
                            destinationRectangle = new Rectangle(x, y, width, height);
                            spriteBatch.Draw(objects[6], destinationRectangle, sourceRectangle, Color.White);
                        }
                        break;
                    case 7:
                        if (hudItemList["BluePotion"] > 0)
                        {
                            sourceRectangle = new Rectangle(0, 0, objects[7].Width, objects[7].Height);
                            destinationRectangle = new Rectangle(x, y, width, height);
                            spriteBatch.Draw(objects[7], destinationRectangle, sourceRectangle, Color.White);
                        }
                        break;
                    case 8:
                        if (hudItemList["BlueRing"] > 0)
                        {
                            sourceRectangle = new Rectangle(0, 0, objects[8].Width, objects[8].Height);
                            destinationRectangle = new Rectangle(x, y, width, height);
                            spriteBatch.Draw(objects[8], destinationRectangle, sourceRectangle, Color.White);
                        }
                        break;
                }

            }

           


        }

        public void Update(float newStartX, float newStartY, int index)
        {
            x = (int)newStartX + 128 * scale;
            y = (int)newStartY - 56 * scale + 24 * scale;
            i = index;
        }
    }
}
