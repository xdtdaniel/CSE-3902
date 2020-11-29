using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerCharacter;
using Game1.Code.Player.PlayerItem;
using Game1.Code.Player.PlayerItem.PlayerItemState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Zelda.Code.Player.PlayerCharacter
{
    public class ItemPool
    {
        private int boomerangUsed = 0;
        private int boomerangLimit = 1;

        private Link link;

        private List<IPlayerItemState> list = new List<IPlayerItemState>();
        public ItemPool(Link link)
        {
            this.link = link;
        }
        public void UseItem(string itemName)
        {
            switch (itemName)
            {
                case "Arrow":
                    list.Add(new UseArrow(link));
                    break;
                case "Boomerang":
                    if (boomerangUsed < boomerangLimit)
                    {
                        list.Add(new UseBoomerang(link));
                        boomerangUsed++;
                    }
                    break;
                case "Bomb":
                    list.Add(new UseBomb(link));
                    break;
                case "RangedWoodenSword":
                    list.Add(new RangedSword(link, 0));
                    break;
                case "RangedSwordBeam":
                    list.Add(new RangedSword(link, 1));
                    break;
                default:
                    break;
            }
        }
        public void UseAbility(string abilityName)
        {
        }

        public Rectangle GetRectangle(int index)
        {
            return list[index].GetRectangle();
        }
        public void CollisionResponse(int index)
        {
            list[index].CollisionResponse();
        }

        public void Update(int x, int y, int directionIndex)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsDone())
                {
                    if (list[i].GetItemName() == "Boomerang")
                    {
                        boomerangUsed--;
                    }
                    list.RemoveAt(i);
                    i--;
                    
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                list[i].Update();
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Draw(spriteBatch);
            }
        }
        public List<IPlayerItemState> GetItemPool()
        {
            return list;
        }
    }
}
