using Game1.Code.Achievement.Factory;
using Game1.Code.Audio;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Game1.Code.Achievement.Tracker
{
    class TrialAndErrorTracker : ITracker
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

        private int totalRoomNum = 21; // 21 rooms in total
        private List<int> enteredList = new List<int>();

        public TrialAndErrorTracker(Game1 game)
        {
            this.game = game;
            texture = AchievementFactory.GetTrialAndError();

        }

        public bool Update(bool startDrawing, int x, int y)
        {
            start_x = x + offset_x;
            start_y = y + offset_y;

            if (!completed)
            {
                if (!enteredList.Contains(LoadAll.Instance.GetCurrentMapID()))
                {
                    enteredList.Add(LoadAll.Instance.GetCurrentMapID());
                }
                if (enteredList.Count >= totalRoomNum)
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
