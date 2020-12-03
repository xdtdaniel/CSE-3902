using Game1.Code.Achievement.Tracker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            trackerList.Add(new DragonSlayerTracker(game));
            trackerList.Add(new MasterTracker(game));
            trackerList.Add(new PentaKillTracker(game));
            trackerList.Add(new PerfectionTracker(game));
            trackerList.Add(new StopRollingTracker(game));
            trackerList.Add(new TrialAndErrorTracker(game));
            trackerList.Add(new WealthyTracker(game));
            trackerList.Add(new WrathOfTheDeadTracker(game));
        }
        public void Update(int x, int y)
        {
            bool done = false;

            // traverse to check if any achievement is completed
            for (int i = 0; i < trackerList.Count; i++)
            {
                bool completed = trackerList[i].AchievementCompleted();
                if (!completed)
                {
                    // keep tracking if not done yet
                    done = trackerList[i].Update(false, x, y);

                    // remove from list if display is done
                    if (done)
                    {
                        trackerList.RemoveAt(i);
                        i--;
                    }
                }
                else if (completed && !done)
                {
                    // move to wait list if completed
                    if (!drawingWaitList.Contains(trackerList[i]))
                    {
                        drawingWaitList.Add(trackerList[i]);
                    }
                }

            }

            if (drawingWaitList.Count > 0)
            {
                // only update the first one
                done = drawingWaitList[0].Update(true, x, y);

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
