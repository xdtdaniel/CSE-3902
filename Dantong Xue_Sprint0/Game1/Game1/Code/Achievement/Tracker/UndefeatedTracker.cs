using Game1.Code.Achievement.Factory;
using Game1.Code.Audio;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace Game1.Code.Achievement.Tracker
{
    class UndefeatedTracker : ITracker
    {
        private Game1 game;
        private Texture2D texture;

        private static int scale = (int)LoadAll.Instance.scale;

        private bool completed = false;
        private bool doneDisplay = false;

        private int currentFrame = 0;
        private int totalFrame = 100;
        private int displayTime = 200;
        private int stayedTime = 0;
        private int transitionTime = 60;

        private int offset_x = 38 * scale;
        private int offset_y = 1 * scale;
        private int start_x = 68 * scale;
        private int start_y = 56 * scale;
        private int drawWidth = 180 * scale;
        private int drawHeight = 81 * scale;

        private int goalDeaths = 5;

        public UndefeatedTracker(Game1 game)
        {
            this.game = game;
            texture = AchievementFactory.GetUndefeated();

        }

        public bool Update(bool startDrawing, int x, int y)
        {
            start_x = x + offset_x;
            start_y = y + offset_y;

            if (!completed)
            {
                game.link.itemList["Heart"] = 1;

                if (game.deaths >= goalDeaths)
                {
                    completed = true;
                }
                
                if (completed)
                {
                    // award
                    // max health += 3
                    game.link.itemList["HeartContainer"] += 3;
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
