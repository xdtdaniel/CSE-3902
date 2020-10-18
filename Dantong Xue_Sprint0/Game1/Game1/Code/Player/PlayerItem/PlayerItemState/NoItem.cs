using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Player.PlayerCharacter
{
    class NoItem : IPlayerItemState
    {

        PlayerItem item;

        public NoItem(PlayerItem item)
        {
            this.item = item;
        }
        public void UseItem(int itemNum)
        {
            switch (itemNum)
            {
                case 1:
                    item.state = new UseArrow(item);
                    break;
                case 2:
                    item.state = new UseBoomerang(item);
                    break;
                case 3:
                    item.state = new UseBomb(item);
                    break;
                case 4:
                    item.state = new UseBlueCandle(item);
                    break;
                case 5:
                    item.state = new UseBluePotion(item);
                    break;
                case 6:
                    item.state = new UseBlueRing(item);
                    break;
                default:
                    break;
            }
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle();
        }
    }
}

