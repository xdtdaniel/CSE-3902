using Game1.Code.Achievement.Factory;
using Game1.Code.Audio;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1.Code.Achievement.Tracker
{
    class UndefeatedTracker : ITracker
    {
        private Game1 game;
        private Texture2D undefeatedSprite;

        private static int scale = (int)LoadAll.Instance.scale;

        private bool completed = false;
        private bool doneDisplay = false;
        private int movedDistance = 0;
        private int goalDistance = 300;

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

        public UndefeatedTracker(Game1 game)
        {
            this.game = game;
            undefeatedSprite = AchievementFactory.GetUndefeated();
            prevX = currX = game.link.x;
            prevY = currY = game.link.y;

        }

        public bool Update(bool startDrawing)
        {
            // to do
            return doneDisplay;
        }

        public void Draw(int x, int y)
        {
            if (completed && !doneDisplay)
            {
                Rectangle sourceRectangle = new Rectangle(0, 0, undefeatedSprite.Width, undefeatedSprite.Height);
                Rectangle destinationRectangle = new Rectangle(startX, startY, drawWidth, drawHeight);
                game._spriteBatch.Draw(undefeatedSprite, destinationRectangle, sourceRectangle, Color.White * ((float)currentFrame / transitionTime));
            }
        }
        public bool AchievementCompleted()
        {
            return completed;
        }
    }
}
