using Game1.Code.Item.ItemInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
namespace Game1.Code.Item
{
    class DrawAllItem
    {
        private static DrawAllItem instance = new DrawAllItem();
        private List<Tuple<IItemSprite, string>> outRoomList = new List<Tuple<IItemSprite, string>>();
        public static DrawAllItem Instance
        {
            get
            {
                return instance;
            }
        }

        public void DrawAll(List<Tuple<IItemSprite, string>> inRoom, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < inRoom.Count; i++)
            {
                inRoom[i].Item1.Draw(spriteBatch);
            }
        }


    }
}
