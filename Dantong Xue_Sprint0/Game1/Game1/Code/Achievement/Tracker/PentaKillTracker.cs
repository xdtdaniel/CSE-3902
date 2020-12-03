using Game1.Code.Achievement.Factory;
using Game1.Code.Audio;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1.Code.Achievement.Tracker
{
    class PentaKillTracker : ITracker
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

        // kill 5 enemies in 1 second
        private int goalKillsInTime = 5;
        private int currentTime = 0;
        private int timeInterval = 60; 
        private int currentKills = 0;
        private int prevNumOfKilled;

        public PentaKillTracker(Game1 game)
        {
            this.game = game;
            texture = AchievementFactory.GetPentaKill();

        }

        public bool Update(bool startDrawing, int x, int y)
        {
            start_x = x + offset_x;
            start_y = y + offset_y;

            if (!completed)
            {
                if (currentKills == 0)
                {
                    currentTime = 0;
                }
                else
                {
                    currentTime++;
                }

                if (currentTime >= timeInterval)
                {
                    currentKills = 0;
                }

                int newNumOfKills = Enemy.DrawAndUpdateEnemy.numberOfKilled();
                currentKills += newNumOfKills - prevNumOfKilled;
                prevNumOfKilled = newNumOfKills;
                

                if (currentKills >= goalKillsInTime) 
                { 
                    completed = true;
                }
                
                if (completed)
                {
                    // award
                    // increase link's agility
                    game.link.timeBetweenAttack = (int)(game.link.timeBetweenAttack * 0.8);
                    game.link.timeBetweenDash = (int)(game.link.timeBetweenDash * 0.8);
                    game.link.timeBetweenJump = (int)(game.link.timeBetweenJump * 0.8);
                    game.link.timeBetweenItem = (int)(game.link.timeBetweenItem * 0.8);
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
