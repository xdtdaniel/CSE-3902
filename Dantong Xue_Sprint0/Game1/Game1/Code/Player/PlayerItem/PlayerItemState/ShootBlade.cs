using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Player.Interface;
using Game1.Code.Player.Factory;
using Game1.Code.LoadFile;
using System;
using Game1.Code.Player.PlayerCharacter;
using Game1.Code.Audio;
using System.Diagnostics;
using System.Collections.Generic;

namespace Game1.Code.Player.PlayerItem.PlayerItemState
{
    class ShootBlade : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;

        private int damageMultiplier = 2;
        private int currentDamage = 2;
        private bool done = false;
        private List<int> hitEnemyList = new List<int>();

        private int sword_x;
        private int sword_y;
        private int swordOffset_x;
        private int swordOffset_y;
        private int radius = 15 * scale;
        private int swordWidth = 6 * scale;
        private int swordHeight = 13 * scale;
        private int swordCurrentFrame = 0;
        private int swordSecondFrame = 0;
        private int swordMaxSecondFrame = 80;
        private int swordThirdFrame = 0;
        private int swordMaxThirdFrame = 20;
        private int swordTotalFrame = 3000;
        private int swordFloatSpeed = 1 * scale;
        private int swordShootSpeed = 10 * scale;

        private int edge_x;
        private int edge_y;
        private int edgeWidth = 13 * scale;
        private int edgeHeight = 13 * scale;
        private int edgeCurrentFrame = 0;
        private int edgeTotalFrame = 15;
        private int edgeSpeed = 2 * scale;

        private int phase = 0;

        private float angle;

        private Texture2D blade;
        private Texture2D edge;
        private int numberOfSprite = 4;

        private Link link;

        private Rectangle rect = new Rectangle();


        public ShootBlade(Link link, float angle, int x, int y)
        {
            AudioPlayer.swordSlash.Play();
            this.link = link;
            this.angle = angle;
            sword_x = x + link.linkWidth / 2;
            sword_y = y + link.linkHeight / 2;

            swordOffset_x = (int)(radius * Math.Sin(angle));
            swordOffset_y = -(int)(radius * Math.Cos(angle));

            blade = PlayerAbilityFactory.Instance.GetBlade();

            edge = PlayerAbilityFactory.Instance.GetBladeEdge();
            
        }
        public string GetItemName()
        {
            return "RangedSword";
        }
        public int GetDamage()
        {
            return link.basicAttackDamage * currentDamage;
        }
        public void CollisionResponse(int enemyIndex)
        {
            Camera.ShakeCamera(1);
            if (phase == 0)
            {
                swordCurrentFrame = swordTotalFrame;
            }
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
            if (phase == 0)
            {
                swordSecondFrame++;
                if (swordSecondFrame >= swordMaxSecondFrame)
                {
                    swordCurrentFrame++;
                    swordThirdFrame++;
                    int speed_x;
                    int speed_y;
                    if (swordThirdFrame < swordMaxThirdFrame)
                    {
                        speed_x = (int)(swordFloatSpeed * Math.Sin(angle));
                        speed_y = -(int)(swordFloatSpeed * Math.Cos(angle));
                    }
                    else
                    {
                        speed_x = (int)(swordShootSpeed * Math.Sin(angle));
                        speed_y = -(int)(swordShootSpeed * Math.Cos(angle));
                    }
                    sword_x += speed_x;
                    sword_y += speed_y;
                }
                if (swordCurrentFrame >= swordTotalFrame)
                {
                    swordSecondFrame++;
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
                Rectangle sourceRectangle = new Rectangle(0, 0, blade.Width, blade.Height);
                Rectangle destinationRectangle = new Rectangle(sword_x + swordOffset_x, sword_y + swordOffset_y, swordWidth, swordHeight);
                Vector2 origin = new Vector2(blade.Width / 2, blade.Height / 2);

                spriteBatch.Draw(blade, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);
            }
            else if (phase == 1)
            {
                for (int i = 0; i < numberOfSprite; i++)
                {
                    int rotationDegree = 90 * i;
                    angle = (float)(Math.PI / 180) * rotationDegree;
                    Rectangle sourceRectangle = new Rectangle(0, 0, edge.Width, edge.Height);
                    int xSign;
                    int ySign;
                    if (Math.Sin(angle - Math.PI / 4) > 0)
                    {
                        xSign = 1;
                    }
                    else
                    {
                        xSign = -1;
                    }
                    if (-Math.Cos(angle - Math.PI / 4) > 0)
                    {
                        ySign = 1;
                    }
                    else
                    {
                        ySign = -1;
                    }
                    int edgeMovement_x = edgeSpeed * edgeCurrentFrame * xSign;
                    int edgeMovement_y = edgeSpeed * edgeCurrentFrame * ySign;


                    Rectangle destinationRectangle = new Rectangle(edge_x + edgeMovement_x, edge_y + edgeMovement_y, edgeWidth, edgeHeight);
                    Vector2 origin = new Vector2(edge.Width / 2, edge.Height / 2);

                    spriteBatch.Draw(edge, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);
                }
            }
        }
        
        public Rectangle GetRectangle()
        {
            if (phase == 0)
            {
                rect = new Rectangle(sword_x, sword_y, swordHeight, swordHeight);
            }
            else if (phase == 1)
            {
                int edgeMovement_x = edgeSpeed * edgeCurrentFrame;
                int edgeMovement_y = edgeSpeed * edgeCurrentFrame;
                int hitboxWidth = edgeMovement_x * 2;
                int hitboxHeight = edgeMovement_y * 2;
                rect = new Rectangle(edge_x - edgeMovement_x, edge_y - edgeMovement_y, hitboxWidth, hitboxHeight);
            }
            return rect;
        }
        public bool IsDone()
        {
            return done;
        }
    }
}

