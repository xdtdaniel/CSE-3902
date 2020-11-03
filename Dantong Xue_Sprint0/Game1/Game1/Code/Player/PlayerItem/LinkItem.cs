using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1.Player.PlayerCharacter
{
    public class LinkItem
    {
        public IPlayerItemState state;

        public int x;
        public int y;
        public int linkX;
        public int linkY;
        public int direction;
        public Link link;
        public LinkItem(Link link)
        {
            this.state = new NoItem(this);
            x = 0;
            y = 0;
            direction = -1;

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
            linkX = x;
            linkY = y;
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
