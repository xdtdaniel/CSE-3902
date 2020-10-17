using Game1.Code.Item.ItemInterface;
using Game1.Code.Item.ItemSprite;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.Code.Item
{
    class ItemList
    {
        private List<IItemSprite> itemList;
        private static int index;

        public ItemList() {
            itemList = new List<IItemSprite>();
            index = 0;
 
            itemList.Add(ItemFactory.ItemSpriteFactory.Instance.CreateArrow());
            itemList.Add(ItemFactory.ItemSpriteFactory.Instance.CreateBomb());
            itemList.Add(ItemFactory.ItemSpriteFactory.Instance.CreateBoomerang());
            itemList.Add(ItemFactory.ItemSpriteFactory.Instance.CreateBow());
            itemList.Add(ItemFactory.ItemSpriteFactory.Instance.CreateClock());
            itemList.Add(ItemFactory.ItemSpriteFactory.Instance.CreateCompass());
            itemList.Add(ItemFactory.ItemSpriteFactory.Instance.CreateFairy());
            itemList.Add(ItemFactory.ItemSpriteFactory.Instance.CreateHeart());
            itemList.Add(ItemFactory.ItemSpriteFactory.Instance.CreateHeartContainer());
            itemList.Add(ItemFactory.ItemSpriteFactory.Instance.CreateKey());
            itemList.Add(ItemFactory.ItemSpriteFactory.Instance.CreateMap());
            itemList.Add(ItemFactory.ItemSpriteFactory.Instance.CreateRuby());
            itemList.Add(ItemFactory.ItemSpriteFactory.Instance.CreateTriforce());

        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
           
            itemList[index].Draw(spriteBatch, x, y);

        }
        public void Update() {

            itemList[index].Update();

        }

        public void MoveNext()
        {
            index++;
            if (index == itemList.Count)
            {
                index = 0;
            }
        }

        public void MovePrev()
        {
            index--;
            if (index <0)
            {
                index = itemList.Count-1;
            }
        }
    }
}
