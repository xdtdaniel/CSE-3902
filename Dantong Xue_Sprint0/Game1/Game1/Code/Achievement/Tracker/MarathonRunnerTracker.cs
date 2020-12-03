using Game1.Code.Achievement.Factory;
using Game1.Code.Audio;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace Game1.Code.Achievement.Tracker
{
    class MarathonRunnerTracker: ITracker
    {
        private Game1 game;
        private Texture2D texture;

        private static int scale = (int)LoadAll.Instance.scale;

        private bool completed = false;
        private bool doneDisplay = false;

        private int movedDistance = 0;
        private int goalDistance = 3333 * scale; 

        private int currentFrame = 0;
        private int totalFrame = 100;
        private int displayTime = 200;
        private int stayedTime = 0;
        private int transitionTime = 60;

        private int offset_x = 38 * scale;
        private int offset_y = 1 * scale;
        private int start_x;
        private int start_y;
        private int drawWidth = 180 * scale;
        private int drawHeight = 81 * scale;

        private int prevX;
        private int prevY;
        private int currX;
        private int currY;

        public MarathonRunnerTracker(Game1 game)
        {
            this.game = game;
            texture = AchievementFactory.GetMarathonRunner();
            prevX = currX = game.link.x;
            prevY = currY = game.link.y;

        }

        public bool Update(bool startDrawing, int x, int y)
        {
            start_x = x + offset_x;
            start_y = y + offset_y;
            if (!completed)
            {
                currX = game.link.x;
                currY = game.link.y;

                if (prevX != currX || prevY != currY)
                {
                    movedDistance += Math.Abs(prevX - currX) + Math.Abs(prevY - currY);
                    prevX = currX;
                    prevY = currY;
                }

                if (movedDistance >= goalDistance)
                {
                    completed = true;
                }
                if (completed)
                { 
                    // award
                    // rupee += 10
                    game.link.itemList["Ruby"] += 10;
                    AudioPlayer.getItem.Play();
                }
            }
            else if (!doneDisplay && startDrawing)
            {
                if (currentFrame < totalFrame && stayedTime < displayTime)
                {
                    currentFrame++;
                }
                else if (currentFrame > 0 && stayedTime >= displayTime)
                {
                    currentFrame--;
                }
                else if (currentFrame == 0)
                {
                    doneDisplay = true;
                }
                else
                {
                    stayedTime++;
                }
            }
            return doneDisplay;
        }

        public void Draw()
        {
            if (completed && !doneDisplay)
            {
                Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
                Rectangle destinationRectangle = new Rectangle(start_x, start_y, drawWidth, drawHeight);
                game._spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White * ((float)currentFrame / transitionTime));
            }
        }
        public bool AchievementCompleted()
        {
            return completed;
        }
    }
}
