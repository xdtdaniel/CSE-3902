using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game1.Code.Block
{
    class MovableBlock : IBlock
    {

        private Vector2 initPos;
        private Vector2 destPos;
        private float x;
        private float y;

        private int frame;
        private int frameThreshold;

        private ISprite block;

        private Texture2D Texture;
        private bool movable = true;

        // private Vector2 location;

        public MovableBlock(Texture2D texture, Vector2 originalPos)
        {
            Texture = texture;
            initPos = originalPos;
            x = originalPos.X;
            y = originalPos.Y;
            frameThreshold = 60;
            block = new NonMovingNonAnimatedSprite(texture);
        }

        public void DrawBlock(SpriteBatch spriteBatch, Vector2 location)
        {
            block.Draw(spriteBatch, new Vector2(x, y));
        }

        public Rectangle GetRectangle(Vector2 location)
        {
            if (movable)
            {
                return new Rectangle((int)x, (int)y, (int)(Texture.Width * LoadAll.Instance.scale), (int)(Texture.Height * LoadAll.Instance.scale));
            }
            else
            {
                return new Rectangle((int)destPos.X, (int)destPos.Y, (int)(Texture.Width * LoadAll.Instance.scale), (int)(Texture.Height * LoadAll.Instance.scale));
            }
            
        }

        public void SetDestination(string side)
        {
            if (LoadAll.Instance.noEnemy && movable) 
            { 
                movable = false;

                switch (side)
                {
                    case "left":
                        destPos.X = initPos.X - (float)(LoadAll.Instance.multiplier * LoadAll.Instance.scale * 2);
                        destPos.Y = initPos.Y;
                        break;
                    case "right":
                        destPos.X = initPos.X + (float)(LoadAll.Instance.multiplier * LoadAll.Instance.scale * 2);
                        destPos.Y = initPos.Y;
                        break;
                    case "up":
                        destPos.X = initPos.X;
                        destPos.Y = initPos.Y - (float)(LoadAll.Instance.multiplier * LoadAll.Instance.scale * 2);
                        break;
                    case "down":
                        destPos.X = initPos.X;
                        destPos.Y = initPos.Y + (float)(LoadAll.Instance.multiplier * LoadAll.Instance.scale * 2);
                        break;
                }

                
                if (LoadAll.Instance.SwitchToAlternative(""))
                {
                    LoadAll.Instance.LoadRoom();
                }
                
            }
        }

        public void UpdateBlock()
        {

            if (!movable)
            {
                if (frame < frameThreshold)
                {
                    frame++;
                    x = initPos.X + (destPos.X - initPos.X) * frame / frameThreshold;
                    y = initPos.Y + (destPos.Y - initPos.Y) * frame / frameThreshold;
                }

                else
                {
                    x = destPos.X;
                    y = destPos.Y;
                }
            }
        }
    }
}
