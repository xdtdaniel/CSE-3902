using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using Microsoft.Xna.Framework;

namespace Game1.Player.PlayerCharacter
{
    public class LinkItem
    {
        public IPlayerItemState state;

        public int x = 0;
        public int y = 0;
        public int direction = -1;
        public int lastLinkX;
        public int lastLinkY;
        public Link link;
        public LinkItem(Link link)
        {
            this.state = new NoItem(this);
            this.link = link;
        }

        public void UseItem(string itemName)
        {
            state.UseItem(itemName);
        }
        public Rectangle GetRectangle()
        {
            return state.GetRectangle();
        }
        public string GetItemName()
        {
            return state.GetItemName();
        }
        public void CollisionResponse()
        {
            state.CollisionResponse();
        }
        public void Update(int x, int y, int direction)
        {
            state.Update();
            if (state.GetItemName() == "NoItem")
            {
                this.x = x;
                this.y = y;
                this.direction = direction;
            }
            lastLinkX = x;
            lastLinkY = y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }
        public bool IsDone()
        {
            return state.IsDone();
        }
    }
}
