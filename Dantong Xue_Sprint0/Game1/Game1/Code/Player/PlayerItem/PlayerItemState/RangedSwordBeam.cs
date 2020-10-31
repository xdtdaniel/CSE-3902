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
    class RangedSwordBeam : IPlayerItemState
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

        IPlayerItemSprite[] swordBeam;

        Rectangle rectangle;


        public RangedSwordBeam(LinkItem item)
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

            swordBeam = new IPlayerItemSprite[4];
            for (int i = 0; i < 4; i++)
            {
                swordBeam[i] = PlayerItemFactory.Instance.CreateSwordBeam(i);
            }

            this.item = item;

            rectangle = new Rectangle();
        }
        public void UseItem(int itemNum) 
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
                        swordBeam[2].Draw(spriteBatch, x += (int)(13 * LoadAll.Instance.scale) / 2 - offsetX, y += (int)(13 * LoadAll.Instance.scale), currentFrame, direction);
                        break;
                    case 1: /* right */
                        swordBeam[1].Draw(spriteBatch, x += (int)(13 * LoadAll.Instance.scale), y += (int)(13 * LoadAll.Instance.scale) / 2 - offsetY, currentFrame, direction);
                        break;
                    case 2: /* back */
                        swordBeam[0].Draw(spriteBatch, x += (int)(13 * LoadAll.Instance.scale) / 2 - offsetX, y -= (int)(13 * LoadAll.Instance.scale), currentFrame, direction);
                        break;
                    case 3: /* left */
                        swordBeam[3].Draw(spriteBatch, x -= (int)(13 * LoadAll.Instance.scale), y += (int)(13 * LoadAll.Instance.scale) / 2 - offsetY, currentFrame, direction);
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

