using Game1.Code.HUD.Factory;
using Game1.Code.Item.ItemFactory;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace Game1.Code.HUD.Sprite
{
    public class InventoryObject : IHUDSprite
    {
        private int scale;
        private int height;
        private int width;
        private int spacing;
        private int x;
        private int y;
        private int index;
        private int x_selection;
        private int y_selection;
        private string[] ba;

        private Texture2D[] objects;
        private Dictionary<string, int> hudItemList;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private List<string> inventoryItemList;
        private Texture2D firstSelection;
        public InventoryObject(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //load all texture needed in inventory
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

            //load selections
            firstSelection = HUDFactory.LoadFirstEquipment();



            scale = (int)LoadAll.Instance.scale;
            height = 14 * scale;
            width = 7 * scale;
            spacing = 8 * scale;

            index = 0;

            inventoryItemList = new List<string>();
            //first item position in itenSelection screen
            x = 132 * scale + (int)LoadAll.Instance.startPos.X;
            y = -176 * scale + 48 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
            x_selection = 132 * scale + (int)LoadAll.Instance.startPos.X;
            y_selection = -176 * scale + 48 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;

        }
        public void DrawSelection(SpriteBatch spriteBatch) {

            //initial first selection position

            sourceRectangle = new Rectangle(0, 0, firstSelection.Width, firstSelection.Height);
            destinationRectangle = new Rectangle(x_selection, y_selection, width, height);
            spriteBatch.Draw(firstSelection, destinationRectangle, sourceRectangle, Color.White);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
          

            if (hudItemList["Bomb"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[0].Width, objects[0].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[0], destinationRectangle, sourceRectangle, Color.White);

            }

            x += 16 * scale + width;
            if (hudItemList["Boomerang"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[1].Width, objects[1].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[1], destinationRectangle, sourceRectangle, Color.White);

            }

            x += 12 * scale + width;
            if (hudItemList["WoodenSword"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[2].Width, objects[2].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[2], destinationRectangle, sourceRectangle, Color.White);

            }

            x += width;
            if (hudItemList["SwordBeam"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[3].Width, objects[3].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[3], destinationRectangle, sourceRectangle, Color.White);

            }

            x += 12 * scale + width;
            if (hudItemList["Bow"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[4].Width, objects[4].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[4], destinationRectangle, sourceRectangle, Color.White);
            }

            x = 132 * scale;
            y += 16 * scale;
            if (hudItemList["Clock"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[5].Width, objects[5].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[5], destinationRectangle, sourceRectangle, Color.White);
            }

            x += 16 * scale + width;
            if (hudItemList["BlueCandle"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[6].Width, objects[6].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[6], destinationRectangle, sourceRectangle, Color.White);
            }

            x += 16 * scale + width;
            if (hudItemList["BluePotion"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[7].Width, objects[7].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[7], destinationRectangle, sourceRectangle, Color.White);
            }

            x += 16 * scale + width;
            if (hudItemList["BlueRing"] > 0)
            {
                sourceRectangle = new Rectangle(0, 0, objects[8].Width, objects[8].Height);
                destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(objects[8], destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public void UpdateSelection(float newStartX, float newStartY)
        {
            x_selection = 132 * scale + (int)newStartX;
            y_selection = -176 * scale + 48 * scale + (int)newStartY - 56 * scale;


        }
        public void Update(float newStartX, float newStartY)
        {
            x = 132 * scale + (int)newStartX;
            y = -176 * scale + 48 * scale + (int)newStartY - 56 * scale;

        }


        public void MoveNext()
        {
            index++;
            if (index == 9)
            {
                index = 0;
                x_selection = 132 * scale + (int)LoadAll.Instance.startPos.X;
                y_selection = -176 * scale + 48 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
            }
            else if (index == 2)
            {
                x_selection = x_selection = 132 * scale + (int)LoadAll.Instance.startPos.X + 2 * width + 4 * spacing;
                y_selection = y_selection = -176 * scale + 48 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
                ++index;

            }
            else if (index == 5)
            {
                x_selection = x_selection = 132 * scale + (int)LoadAll.Instance.startPos.X;
                y_selection += (2 * spacing);

            }
            else
            {
                x_selection += width + 2 * spacing;
            }

        }

        public void MovePrev()
        {
            index--;
            if (index < 0)
            {
                index = 8;
                x_selection = 132 * scale + (int)LoadAll.Instance.startPos.X + 2 * width + 7 * spacing;
                y_selection += 2 * spacing;
            }
            else if (index == 3)
            {
                x_selection = x_selection = 132 * scale + (int)LoadAll.Instance.startPos.X + 2 * width + 4 * spacing;
                y_selection = y_selection = -176 * scale + 48 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;
                --index;

            }
            else if (index == 4)
            {
                x_selection = x_selection = 132 * scale + (int)LoadAll.Instance.startPos.X + 2*width + 7 * spacing;
                y_selection  -= 2 * spacing;

            }
            else if (index == 5)
            {
                x_selection = x_selection = 132 * scale + (int)LoadAll.Instance.startPos.X;
            }
            else
            {
                x_selection -= width + 2 * spacing;
            }
        }
    }
       
}
