using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.LoadFile;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;

namespace Game1.Code.Player.PlayerItem.PlayerItemState
{
    class RangedSwordBeam : IPlayerItemState
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private LinkItem item;
        private int direction;
        private int x;
        private int y;
        private int currentFrame = 0;
        private int totalFrame = 120;

        private int speed = 5 * scale;
        private int offsetX = 3 * scale;
        private int offsetY = 3 * scale;
        private bool used = false;
        private int numberOfSprite = 4;

        private IPlayerItemSprite[] swordBeam;

        private Rectangle rectangle;
        public RangedSwordBeam(LinkItem item)
        {
            direction = item.direction;
            x = item.x;
            y = item.y;

            swordBeam = new IPlayerItemSprite[numberOfSprite];
            for (int i = 0; i < numberOfSprite; i++)
            {
                swordBeam[i] = PlayerItemFactory.Instance.CreateSwordBeam(i);
            }

            this.item = item;

            rectangle = new Rectangle();
        }
        public void UseItem(string itemName) 
        {
        }
        public string GetItemName()
        {
            return "RangedSwordBeam";
        }
        public void CollisionResponse()
        {
            currentFrame = totalFrame;
        }
        public void Update() 
        {
            currentFrame++;
            if (currentFrame >= totalFrame)
            {
                currentFrame = 0;
                item.x = x;
                item.y = y;
                item.state = new RangedBeamEdge(item);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            if (!used)
            {
                switch (direction)
                {
                    case 0: /* front */
                        swordBeam[2].Draw(spriteBatch, x += item.link.linkWidth / 2 - offsetX, y += item.link.linkHeight, currentFrame, direction);
                        break;
                    case 1: /* right */
                        swordBeam[1].Draw(spriteBatch, x += item.link.linkWidth, y += item.link.linkHeight / 2 - offsetY, currentFrame, direction);
                        break;
                    case 2: /* back */
                        swordBeam[0].Draw(spriteBatch, x += item.link.linkWidth / 2 - offsetX, y -= item.link.linkHeight, currentFrame, direction);
                        break;
                    case 3: /* left */
                        swordBeam[3].Draw(spriteBatch, x -= item.link.linkWidth, y += item.link.linkHeight / 2 - offsetY, currentFrame, direction);
                        break;
                    default:
                        break;
                }
            }
            switch (direction)
            {
                case 0: /* front */
                    y += speed;
                    rectangle = swordBeam[2].Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 1: /* right */
                    x += speed;
                    rectangle = swordBeam[1].Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 2: /* back */
                    y -= speed;
                    rectangle = swordBeam[0].Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 3: /* left */
                    x -= speed;
                    rectangle = swordBeam[3].Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                default:
                    break;
            }
            used = true;
        }
        
        public Rectangle GetRectangle()
        {
            return rectangle;
        }
        public bool IsDone()
        {
            return false;
        }
    }
}

