using Game1.Code.LoadFile;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Player.PlayerItem.PlayerItemSprite
{
    class SwordBarrage
    {
        /*Texture2D texture;
        int sourceWidth;
        int sourceHeight;
        int destinationWidth;
        int destinationHeight;
        float[] angle;
        Rectangle sourceRectangle;
        Rectangle[] destinationRectangle;
        Vector2 origin;
        int currentFrame;
        int rectX;
        int rectY;
        double xDistance;
        double yDistance;
        double angle2;
        int xSpeed;
        int ySpeed;
        public SwordBarrage(Texture2D texture)
        {
            this.texture = texture;
            sourceWidth = texture.Width;
            sourceHeight = texture.Height;
            destinationWidth = (int)(LoadAll.Instance.scale * texture.Width / 60);
            destinationHeight = (int)(LoadAll.Instance.scale * texture.Height / 60);
            angle = new float[8];
            sourceRectangle = new Rectangle(0, 0, sourceWidth, sourceHeight);
            destinationRectangle = new Rectangle[8];
            origin = new Vector2(sourceWidth / 2, sourceHeight / 2);

            for (int i = 0; i < 8; i++)
            {
                if (i < 4)
                {
                    angle[i] = MathHelper.ToRadians(180 - (18 * (i + 1)));
                }
                else
                {

                    angle[i] = MathHelper.ToRadians(18 * (i - 3));
                }
            }
            currentFrame = 0;
            rectX = 0;
            rectY = 0;
            xDistance = Math.Abs(link.x - rectX);
            yDistance = Math.Abs(link.y - rectY);
            angle = Math.Atan(xDistance / yDistance);
            xSpeed = Convert.ToInt32(speed * Math.Sin(angle));
            ySpeed = Convert.ToInt32(speed * Math.Cos(angle));
        }
        public void Update()
        {
            currentFrame++;
        }

        public void Draw(SpriteBatch spriteBatch, Link link)
        {
            int speed = 5;
            for (int i = 0; i < 8; i++)
            {
                if (i < 4)
                {
                    rectX = link.x - i * 30;
                    rectY = link.y - 100 + i * 20; 
                    double xDistance = Math.Abs(link.x - rectX);
                    double yDistance = Math.Abs(link.y - rectY);
                    double angle = Math.Atan(xDistance / yDistance);
                    int xSpeed = Convert.ToInt32(speed * Math.Sin(angle));
                    int ySpeed = Convert.ToInt32(speed * Math.Cos(angle));
                    if (rectX < link.x)
                    {
                        rectX += xSpeed;
                    }
                    if (rectY < link.y)
                    {
                        rectY += ySpeed;
                    }
                    destinationRectangle[i] = new Rectangle(rectX, rectY, destinationWidth, destinationHeight);
                }
                else
                {
                    rectX = link.x - (i - 4) * 30;
                    rectY = link.y + 100 - (i - 4) * 10;
                    destinationRectangle[i] = new Rectangle(rectX, rectY, destinationWidth, destinationHeight);
                }
                spriteBatch.Draw(texture, destinationRectangle[i], sourceRectangle, Color.White, angle[i], origin, SpriteEffects.None, 1);
            }
        }
    }*/
    }
}
