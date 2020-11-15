using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using Game1.Code.LoadFile;
using Game1.Code.Audio;

namespace Game1.Player.PlayerCharacter
{
    class UseArrow : IPlayerItemState
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private LinkItem item;
        private bool used = false;
        private int direction;
        private int x;
        private int y;
        private int currentFrame = 0;
        private int maxCurrentFrame = 120;

        private int speed = 5 * scale;
        private int offsetX = 3 * scale;
        private int offsetY = 3 * scale;

        private IPlayerItemSprite frontArrow;
        private IPlayerItemSprite rightArrow;
        private IPlayerItemSprite backArrow;
        private IPlayerItemSprite leftArrow;

        private Rectangle rectangle;

        public UseArrow(LinkItem item)
        {
            used = false;
            direction = item.direction;
            x = item.x;
            y = item.y;

            frontArrow = PlayerItemFactory.Instance.CreateFrontArrow();
            rightArrow = PlayerItemFactory.Instance.CreateRightArrow();
            backArrow = PlayerItemFactory.Instance.CreateBackArrow();
            leftArrow = PlayerItemFactory.Instance.CreateLeftArrow();

            this.item = item;

            rectangle = new Rectangle();
        }
        public void UseItem(string itemName) 
        {
        }
        public string GetItemName()
        {
            return "Arrow";
        }
        public void CollisionResponse()
        {
            currentFrame = maxCurrentFrame;
        }
        public void Update() 
        {
            if (currentFrame == 0)
            {

                AudioPlayer.arrowShoot.Play();
            }
            currentFrame++;
            if (currentFrame >= maxCurrentFrame)
            {
                item.state = new NoItem(item);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!used)
            {
                switch (direction)
                {
                    case 0: /* front */
                        frontArrow.Draw(spriteBatch, x += item.link.linkWidth / 2 - offsetX, y += item.link.linkHeight, currentFrame, direction);
                        break;
                    case 1: /* right */
                        rightArrow.Draw(spriteBatch, x += item.link.linkWidth, y += item.link.linkHeight / 2 - offsetY, currentFrame, direction);
                        break;
                    case 2: /* back */
                        backArrow.Draw(spriteBatch, x += item.link.linkWidth / 2 - offsetX, y -= item.link.linkHeight, currentFrame, direction);
                        break;
                    case 3: /* left */
                        leftArrow.Draw(spriteBatch, x -= item.link.linkWidth, y += item.link.linkHeight / 2 - offsetY, currentFrame, direction);
                        break;
                    default:
                        break;
                }
            }
            switch (direction)
            {
                case 0: /* front */
                    y += speed;
                    rectangle = frontArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 1: /* right */
                    x += speed;
                    rectangle = rightArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 2: /* back */
                    y -= speed;
                    rectangle = backArrow.Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 3: /* left */
                    x -= speed;
                    rectangle = leftArrow.Draw(spriteBatch, x, y, currentFrame, direction);
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

