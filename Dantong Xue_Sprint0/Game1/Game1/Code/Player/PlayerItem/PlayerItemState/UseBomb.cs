using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;
using Game1.Code.Audio;

namespace Game1.Code.Player.PlayerItem.PlayerItemState
{
    class UseBomb : IPlayerItemState
    {
        private LinkItem item;
        private int x;
        private int y;
        private int direction;
        private int currentFrame = 0;
        private int totalFrame = 3;
        private int secondFrame = 0;
        private int maxSecondFrame = 80;
        private int resetSecondFrame = 60;

        private IPlayerItemSprite bomb;
        private IPlayerItemSprite bombExplosion;

        private Rectangle rectangle;

        public UseBomb(LinkItem item)
        {
            this.x = item.x;
            this.y = item.y;
            this.direction = item.direction;

            bomb = PlayerItemFactory.Instance.CreateBomb();
            bombExplosion = PlayerItemFactory.Instance.CreateBombExplosion();

            this.item = item;
            AudioPlayer.bombDrop.Play();
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
        }
        public void Update() 
        { 
            secondFrame++;
            /* explode after 80 frames */
            if (secondFrame == maxSecondFrame)
            {
                currentFrame++;
                secondFrame = resetSecondFrame;
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
            else if(currentFrame == 1)
            {
                AudioPlayer.bombBlow.Play();
                rectangle = bombExplosion.Draw(spriteBatch, x, y, currentFrame, direction);
            }
            else
            {
                rectangle = bombExplosion.Draw(spriteBatch, x, y, currentFrame, direction);
            }
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

