using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;
using Game1.Code.Item.ItemSprite;
using Game1.Code.LoadFile;
using Game1.Code.HUD;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Player.PlayerCharacter.LinkState
{

    class LevelUpLink : IPlayerLinkState
    {
        private static int scale = (int)LoadAll.Instance.scale;

        private Link link;
        private IPlayerLinkSprite linkSprite;        
        private int offsetX = 8 * scale;
        private int offsetY = 30 * scale;
        private int currentFrame = 0;
        private int maxCurrentFrame = 100;
        private LevelUp font;

        public LevelUpLink(Link link)
        {
            font = new LevelUp(link.x - (int)LoadAll.Instance.startPos.X - offsetX, link.y - (int)LoadAll.Instance.startPos.Y - offsetY);
            linkSprite = PlayerCharacterFactory.Instance.CreatePickUpLink();
            this.link = link;
            link.isDamaged = false;
            link.movable = true;
           
        }


        public void UseItem()
        {
        }
        public void TakeDamage(int dmgAmount)
        {
        }
        public void PickUp(int pickUp)
        {
        }
        public void KnockedBack(string collisionSide)
        {
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == maxCurrentFrame) // decide how long the hold state will take
            {
                currentFrame = 0;
                link.state = new NormalLink(link);
            }
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            linkSprite.Draw(spriteBatch, link.x, link.y, 1, link.direction);
            font.Draw(spriteBatch);

        }
        public string GetStateName()
        {
            return "LevelUpLink";
        }
    }
}

