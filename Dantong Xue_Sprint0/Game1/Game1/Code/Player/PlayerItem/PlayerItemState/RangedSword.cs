using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;
using Game1.Code.LoadFile;
using Game1.Code.Player.PlayerCharacter;

namespace Game1.Code.Player.PlayerItem.PlayerItemState
{
    class RangedSword : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;
        private Link link;
        private int direction;
        private int damageMultiplier = 1;

        private int sword_x;
        private int sword_y;
        private int swordCurrentFrame = 0;
        private int swordTotalFrame = 3000;

        private int edge_x;
        private int edge_y;
        private int edgeCurrentFrame = 0;
        private int edgeTotalFrame = 15;
        private int edgeSpeed = 2 * scale;
        private int edgeRectSideLengthOffset = 8 * scale;

        private int phase = 0;

        private bool done = false;

        private int speed = 5 * scale;
        private int offsetX = 3 * scale;
        private int offsetY = 3 * scale;
        private bool used = false;
        private int numberOfSprite = 4;

        private IPlayerItemSprite[] sword;
        private IPlayerItemSprite[] edge;

        private Rectangle rectangle;


        public RangedSword(Link link, int type)
        {
            direction = link.directionIndex;
            sword_x = link.x;
            sword_y = link.y;

            sword = new IPlayerItemSprite[numberOfSprite];
            edge = new IPlayerItemSprite[numberOfSprite];
            switch (type)
            {
                case 0:
                    for (int i = 0; i < numberOfSprite; i++)
                    {
                        sword[i] = PlayerItemFactory.Instance.CreateWoodenSword(i);
                        edge[i] = PlayerItemFactory.Instance.CreateWoodenEdge(i);
                    }
                    break;
                case 1:
                    for (int i = 0; i < numberOfSprite; i++)
                    {
                        sword[i] = PlayerItemFactory.Instance.CreateSwordBeam(i);
                        edge[i] = PlayerItemFactory.Instance.CreateBeamEdge(i);
                    }
                    break;
                default:
                    break;
            }
        

            this.link = link;

            rectangle = new Rectangle();
        }
        public void UseItem(string itemName) 
        {
        }
        public string GetItemName()
        {
            if (phase == 0)
            {
                return "RangedSword";
            }
            else if (phase == 1)
            {
                return "SwordEdge";
            }
            else
            {
                return "";
            }
        }
        public int GetDamage()
        {
            return link.basicAttackDamage * damageMultiplier;
        }
        public void CollisionResponse()
        {
            if (phase == 0)
            {
                swordCurrentFrame = swordTotalFrame;
            }
        }
        public void Update() 
        {
            if (phase == 0)
            {
                swordCurrentFrame++;
                if (swordCurrentFrame >= swordTotalFrame)
                {
                    swordCurrentFrame = 0;
                    phase = 1;
                    edge_x = sword_x;
                    edge_y = sword_y;
                }
            }
            else if (phase == 1)
            {
                edgeCurrentFrame++;
                if (edgeCurrentFrame >= edgeTotalFrame)
                {
                    done = true;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (phase == 0)
            {
                if (!used)
                {
                    switch (direction)
                    {
                        case 0: /* front */
                            sword[2].Draw(spriteBatch, sword_x += link.linkWidth / 2 - offsetX, sword_y += link.linkHeight, swordCurrentFrame, direction);
                            break;
                        case 1: /* right */
                            sword[1].Draw(spriteBatch, sword_x += link.linkWidth, sword_y += link.linkHeight / 2 - offsetY, swordCurrentFrame, direction);
                            break;
                        case 2: /* back */
                            sword[0].Draw(spriteBatch, sword_x += link.linkWidth / 2 - offsetX, sword_y -= link.linkHeight, swordCurrentFrame, direction);
                            break;
                        case 3: /* left */
                            sword[3].Draw(spriteBatch, sword_x -= link.linkWidth, sword_y += link.linkHeight / 2 - offsetY, swordCurrentFrame, direction);
                            break;
                        default:
                            break;
                    }
                }
                switch (direction)
                {
                    case 0: /* front */
                        sword_y += speed;
                        rectangle = sword[2].Draw(spriteBatch, sword_x, sword_y, swordCurrentFrame, direction);
                        break;
                    case 1: /* right */
                        sword_x += speed;
                        rectangle = sword[1].Draw(spriteBatch, sword_x, sword_y, swordCurrentFrame, direction);
                        break;
                    case 2: /* back */
                        sword_y -= speed;
                        rectangle = sword[0].Draw(spriteBatch, sword_x, sword_y, swordCurrentFrame, direction);
                        break;
                    case 3: /* left */
                        sword_x -= speed;
                        rectangle = sword[3].Draw(spriteBatch, sword_x, sword_y, swordCurrentFrame, direction);
                        break;
                    default:
                        break;
                }
                used = true;
            }
            else if (phase == 1)
            {
                edge[0].Draw(spriteBatch, edge_x - edgeSpeed * edgeCurrentFrame, edge_y - edgeSpeed * edgeCurrentFrame, edgeCurrentFrame, direction);
                edge[1].Draw(spriteBatch, edge_x + edgeSpeed * edgeCurrentFrame, edge_y - edgeSpeed * edgeCurrentFrame, edgeCurrentFrame, direction);
                edge[2].Draw(spriteBatch, edge_x - edgeSpeed * edgeCurrentFrame, edge_y + edgeSpeed * edgeCurrentFrame, edgeCurrentFrame, direction);
                edge[3].Draw(spriteBatch, edge_x + edgeSpeed * edgeCurrentFrame, edge_y + edgeSpeed * edgeCurrentFrame, edgeCurrentFrame, direction);
            }
        }
        
        public Rectangle GetRectangle()
        {
            if (phase == 1)
            {
                int start_x = edge_x - edgeSpeed * edgeCurrentFrame;
                int start_y = edge_y - edgeSpeed * edgeCurrentFrame;
                int width = edgeSpeed * edgeCurrentFrame * 2 + edgeRectSideLengthOffset;
                int height = edgeSpeed * edgeCurrentFrame * 2 + edgeRectSideLengthOffset;
                rectangle = new Rectangle(start_x, start_y, width, height);
            }
            return rectangle;
        }
        public bool IsDone()
        {
            return done;
        }
    }
}

