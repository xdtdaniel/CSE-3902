using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using Game1.Code.LoadFile;

namespace Game1.Player.PlayerCharacter
{
    class RangedBeamEdge : IPlayerItemState
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

        private IPlayerItemSprite[] beamEdge;

        private Rectangle rectangle;

        public RangedBeamEdge(LinkItem item)
        {
            direction = item.direction;
            x = item.x;
            y = item.y;

            beamEdge = new IPlayerItemSprite[numberOfSprite];
            for (int i = 0; i < numberOfSprite; i++)
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
            rectangle = new Rectangle(x - speed * currentFrame, y - speed * currentFrame, speed * currentFrame * 2 + rectSideLengthOffset, speed * currentFrame * 2 + rectSideLengthOffset);
            return rectangle;
        }
        public bool IsDone()
        {
            return false;
        }
    }
}

