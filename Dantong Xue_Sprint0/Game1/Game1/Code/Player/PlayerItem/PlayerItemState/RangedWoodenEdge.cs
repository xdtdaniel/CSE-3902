using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Game1.Code.LoadFile;

namespace Game1.Player.PlayerCharacter
{
    class RangedWoodenEdge : IPlayerItemState
    {
        LinkItem item;
        int direction;
        int x;
        int y;
        int currentFrame;
        int totalFrame;
        int speed;
        int rectSideLengthOffset;

        IPlayerItemSprite[] woodenEdge;

        Rectangle rectangle;

        public RangedWoodenEdge(LinkItem item)
        {
            direction = item.direction;
            x = item.x;
            y = item.y;

            rectSideLengthOffset = 8 * (int)LoadAll.Instance.scale;
            currentFrame = 0;
            totalFrame = 15;
            speed = 5;

            woodenEdge = new IPlayerItemSprite[4];
            for (int i = 0; i < 4; i++)
            {
                woodenEdge[i] = PlayerItemFactory.Instance.CreateWoodenEdge(i);
            }

            this.item = item;

            rectangle = new Rectangle();
        }
        public void UseItem(string itemName) 
        {
        }
        public string GetItemName()
        {
            return "RangedWoodenEdge";
        }
        public void CollisionResponse()
        {
        }
        public void Update() 
        {
            currentFrame++;
            if (currentFrame >= totalFrame)
            {
                item.state = new NoItem(item);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            woodenEdge[0].Draw(spriteBatch, x - speed * currentFrame, y - speed * currentFrame, currentFrame, direction);
            woodenEdge[1].Draw(spriteBatch, x + speed * currentFrame, y - speed * currentFrame, currentFrame, direction);
            woodenEdge[2].Draw(spriteBatch, x - speed * currentFrame, y + speed * currentFrame, currentFrame, direction);
            woodenEdge[3].Draw(spriteBatch, x + speed * currentFrame, y + speed * currentFrame, currentFrame, direction);
        }
        public Rectangle GetRectangle()
        {
            rectangle = new Rectangle(x - speed * currentFrame, y - speed * currentFrame, speed * currentFrame * 2 + rectSideLengthOffset, speed * currentFrame * 2 + rectSideLengthOffset);
            return rectangle;
        }
        public bool IsDone()
        {
            return false;
        }
    }
}

