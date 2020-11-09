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
    public class InventoryItenSelection
    {
        private int scale;
        private int height;
        private int width;
        private int spacing;
        private int index;
        private int x_selection;
        private int y_selection;
        private string[] ba;

        private Texture2D[] objects;
        private Dictionary<string, int> hudItemList;
        private List<string> inventoryItemList;
        private Texture2D Selection;
        public InventoryItenSelection(Dictionary<string, int> itemList)
        {
            hudItemList = itemList;
            //load selections
            Selection = HUDFactory.LoadFirstEquipment();



            scale = (int)LoadAll.Instance.scale;
            height = 14 * scale;
            width = 7 * scale;
            spacing = 8 * scale;

            index = 0;

            inventoryItemList = new List<string>();
            x_selection = 132 * scale + (int)LoadAll.Instance.startPos.X;
            y_selection = -176 * scale + 48 * scale + (int)LoadAll.Instance.startPos.Y - 56 * scale;

        }
        public void DrawSelection(SpriteBatch spriteBatch)
        {

            //initial first selection position

           Rectangle sourceRectangle = new Rectangle(0, 0, Selection.Width, Selection.Height);
           Rectangle destinationRectangle = new Rectangle(x_selection, y_selection, width, height);
            spriteBatch.Draw(Selection, destinationRectangle, sourceRectangle, Color.White);

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
                x_selection = x_selection = 132 * scale + (int)LoadAll.Instance.startPos.X + 2 * width + 7 * spacing;
                y_selection -= 2 * spacing;

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
