using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;
using Game1.Code.LoadFile;

namespace Game1.Code.Player.PlayerItem.PlayerItemState
{
    class RangedWoodenEdge : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;
        private LinkItem item;
        private int direction;
        private int x;
        private int y;
        private int currentFrame = 0;
        private int totalFrame = 15;
        private int speed = 2 * scale;
        private int rectSideLengthOffset = 8 * scale;
        private int numberOfSprite = 4;

        private IPlayerItemSprite[] woodenEdge;

        private Rectangle rectangle;

        public RangedWoodenEdge(LinkItem item)
        {
            direction = item.direction;
            x = item.x;
            y = item.y;

            rectSideLengthOffset = 8 * (int)LoadAll.Instance.scale;

            woodenEdge = new IPlayerItemSprite[numberOfSprite];
            for (int i = 0; i < numberOfSprite; i++)
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

