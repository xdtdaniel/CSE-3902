using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;
using Game1.Code.LoadFile;
using Game1.Code.Audio;
using Game1.Code.Player.PlayerCharacter;

namespace Game1.Code.Player.PlayerItem.PlayerItemState
{
    class UseArrow : IPlayerItemState
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private Link link;
        private bool used = false;
        private int direction;
        private int x;
        private int y;
        private int currentFrame = 0;
        private int maxCurrentFrame = 120;
        private int damageMultiplier = 2;
        private bool done = false;

        private int speed = 5 * scale;
        private int offsetX = 3 * scale;
        private int offsetY = 3 * scale;

        private IPlayerItemSprite frontArrow;
        private IPlayerItemSprite rightArrow;
        private IPlayerItemSprite backArrow;
        private IPlayerItemSprite leftArrow;

        private Rectangle rectangle;

        public UseArrow(Link link)
        {
            used = false;
            direction = link.directionIndex;
            x = link.x;
            y = link.y;

            frontArrow = PlayerItemFactory.Instance.CreateFrontArrow();
            rightArrow = PlayerItemFactory.Instance.CreateRightArrow();
            backArrow = PlayerItemFactory.Instance.CreateBackArrow();
            leftArrow = PlayerItemFactory.Instance.CreateLeftArrow();

            this.link = link;

            rectangle = new Rectangle();
        }
        public string GetItemName()
        {
            return "Arrow";
        }
        public int GetDamage()
        {
            return link.basicAttackDamage * damageMultiplier;
        }
        public void CollisionResponse(int enemyIndex)
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
                done = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!used)
            {
                switch (direction)
                {
                    case 0: /* front */
                        frontArrow.Draw(spriteBatch, x += link.linkWidth / 2 - offsetX, y += link.linkHeight, currentFrame, direction);
                        break;
                    case 1: /* right */
                        rightArrow.Draw(spriteBatch, x += link.linkWidth, y += link.linkHeight / 2 - offsetY, currentFrame, direction);
                        break;
                    case 2: /* back */
                        backArrow.Draw(spriteBatch, x += link.linkWidth / 2 - offsetX, y -= link.linkHeight, currentFrame, direction);
                        break;
                    case 3: /* left */
                        leftArrow.Draw(spriteBatch, x -= link.linkWidth, y += link.linkHeight / 2 - offsetY, currentFrame, direction);
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
            return done;
        }
    }
}

