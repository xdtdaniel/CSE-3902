using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;

namespace Game1.Player.PlayerCharacter
{
    class NoItem : IPlayerItemState
    {

        LinkItem item;

        public NoItem(LinkItem item)
        {
            this.item = item;
        }
        public void UseItem(string itemName)
        {
            switch (itemName)
            {
                case "Arrow":
                    item.state = new UseArrow(item);
                    break;
                case "Boomerang":
                    item.state = new UseBoomerang(item);
                    break;
                case "Bomb":
                    item.state = new UseBomb(item);
                    break;
                case "BlueCandle":
                    item.state = new UseBlueCandle(item);
                    break;
                case "BluePotion":
                    item.state = new UseBluePotion(item);
                    break;
                case "BlueRing":
                    item.state = new UseBlueRing(item);
                    break;
                case "RangedWoodenSword":
                    item.state = new RangedWoodenSword(item);
                    break;
                case "RangedSwordBeam":
                    item.state = new RangedSwordBeam(item);
                    break;
                default:
                    break;
            }
        }
        public string GetItemName()
        {
            return "NoItem";
        }
        public void CollisionResponse()
        {

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
        public bool IsDone()
        {
            return true;
        }
    }
}

