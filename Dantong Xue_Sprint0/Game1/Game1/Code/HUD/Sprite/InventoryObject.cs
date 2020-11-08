using Game1.Code.HUD.Factory;
using Game1.Code.Item.ItemFactory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.HUD.Sprite
{
    public class InventoryObject : IHUDSprite
    {
        private int scale;
        private int height;
        private int width;
        private int x;
        private int y;
        private Texture2D[] objects;
        private Dictionary<string, int> hudItemList;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;

        public InventoryObject(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //load all texture needed in inventory
            objects = new Texture2D[5];
            objects[0] = HUDFactory.LoadSword();
            objects[1] = ItemSpriteFactory.CreateArrow();
            objects[2] = ItemSpriteFactory.CreateBomb();
            objects[3] = ItemSpriteFactory.CreateBoomerang();
            objects[4] = ItemSpriteFactory.CreateBow();

            scale = (int)LoadAll.Instance.scale;
            height = 16 * scale;
            width = 8 * scale;
            //first item position in itenSelection screen
            x = 132 * scale + (int)LoadAll.Instance.startPos.X;
            y = 48 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
 
            for (int i = 0; i < 5; i++)
            {
                if (hudItemList["Sword"] > 0 )
                {
                    sourceRectangle = new Rectangle(0, 0, objects[i].Width, objects[i].Height);
                    destinationRectangle = new Rectangle(x + i * width, y, width, height);
                    spriteBatch.Draw(objects[i], destinationRectangle, sourceRectangle, Color.White);

                }
                else if (hudItemList["Arrow"] > 0 )
                {
                    sourceRectangle = new Rectangle(0, 0, objects[i].Width, objects[i].Height);
                    destinationRectangle = new Rectangle(x + i * width, y, width, height);
                    spriteBatch.Draw(objects[i], destinationRectangle, sourceRectangle, Color.White);

                }
                else if (hudItemList["Bomb"] > 0 )
                {
                    sourceRectangle = new Rectangle(0, 0, objects[i].Width, objects[i].Height);
                    destinationRectangle = new Rectangle(x + i * width, y, width, height);
                    spriteBatch.Draw(objects[i], destinationRectangle, sourceRectangle, Color.White);

                }
                else if (hudItemList["Boomerang"] > 0 )
                {
                    sourceRectangle = new Rectangle(0, 0, objects[i].Width, objects[i].Height);
                    destinationRectangle = new Rectangle(x + i * width, y, width, height);
                    spriteBatch.Draw(objects[i], destinationRectangle, sourceRectangle, Color.White);

                }
                else if (hudItemList["Bow"] > 0 )
                {
                    sourceRectangle = new Rectangle(0, 0, objects[i].Width, objects[i].Height);
                    destinationRectangle = new Rectangle(x + i * width, y, width, height);
                    spriteBatch.Draw(objects[i], destinationRectangle, sourceRectangle, Color.White);

                }


            }
        }
    
        public void Update(float newStartX, float newStartY)
        {
            x = (int)newStartX + 132 * scale;
            y = (int)newStartY - 56 * scale + 48 * scale;

            //if (hudItemList["Arrow"] == 0) {
            //    hudItemList.Remove("Arrow");
            //}
            
        }
    }
       
}
