using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.HUD
{
    public class HUDItemCount
    {
        private int ruby_count;
        private int key_count;
        private int bomb_count;
        private int life_count;

        private Dictionary<string, int> hudItemList;       

        public HUDItemCount(Dictionary<string, int> itemList) {
            hudItemList = itemList;
            //initial values
            ruby_count = 0;
            key_count = 0;
            bomb_count = 0;
            life_count = 3; 
        }

        public void DrawCount(SpriteBatch spriteBatch) { 
        
            //draw each item count in certain part on HUD
        }
        public void UpdateCount() {
            for (int i = 0; i < hudItemList.Count; i++) {
                if (hudItemList.ContainsKey("ruby"))
                {
                    ruby_count = hudItemList["ruby"];
                }
                else if (hudItemList.ContainsKey("key"))
                {
                    key_count = hudItemList["key"];
                }
                else if (hudItemList.ContainsKey("bomb"))
                {
                    bomb_count = hudItemList["bomb"];
                }
                else if (hudItemList.ContainsKey("heartcontainer")) {
                    life_count = hudItemList["heartcontainer"];
                }
            }
        
        }

    }
}
