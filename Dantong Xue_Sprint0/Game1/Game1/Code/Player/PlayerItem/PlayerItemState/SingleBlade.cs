using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;
using Game1.Code.LoadFile;
using System;
using Game1.Code.Player.PlayerCharacter;

namespace Game1.Code.Player.PlayerItem.PlayerItemState
{
    class SingleBlade : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;

        private int width = 6 * scale;
        private int height = 13 * scale;
        private int damageMultiplier = 2;

        private int currentFrame = 0;
        private int totalFrame = 3000;

        private float angle;

        private Texture2D blade;

        private Link link;

        private Rectangle rect = new Rectangle();


        public SingleBlade(Link link, float angle)
        {
            this.link = link;
            this.angle = angle;

            blade = PlayerAbilityFactory.Instance.GetBlade();
        }
        public void UseItem(string itemName) 
        {
        }
        public string GetItemName()
        {
            return "Blade";
        }
        public int GetDamage()
        {
            return link.basicAttackDamage * damageMultiplier;
        }
        public void CollisionResponse()
        {
            currentFrame = totalFrame;
        }
        public void Update() 
        {
            //currentFrame++;
            //if (currentFrame >= totalFrame)
            //{
            //    currentFrame = 0;
            //    item.x = x;
            //    item.y = y;
            //    item.state = new RangedWoodenEdge(item);
            //}
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            angle = (float)(Math.PI / 180) * 45;
            Rectangle sourceRectangle = new Rectangle(0, 0, blade.Width, blade.Height);
            Rectangle destinationRectangle = new Rectangle(link.x, link.y - 20 * scale, width, height);
            Vector2 origin = new Vector2(blade.Width / 2, blade.Height / 2);

            rect = destinationRectangle;

            spriteBatch.Draw(blade, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);
        }
        
        public Rectangle GetRectangle()
        {
            return rect;
        }
        public bool IsDone()
        {
            return false;
        }
    }
}

