using Game1.Code.Achievement.Tracker;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Achievement
{
    public class AchievementPanel
    {
        private List<ITracker> drawingWaitList; // if multiple achievements are accomplished, draw them one by one
        private List<ITracker> trackerList;

        public AchievementPanel(Game1 game)
        {
            drawingWaitList = new List<ITracker>();

            trackerList = new List<ITracker>();
            trackerList.Add(new MarathonRunnerTracker(game));
            trackerList.Add(new UndefeatedTracker(game));
        }
        public void Update()
        {
            bool done = false;

            // traverse to check if any achievement is completed
            for (int i = 0; i < trackerList.Count; i++)
            {
                bool completed = trackerList[i].AchievementCompleted();
                if (!completed)
                {
                    // keep tracking if not done yet
                    done = trackerList[i].Update(false);
                }
                else
                {
                    // move to wait list if completed
                    drawingWaitList.Add(trackerList[i]);
                }

                // remove from list if display is done
                if (done)
                {
                    trackerList.RemoveAt(i);
                    i--;
                }
            }

            if (drawingWaitList.Count > 0)
            {
                // only update the first one
                done = drawingWaitList[0].Update(true);

                // remove if done
                if (done)
                {
                    drawingWaitList.RemoveAt(0);
                }
            }
        }
        public void Draw()
        {
            if (drawingWaitList.Count > 0)
            {
                // only draw one achievement at a time
                drawingWaitList[0].Draw();
            }

        }
    }
}
