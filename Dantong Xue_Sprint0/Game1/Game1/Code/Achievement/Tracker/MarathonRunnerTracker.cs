using Game1.Code.Achievement.Factory;
using Game1.Code.Audio;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1.Code.Achievement.Tracker
{
    class MarathonRunnerTracker: ITracker
    {
        private Game1 game;
        private Texture2D marathonRunnerSprite;

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

        private int startX = 68 * scale;
        private int startY = 56 * scale;
        private int drawWidth = 120 * scale;
        private int drawHeight = 54 * scale;

        private int prevX;
        private int prevY;
        private int currX;
        private int currY;

        public MarathonRunnerTracker(Game1 game)
        {
            this.game = game;
            marathonRunnerSprite = AchievementFactory.GetMarathonRunner();
            prevX = currX = game.link.x;
            prevY = currY = game.link.y;

        }

        public bool Update(bool startDrawing)
        {
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
                Rectangle sourceRectangle = new Rectangle(0, 0, marathonRunnerSprite.Width, marathonRunnerSprite.Height);
                Rectangle destinationRectangle = new Rectangle(startX, startY, drawWidth, drawHeight);
                game._spriteBatch.Draw(marathonRunnerSprite, destinationRectangle, sourceRectangle, Color.White * ((float)currentFrame / transitionTime));
            }
        }
        public bool AchievementCompleted()
        {
            return completed;
        }
    }
}
