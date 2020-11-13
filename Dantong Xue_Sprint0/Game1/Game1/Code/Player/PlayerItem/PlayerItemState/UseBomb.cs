using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;

namespace Game1.Player.PlayerCharacter
{
    class UseBomb : IPlayerItemState
    {
        LinkItem item;
        int x;
        int y;
        int direction;
        int currentFrame;
        int totalFrame;
        int secondFrame;

        IPlayerItemSprite bomb;
        IPlayerItemSprite bombExplosion;

        Rectangle rectangle;

        public UseBomb(LinkItem item)
        {
            this.x = item.x;
            this.y = item.y;
            this.direction = item.direction;

            currentFrame = 0;
            totalFrame = 3;
            secondFrame = 0;

            bomb = PlayerItemFactory.Instance.CreateBomb();
            bombExplosion = PlayerItemFactory.Instance.CreateBombExplosion();

            this.item = item;
        }
        public void UseItem(string itemName) 
        {
        }
        public string GetItemName()
        {
            if (currentFrame == 0)
            {
                return "Bomb";
            }
            else
            {
                return "BombExplosion";
            }
        }
        public void CollisionResponse()
        {
            if (currentFrame == 1)
            {
                // player and enemy take damage
            }
        }
        public void Update() 
        { 
            secondFrame++;
            /* explode after 80 frames */
            if (secondFrame == 80)
            {
                currentFrame++;
                secondFrame = 60;
            }
            if (currentFrame == totalFrame)
            {
                item.state = new NoItem(item);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentFrame == 0)
            {
                rectangle = bomb.Draw(spriteBatch, x, y, currentFrame, direction);
            }
            else 
            {
                rectangle = bombExplosion.Draw(spriteBatch, x, y, currentFrame, direction);
            }
        }

        public Rectangle GetRectangle()
        {
            if (secondFrame == 60 && currentFrame == 1)
            {
                return rectangle;
            }
            else
            {
                return new Rectangle();
            }
        }
        public bool IsDone()
        {
            return false;
        }
    }
}

