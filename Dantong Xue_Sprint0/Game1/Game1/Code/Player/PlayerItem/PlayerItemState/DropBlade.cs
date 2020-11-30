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
    class DropBlade : IPlayerItemState
    {

        private static int scale = (int)LoadAll.Instance.scale;

        private int damageMultiplier = 2;
        private int currentDamage = 2;
        private bool done = false;
        private List<int> hitEnemyList = new List<int>();

        private int sword_x;
        private int sword_y;
        private int sword_yThreshold = 30 * scale;
        private int swordWidth = 6 * scale;
        private int swordHeight = 13 * scale;

        private int swordShootSpeed = 2 * scale;
        private int swordDropAcc =(int) (1.0/3 * scale);

        private int edge_x;
        private int edge_y;
        private int edgeWidth = 13 * scale;
        private int edgeHeight = 13 * scale;
        private int edgeCurrentFrame = 0;
        private int edgeTotalFrame = 15;
        private int edgeSpeed = 2 * scale;

        private int phase = 0;


        private Texture2D blade;
        private Texture2D edge;
        private int numberOfSprite = 4;

        private Link link;

        private Rectangle rect = new Rectangle();


        public DropBlade(Link link, int x, int y)
        {
            AudioPlayer.swordSlash.Play();
            this.link = link;
            sword_x = x + link.linkWidth / 2;
            sword_y = y + link.linkHeight / 2;
            sword_yThreshold += y;


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
                sword_y -= swordShootSpeed;
                swordShootSpeed -= swordDropAcc;

                if (sword_y > sword_yThreshold)
                {
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
                float angle = (float)(Math.PI / 180) * 180; // turn blade to face downward
                Rectangle sourceRectangle = new Rectangle(0, 0, blade.Width, blade.Height);
                Rectangle destinationRectangle = new Rectangle(sword_x, sword_y, swordWidth, swordHeight);
                Vector2 origin = new Vector2(blade.Width / 2, blade.Height / 2);

                spriteBatch.Draw(blade, destinationRectangle, sourceRectangle, Color.White, angle, origin, SpriteEffects.None, 1);

            }
            else if (phase == 1)
            {
                for (int i = 0; i < numberOfSprite; i++)
                {
                    int rotationDegree = 90 * i;
                    float angle = (float)(Math.PI / 180) * rotationDegree;
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
            if (phase == 1)
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

