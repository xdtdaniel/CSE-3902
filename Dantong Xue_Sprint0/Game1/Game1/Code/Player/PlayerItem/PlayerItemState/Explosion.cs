using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;
using Game1.Code.LoadFile;
using System;
using Game1.Code.Player.PlayerCharacter;
using Game1.Code.Audio;
using System.Diagnostics;
using Game1.Code.HUD.Factory;
using System.Collections.Generic;

namespace Game1.Code.Player.PlayerItem.PlayerItemState
{
    class Explosion : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;

        private int damageMultiplier = 1; // test
        private int currentDamage = 1;
        private bool done = false;
        private List<int> hitEnemyList = new List<int>();


        private Link link;

        private int x;
        private int y;
        private int currentFrame = 0;
        private int totalFrame = 3;
        private int secondFrame = 0;
        private int maxSecondFrame = 10;

        private Texture2D explosion;
        private int sourceWidth;
        private int sourceHeight;
        private int destinationWidth = 15 * scale;
        private int destinationHeight = 15 * scale;
        private int column = 3;
        private int offsetX = 2 * scale;
        private int numberOfSprite = 9;

        private Rectangle rect = new Rectangle();


        public Explosion(Link link, int x, int y)
        {
            AudioPlayer.swordSlash.Play();

            this.link = link;
            this.x = x + link.linkWidth / 2;
            this.y = y + link.linkHeight / 2;


            explosion = PlayerAbilityFactory.Instance.GetBombExplosion();

            sourceWidth = explosion.Width / column;
            sourceHeight = explosion.Height;

        }
        public string GetItemName()
        {
            return "BombExplosion";
        }
        public int GetDamage()
        {
            return link.basicAttackDamage * currentDamage;
        }
        public void CollisionResponse(int enemyIndex)
        {
            if (hitEnemyList.Contains(enemyIndex))
            {
                currentDamage = 0;
            }
            else
            {
                currentDamage = damageMultiplier;
                hitEnemyList.Add(enemyIndex);
            }
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame >= totalFrame)
            {
                done = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(currentFrame * sourceWidth, 0, sourceWidth, sourceHeight);
            Rectangle[] destinationRectangles = new Rectangle[numberOfSprite];
            destinationRectangles[0] = new Rectangle(x - offsetX, y, destinationWidth, destinationHeight);
            destinationRectangles[1] = new Rectangle(x - offsetX - destinationWidth, y, destinationWidth, destinationHeight);
            destinationRectangles[2] = new Rectangle(x - offsetX + destinationWidth, y, destinationWidth, destinationHeight);
            destinationRectangles[3] = new Rectangle(x - offsetX, y - destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[4] = new Rectangle(x - offsetX - destinationWidth, y - destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[5] = new Rectangle(x - offsetX + destinationWidth, y - destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[6] = new Rectangle(x - offsetX, y + destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[7] = new Rectangle(x - offsetX - destinationWidth, y + destinationHeight, destinationWidth, destinationHeight);
            destinationRectangles[8] = new Rectangle(x - offsetX + destinationWidth, y + destinationHeight, destinationWidth, destinationHeight);

            for (int i = 0; i < numberOfSprite; i++)
            {
                spriteBatch.Draw(explosion, destinationRectangles[i], sourceRectangle, Color.White);
            }
        }
        
        public Rectangle GetRectangle()
        {
            rect = new Rectangle(x + offset_x, y + offset_y, drawWidth, drawHeight);
            
            return rect;
        }
        public bool IsDone()
        {
            return done;
        }
    }
}

