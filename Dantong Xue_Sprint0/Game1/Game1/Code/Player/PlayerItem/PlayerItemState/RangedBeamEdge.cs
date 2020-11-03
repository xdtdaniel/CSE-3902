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
    class RangedBeamEdge : IPlayerItemState
    {
        LinkItem item;
        int direction;
        int x;
        int y;
        int currentFrame;
        int totalFrame;
        int speed;

        IPlayerItemSprite[] beamEdge;

        Rectangle rectangle;

        public RangedBeamEdge(LinkItem item)
        {
            direction = item.direction;
            x = item.x;
            y = item.y;

            currentFrame = 0;
            totalFrame = 15;
            speed = 5;

            beamEdge = new IPlayerItemSprite[4];
            for (int i = 0; i < 4; i++)
            {
                beamEdge[i] = PlayerItemFactory.Instance.CreateBeamEdge(i);
            }

            this.item = item;

            rectangle = new Rectangle();
        }
        public void UseItem(string itemName) 
        {
        }
        public string GetItemName()
        {
            return "RangedBeamEdge";
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
            beamEdge[0].Draw(spriteBatch, x - speed * currentFrame, y - speed * currentFrame, currentFrame, direction);
            beamEdge[1].Draw(spriteBatch, x + speed * currentFrame, y - speed * currentFrame, currentFrame, direction);
            beamEdge[2].Draw(spriteBatch, x - speed * currentFrame, y + speed * currentFrame, currentFrame, direction);
            beamEdge[3].Draw(spriteBatch, x + speed * currentFrame, y + speed * currentFrame, currentFrame, direction);
        }
        public Rectangle GetRectangle()
        {
            rectangle = new Rectangle(x - speed * currentFrame, y - speed * currentFrame, x + speed * currentFrame, y + speed * currentFrame);
            return rectangle;
        }
        public bool IsDone()
        {
            return false;
        }
    }
}

