using Game1.Code.Item.ItemInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Item
{
    class UpdateAllItem
    {
        private static UpdateAllItem instance = new UpdateAllItem();
        private List<Tuple<IItemSprite, string>> outRoomList = new List<Tuple<IItemSprite, string>>();
        public static UpdateAllItem Instance
        {
            get
            {
                return instance;
            }
        }

        public void UpdateAll(List<Tuple<IItemSprite, string>> inRoom)
        {
            for (int i = 0; i < inRoom.Count; i++)
            {
                inRoom[i].Item1.Update();
            }
        }
    }
}
