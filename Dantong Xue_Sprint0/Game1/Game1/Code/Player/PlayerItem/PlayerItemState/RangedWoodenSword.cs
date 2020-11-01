using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Game1.Code.LoadFile;

namespace Game1.Player.PlayerCharacter
{
    class RangedWoodenSword : IPlayerItemState
    {
        LinkItem item;
        int direction;
        int x;
        int y;
        int currentFrame;
        int totalFrame;

        int speed;
        int offsetX;
        int offsetY;

        bool used;

        IPlayerItemSprite[] woodenSword;

        Rectangle rectangle;


        public RangedWoodenSword(LinkItem item)
        {
            direction = item.direction;
            x = item.x;
            y = item.y;

            currentFrame = 0;
            totalFrame = 120;

            speed = 15;
            offsetX = 9;
            offsetY = 7;

            used = false;

            woodenSword = new IPlayerItemSprite[4];
            for (int i = 0; i < 4; i++)
            {
                woodenSword[i] = PlayerItemFactory.Instance.CreateWoodenSword(i);
            }

            this.item = item;

            rectangle = new Rectangle();
        }
        public void UseItem(int itemNum) 
        {
        }
        public string GetItemName()
        {
            return "RangedWoodenSword";
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
                item.state = new RangedWoodenEdge(item);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            if (!used)
            {
                switch (direction)
                {
                    case 0: /* front */
                        woodenSword[2].Draw(spriteBatch, x += (int)(13 * LoadAll.Instance.scale) / 2 - offsetX, y += (int)(13 * LoadAll.Instance.scale), currentFrame, direction);
                        break;
                    case 1: /* right */
                        woodenSword[1].Draw(spriteBatch, x += (int)(13 * LoadAll.Instance.scale), y += (int)(13 * LoadAll.Instance.scale) / 2 - offsetY, currentFrame, direction);
                        break;
                    case 2: /* back */
                        woodenSword[0].Draw(spriteBatch, x += (int)(13 * LoadAll.Instance.scale) / 2 - offsetX, y -= (int)(13 * LoadAll.Instance.scale), currentFrame, direction);
                        break;
                    case 3: /* left */
                        woodenSword[3].Draw(spriteBatch, x -= (int)(13 * LoadAll.Instance.scale), y += (int)(13 * LoadAll.Instance.scale) / 2 - offsetY, currentFrame, direction);
                        break;
                    default:
                        break;
                }
            }
            switch (direction)
            {
                case 0: /* front */
                    y += speed;
                    rectangle = woodenSword[2].Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 1: /* right */
                    x += speed;
                    rectangle = woodenSword[1].Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 2: /* back */
                    y -= speed;
                    rectangle = woodenSword[0].Draw(spriteBatch, x, y, currentFrame, direction);
                    break;
                case 3: /* left */
                    x -= speed;
                    rectangle = woodenSword[3].Draw(spriteBatch, x, y, currentFrame, direction);
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

